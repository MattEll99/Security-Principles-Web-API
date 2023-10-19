using AutoMapper;
using Security_Principles_Web_API.Dto;
using Security_Principles_Web_API.Models;

namespace Security_Principles_Web_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SecurityPrinciple, SecurityPrincipleDto>();
            CreateMap<SecurityPrincipleDto, SecurityPrinciple>();
            CreateMap<GroupMember, GroupMemberDto>();
            CreateMap<GroupMemberDto, GroupMember>();
        }
    }
}
