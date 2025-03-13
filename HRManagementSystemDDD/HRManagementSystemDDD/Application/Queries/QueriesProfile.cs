using AutoMapper;
using HRManagementSystem.Infrastructure.Models.Leaves;
using HRManagementSystemDDD.Application.Queries.Leaves;

namespace HRManagementSystemDDD.Application.Queries
{
    public class QueriesProfile : Profile
    {
        public QueriesProfile()
        {
            CreateMap<LeavesResponse.LeavesInfo, LeavesQuery.LeavesDTO>().ReverseMap();
            CreateMap<LeavesRequest, LeavesQuery.LeavesQueryParameter>().ReverseMap();
        }
    }
}
