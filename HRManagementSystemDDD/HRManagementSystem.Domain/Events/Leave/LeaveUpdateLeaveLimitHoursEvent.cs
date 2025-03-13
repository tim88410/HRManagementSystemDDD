﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystem.Domain.Events.Leave
{
    public class LeaveUpdateLeaveLimitHoursEvent : INotification
    {
        public LeaveUpdateLeaveLimitHoursEvent(int LeaveId,
                                   double oldLeaveLimitHours,
                                   double newLeaveLimitHours)
        {
            this.LeaveId = LeaveId;
            this.OldLeaveLimitHours = oldLeaveLimitHours;
            this.NewLeaveLimitHours = newLeaveLimitHours;
        }
        public int LeaveId { get; set; }
        public double OldLeaveLimitHours { get; set; }
        public double NewLeaveLimitHours { get; set; }
    }
}
