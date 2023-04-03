using System;

namespace SMS.Common.Action
{
    public class ActionEventArgs : EventArgs
    {
        private readonly bool scheduled;
        private readonly EventArgs senderArgs; 

        public ActionEventArgs(EventArgs senderArgs, bool scheduled)
        {
            this.scheduled = scheduled;
            this.senderArgs = senderArgs;
        }

        public bool Scheduled
        {
            get
            {
                return scheduled;
            }
        }

        public EventArgs SenderArgs
        {
            get
            {
                return senderArgs;
            }
        }
    }
}
