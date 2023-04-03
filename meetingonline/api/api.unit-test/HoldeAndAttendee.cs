using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.common.Models;
using api.common.Models.Identity;
using api.common.Queries;
using api.common.Shared;
using api.domain.Commands;
using api.domain.Queries;
using iText.Html2pdf;
using iText.Html2pdf.Resolver.Font;
using iText.IO.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Font;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Moq;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using Path = System.IO.Path;

namespace api.unit_test
{
    public class HoldeAndAttendee
    {
        private readonly ITestOutputHelper testOutputHelper;
        private readonly IServiceProvider serviceProvider;

        private const string MeetingId = "5ed142dbc93f8214ac093036";

        public HoldeAndAttendee(ITestOutputHelper testOutputHelper)
        {
            var user = new IdentityUser("test", "test")
            {
                MeetingAccesses = new List<MeetingAccess> {
                    new MeetingAccess
                    {
                        MeetingId = MeetingId,
                        IsOwner = true
                    }
                }
            };

            this.serviceProvider = RegisterServices.CreateServices()
                .WithCurrentUser(mock => mock.Setup(x => x.User).Returns(user))
                .BuildServiceProvider();
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task CheckinOffline()
        {
            var mediator = serviceProvider.GetService<IMediator>();

            var attendee = new Attendee
            {
                Id = "5ebfb2e40b07a80eecb3e6a9",
                Email = "a@test.com",
                IdentityNumber = "013170315",
                Address = "TEST",
                Shares = 1100,
                OwnedVotes = 1100,
                TotalVotes = 1100
            };

            var result = await mediator.Send(new MeetingUpdateContentCommand<Attendee>(MeetingId, attendee));
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(result.Value));

            var meeting = await mediator.Send(new GetByIdQuery<Meeting>(MeetingId));
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(meeting.Value.Summary));
        }
        [Theory]
        [InlineData("5ed14546c93f8214ac0931b7")]
        public async Task TestReportCheckInAttendee(string attendeeId)
        {
            var mediator = serviceProvider.GetService<IMediator>();
            var ms = await mediator.Send(new AttendeeMeetingCheckInReportCommand(MeetingId, attendeeId));
            testOutputHelper.WriteLine(JsonConvert.SerializeObject(ms));
        }


        [Theory]
        [InlineData("html-report-bks")]
        public async Task TestVoteToPdf(string name)
        {
            var mediator = serviceProvider.GetService<IMediator>();

            var attendee = new Attendee
            {
                Id = "5ed0a5898c2efd4e60eeff45",
                Email = "a@test.com",
                IdentityNumber = "013170315",
                DisplayName = @"Nguyễn Xuân Biểu",
                Address = @"2 bis Nguyễn Thị Minh Khai đakao, Quận 1 HCM",
                Shares = 1100,
                OwnedVotes = 1100,
                TotalVotes = 1100
            };
            var meeting = await mediator.Send(new GetByIdQuery<Meeting>(MeetingId));
            var mt = meeting.Value;
            var logo = $"http://localhost/media/{mt.Logo.FileId}";
            var src = $".data/{name}.html";
            var placeholders = new Placeholders();

            //You should be able to also use other OpenXML tags in your strings
            var style = File.ReadAllText(".data/report.css");
            var matter = mt.ElectionMatters.FirstOrDefault(x => x.Optional);
            placeholders.TextPlaceholders = new Dictionary<string, string>
            {
                {"style",$"<style>{style}</style>"  },
                {"logo", logo },
                {"header", mt.Header },
                {"voteType", "Bầu cử" },
                {"meetingName", mt.Name},
                {"matterName", matter?.Name },
                {"attendeeNo", "01" },
                {"attendeeName", attendee.DisplayName },
                {"attendeeIdentity", attendee.IdentityNumber },
                {"attendeeAddress", attendee.Address },
                {"attendeeRight", $"{attendee.TotalVotes}" },
                {"attendeeTotalRight",$"{attendee.TotalVotes * matter?.Taken}" },
                {"signingstarDate",$"Tp HCM, Ngày {DateTime.Today.Day} Tháng  {DateTime.Today.Month} Năm  {DateTime.Today.Year}"},
            };
            //Table ROW replacements are a little bit more complicated: With them you can
            //fill out only one table row in a table and it will add as many rows as you 
            //need, depending on the string Array.
            placeholders.TablePlaceholders = new List<Dictionary<string, string[]>>
            {


                new Dictionary<string, string[]>()
                {
                    {"index", new string[]{ "1", "2"}},
                    {"matterName", matter?.Options.Select(x=>x.Name).ToArray()}
                }

            };
            string html = File.ReadAllText(src);
            html = HtmlHandler.ReplaceAll(html, placeholders);

            var tempFileToPrint = Path.ChangeExtension(Path.GetTempFileName(), ".html");
            testOutputHelper.WriteLine(tempFileToPrint);
            File.WriteAllText(tempFileToPrint, html);

            var dest = $"D:/report/{name}-{DateTime.Now.Ticks}.pdf";
            ConverterProperties properties = new ConverterProperties();
            FontProvider fontProvider = new DefaultFontProvider(false, false, false);
            foreach (string font in FileConfiguration.Fonts)
            {
                FontProgram fontProgram = FontProgramFactory.CreateFont(font);
                fontProvider.AddFont(fontProgram);
            }

            properties.SetFontProvider(fontProvider);
            PdfWriter writer = new PdfWriter(dest);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetTagged();
            PageSize pageSize = PageSize.A4;
            pdf.SetDefaultPageSize(pageSize);
            HtmlConverter.ConvertToPdf(new FileStream(tempFileToPrint, FileMode.Open), pdf, properties);

        }
    }
}
