using AutoMapper;
using HRManagementSystemDDD.Application.Queries.Leaves;
using HRManagementSystemDDD.Infrastructure.Models.Leaves;

namespace HRManagementSystemDDD.Application.Queries
{
    public class QueriesProfile : Profile
    {
        public QueriesProfile()
        {
            CreateMap<LeavesResponse.LeavesInfo, LeavesQuery.LeavesDTO>().ReverseMap();
            CreateMap<LeavesRequest, LeavesQuery.LeavesQueryParameter>().ReverseMap();
            CreateMap<LeavesResponse.LeavesInfo, Domain.AggregatesModel.LeaveAggregate.Leave>().ReverseMap();
        }
    }
}
