using System;
using System.Collections.Generic;
using System.Text;

namespace api.common.Models
{
    public class MeetingSummary
    {
        public int Holders { get; set; }
        public int Shares { get; set; }
        public int Votes { get; set; }

        
        public int AttendConfirmed { get; set; }
        public int ConfirmedVotes { get; set; }
        
        /// <summary>
        /// Number of attends (online & offline), including holder & delegates
        /// </summary>
        public int CheckIn { get; set; }
        /// <summary>
        /// Number of online attend
        /// </summary>
        public int OnlineCheckIn { get; set; }
        public int HolderCheckIn { get; set; }
        public int HolderOnlineCheckIn { get; set; }

        /// <summary>
        /// Number of all votes to the meeting (online & offline)
        /// </summary>
        public int CheckInVotes { get; set; }
        /// <summary>
        /// Number of votes make online
        /// </summary>
        public int OnlineCheckInVotes { get; set; }
        /// <summary>
        /// Number of all votes to the meeting by holder (online & offline)
        /// </summary>
        public int HolderCheckInVotes { get; set; }
        public int HolderOnlineCheckInVotes { get; set; }
    }
}
