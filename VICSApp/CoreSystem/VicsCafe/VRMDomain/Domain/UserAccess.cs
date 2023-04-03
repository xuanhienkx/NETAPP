using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vrm
{
    class UserAccess
    {
        private int userid;
        private string accessright;

        public UserAccess(int id, String accright)
        {
            this.userid = id;
            this.accessright = accright;
        }
        public int UserId
        {
            get { return userid; }
            set { this.userid = value; }
        }
        public String AccessRight
        {
            get { return accessright; }
            set { this.accessright = value; }
        }
    }
}
