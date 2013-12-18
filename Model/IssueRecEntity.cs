using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class IssueRecEntity
    {
        public int Rid { set; get; }
        public string RoomNumber { set; get; }
        public string KeyCount { set; get; }
        public string KeyType { set; get; }
        public string OperateTime { set; get; }
        public string Workstation { set; get; }
        public string KeyCoder { set; get; }
        public string GuestName { set; get; }
        public string ArrivalDate { set; get; }
        public string DepartureDate { set; get; }
    }
}
