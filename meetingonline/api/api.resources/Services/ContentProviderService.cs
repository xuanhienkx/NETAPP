using api.common.Models;
using api.common.Settings;
using api.common.Shared;
using api.common.Shared.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace api.resources.Services
{
    public class ContentProviderService : IContentProviderService
    {
        private readonly ApplicationSettings settings;
        private readonly IFileService fileService;
        private readonly ILocalizer localizer;
        private readonly string emailTemplateFile = ".data/email-template.vi.json";
        private JObject emailContents;

        public ContentProviderService(ApplicationSettings settings, IFileService fileService, ILocalizer localizer)
        {
            this.fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));

            this.emailTemplateFile = fileService.GetPath(emailTemplateFile);
        }

        #region EmailContent

        public EmailContent GenerateEmailForSignUp(AccountInfo user, string loginCode, string passwordToken)
        {
            var passwordUrl = $"{settings.ClientUrl}/auth/reset-password?userId={user.Id}&token={HttpUtility.UrlEncode(passwordToken)}";
            return Parse("register", new Dictionary<string, string>
            {
                {"{{NAME}}", user.DisplayName},
                {"{{USER_NAME}}", user.UserName },
                {"{{PASS_URL}}", passwordUrl},
                {"{{CODE}}", loginCode}
            });
        }

        public EmailContent GenerateEmailForConfirmEmail(AccountInfo user, string emailConfirmToken)
        {
            var emailUrl = $"{settings.ClientUrl}/auth/verify?userId={user.Id}&type=email&token={HttpUtility.UrlEncode(emailConfirmToken)}";
            return Parse("confirm-email", new Dictionary<string, string>
            {
                {"{{NAME}}", user.DisplayName},
                {"{{URL}}", emailUrl},
            });
        }

        public EmailContent GenerateEmailForRequestDelegation(MeetingLite meeting, AccountInfo holder, Delegation delegation)
        {
            var url = $"{settings.ClientUrl}/meeting?id={meeting.Id}";
            return Parse("request-delegation", new Dictionary<string, string>
            {
                {"{{NAME}}", delegation.DisplayName},
                {"{{MEETING_NAME}}", meeting.Name},
                {"{{MEETING_ADDRESS}}", meeting.Address},
                {"{{MEETING_DATE}}", meeting.OpenedDate.Value.ToString("dd/MM/yyyy")},
                {"{{HOLDER_NAME}}", holder.DisplayName},
                {"{{VOTES}}", delegation.Votes.ToString("N0")},
                {"{{URL}}", url},
            });
        }

        public EmailContent GenerateEmailToInformDelegateRequest(MeetingLite meeting, AccountInfo owner, List<Delegation> delegations)
        {
            var url = $"{settings.ClientUrl}/meeting?id={meeting.Id}";
            var approved = delegations.Count(x => x.ApprovedDate != null);
            return Parse("request-delegation-answer", new Dictionary<string, string>
            {
                {"{{NAME}}", owner.DisplayName},
                {"{{MEETING_NAME}}", meeting.Name},
                {"{{MEETING_ADDRESS}}", meeting.Address},
                {"{{MEETING_DATE}}", meeting.OpenedDate.Value.ToString("dd/MM/yyyy")},
                {"APPROVE_RATE", $"{approved}/{delegations.Count()}" },
                {"{{URL}}", url}
            });
        }

        public EmailContent GenerateEmailForApprovalDelegation(MeetingLite meeting, AccountInfo holder)
        {
            var url = $"{settings.ClientUrl}/meeting/delegate?id={meeting.Id}";
            return Parse("request-delegation-reminder", new Dictionary<string, string>
            {
                {"{{MEETING_NAME}}", meeting.Name},
                {"{{MEETING_ADDRESS}}", meeting.Address},
                {"{{MEETING_DATE}}", meeting.OpenedDate.Value.ToString("dd/MM/yyyy")},
                {"{{HOLDER_NAME}}", holder.DisplayName},
                {"{{URL}}", url}
            });
        }

        public EmailContent GenerateEmailForMeetingHolder(MeetingLite meeting, Holder holder)
        {
            var url = $"{settings.ClientUrl}/meeting?id={meeting.Id}";
            return Parse("request-holder", new Dictionary<string, string>
            {
                {"{{NAME}}", holder.DisplayName},
                {"{{MEETING_NAME}}", meeting.Name},
                {"{{MEETING_ADDRESS}}", meeting.Address},
                {"{{MEETING_DATE}}", meeting.OpenedDate.Value.ToString("dd/MM/yyyy")},
                {"{{HOLDER_NAME}}", holder.DisplayName},
                {"{{SHARES}}", holder.Shares.ToString("N0")},
                {"{{VOTES}}", holder.OwnedVotes.ToString("N0")},
                {"{{URL}}", url},
            });
        }

        public EmailContent GenerateEmailForResetPassword(AccountInfo user, string token)
        {
            var url = $"{settings.ClientUrl}/auth/reset-password?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
            return Parse("reset-password", new Dictionary<string, string>
            {
                {"{{NAME}}", user.DisplayName},
                {"{{URL}}", url},
            });
        }

        #endregion

        #region Report content

        public IList<PlaceHolder> GenerateReportForAttendCheckInOffline(Meeting meeting, Attendee attendee)
        {
            var listPlaceHolders = new List<PlaceHolder>();
            //meeting add
            var logo = string.IsNullOrEmpty(meeting.Logo?.FileId) ? "" : $"{settings.DataFileLocation}/{meeting.Logo.FileId}";
            var textPlaceHolderBase = new Dictionary<string, string>
            {
                {"logo", logo },
                {"header", string.IsNullOrEmpty(meeting.Header)? "": meeting.Header },
                {"meetingName", meeting.Name},
                {"attendeeNo", attendee.IdentityNumber.Substring(0,4) },
                {"attendeeName", attendee.DisplayName },
                {"attendeeIdentity", attendee.IdentityNumber },
                {"attendeeAddress", attendee.Address },
                {"attendeeRight", $"{attendee.TotalVotes:#,###}" }
            };

            //make Confirm
            var placeholder = new PlaceHolder
            {
                ReportTemplateName = "html-template-attendeeConfirm",
                ReportName = localizer.Get("report.attendee.confirm")
            };
            var textPlaceHolders = new Dictionary<string, string>();

            textPlaceHolders.AddRange(textPlaceHolderBase);
          

            if (attendee?.Mandators != null && attendee?.Mandators?.Count > 0)
            {
                textPlaceHolders.Add("showHide", "show");
                placeholder.TablePlaceHolders = new List<Dictionary<string, string[]>>
                {
                    new Dictionary<string, string[]>()
                    {
                        {"rowIndex", attendee.Mandators.Count.NumberArrayString()},
                        {"holderName", attendee.Mandators?.Select(x=>x.DisplayName).ToArray()}
                    }

                };
            }
            else
            {
                textPlaceHolders.Add("showHide", "hiden");
            }
            placeholder.TextPlaceHolders = textPlaceHolders;
            listPlaceHolders.Add(placeholder);

            //make card
            placeholder = new PlaceHolder
            {
                ReportTemplateName = "html-template-vote-card",
                ReportName = localizer.Get("report.attendee.card")
            };
            textPlaceHolders = new Dictionary<string, string>();
            textPlaceHolders.AddRange(textPlaceHolderBase);
            placeholder.TextPlaceHolders = textPlaceHolders;
            listPlaceHolders.Add(placeholder);

            //make vote ElectionMatters
            if (meeting.ElectionMatters.Count > 0)
            {
                var elections = meeting.ElectionMatters.Where(x => x.Optional).ToList();
                var matters = meeting.ElectionMatters.Where(x => !x.Optional).ToList();

                //make vote matters
                if (matters.Count > 0)
                {
                    placeholder = new PlaceHolder
                    {
                        ReportTemplateName = "html-template-vote-matters",
                        ReportName = localizer.Get("report.attendee.matterVote")
                    };
                    textPlaceHolders = new Dictionary<string, string>();
                    textPlaceHolders.AddRange(textPlaceHolderBase);

                    textPlaceHolders.Add("voteType", localizer.Get("report.attendee.voteTypeMatter"));
                    placeholder.TablePlaceHolders = new List<Dictionary<string, string[]>>
                    {
                        new Dictionary<string, string[]>()
                        {
                            {"rowIndex", matters.Count.NumberArrayString()},
                            {"matterName", matters?.Select(x=>x.Name).ToArray()}
                        }

                    };

                    placeholder.TextPlaceHolders = textPlaceHolders;
                    listPlaceHolders.Add(placeholder);
                }

                //make vote matters
                if (elections.Count > 0)
                {
                    foreach (var election in elections)
                    {
                        placeholder = new PlaceHolder
                        {
                            ReportTemplateName = "html-template-vote-election",
                            ReportName = localizer.Get("report.attendee.electionName", election?.Name)
                        };
                        textPlaceHolders = new Dictionary<string, string>();
                        textPlaceHolders.AddRange(textPlaceHolderBase);
                        textPlaceHolders.Add("matterName", election?.Name);

                        textPlaceHolders.Add("voteType", localizer.Get("report.attendee.voteTypeElection"));
                        textPlaceHolders.Add("attendeeTotalRight", $"{(attendee.TotalVotes * election?.Taken):#,###}");
                        var index = election?.Options.Count.NumberArrayString();
                        placeholder.TablePlaceHolders = new List<Dictionary<string, string[]>>
                        {
                            new Dictionary<string, string[]>()
                            {
                                {"rowIndex",index},
                                {"matterName", election?.Options.Select(x=>x.Name).ToArray()}
                            }

                        };
                        placeholder.TextPlaceHolders = textPlaceHolders;
                        listPlaceHolders.Add(placeholder);
                    }

                }

            }

            return listPlaceHolders;
        }


        #endregion

        #region private for email connten

        private EmailContent Parse(string name, IDictionary<string, string> lexer)
        {
            EnsureData();

            var email = emailContents.GetValue(name).ToObject<EmailContent>();
            var emailBody = lexer.Aggregate(email.Body, (current, l) => current.Replace(l.Key, l.Value));
            return new EmailContent(email.Title, emailBody);
        }

        private void EnsureData()
        {
            if (emailContents == null)
            {
                var file = fileService.Load(emailTemplateFile);
                using var reader = new JsonTextReader(new StringReader(file));
                emailContents = (JObject)JToken.ReadFrom(reader);
            }
        }

        #endregion
    }
}
