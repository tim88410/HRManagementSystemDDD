using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagementSystemDDD.Domain.Events.Leave
{
    public class LeaveUpdateNameEvent : INotification
    {
        public LeaveUpdateNameEvent(int LeaveId,
                                   string oldName,
                                   string newName)
        {
            this.LeaveId = LeaveId;
            OldName = oldName;
            NewName = newName;
        }
        public int LeaveId { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
    }
}
