using api.common.Models;
using AutoMapper;

namespace api.common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Holder, AccountInfo>();
            CreateMap<Holder, Attendee>()
                .ForMember(x => x.TotalVotes, opt => opt.MapFrom(x => x.OwnedVotes - x.BlockedVotes + x.DelegatedVotes))
                .ForMember(x => x.SharedVotes, opt => opt.MapFrom(x => x.DelegatedVotes))
                .ForMember(x => x.DelegatingVotes, opt => opt.MapFrom(x => x.BlockedVotes))
                .ForMember(x => x.CreatedDate, opt => opt.Ignore()) 
                .ForMember(x => x.RepTitle, opt => opt.Ignore())
                .ForMember(x => x.Mandators, opt => opt.Ignore());

            CreateMap<Delegation, Holder>()
                .ForMember(x => x.DelegatedVotes, opt => opt.MapFrom(x => x.Votes));
            CreateMap<Holder, Delegation>();
            CreateMap<Attendee, Delegation>();
            CreateMap<Meeting, MeetingLite>();

            CreateMap<Vote, ElectionOption>();
            CreateMap<ElectionVote, ElectionMatter>();
        }
    }
}
