using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemDDD.Domain.Events.Leave
{
    public class LeaveUpdateLeaveLimitHoursEvent : INotification
    {
        public LeaveUpdateLeaveLimitHoursEvent(int LeaveId,
                                   double oldLeaveLimitHours,
                                   double newLeaveLimitHours)
        {
            this.LeaveId = LeaveId;
            OldLeaveLimitHours = oldLeaveLimitHours;
            NewLeaveLimitHours = newLeaveLimitHours;
        }
        public int LeaveId { get; set; }
        public double OldLeaveLimitHours { get; set; }
        public double NewLeaveLimitHours { get; set; }
    }
}
