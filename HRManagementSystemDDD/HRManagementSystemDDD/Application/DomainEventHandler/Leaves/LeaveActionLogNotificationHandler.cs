using HRManagementSystemDDD.Domain.Events.Leave;
using HRManagementSystemDDD.Infrastructure.Repositories.Leaves;
using MediatR;

namespace HRManagementSystemDDD.Application.DomainEventHandler.Leaves
{
    public class LeaveActionLogNotificationHandler : INotificationHandler<LeaveActionLogEvent>
    {
        private readonly IMediator mediator;
        private readonly ILeaveActionLogRepository leaveActionLogRepository;
        public LeaveActionLogNotificationHandler(IMediator mediator, ILeaveActionLogRepository leaveActionLogRepository)
        {
            this.mediator = mediator;
            this.leaveActionLogRepository = leaveActionLogRepository;
        }
        public async Task Handle(LeaveActionLogEvent notification, CancellationToken cancellationToken)
        {
            await leaveActionLogRepository.InsertAsync(new Domain.AggregatesModel.LeaveAggregate.Leave.LeaveDomainEvent
            {
                LeaveId = notification.LeaveId,
                Action = notification.Action,
                OldValue = notification.OldValue,
                NewValue = notification.NewValue,
                OperatorId = notification.OperatorId
            });
            return;
        }

    }
}
