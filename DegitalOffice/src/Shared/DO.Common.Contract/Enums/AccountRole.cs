using System;
using System.Collections.Generic;
using System.Text;

namespace DO.Common.Contract.Enums
{
    public enum AccountRole
    {
        /// <summary>
        /// The owner, who has greatest power to his resource
        /// </summary>
        MODERATOR,
        /// <summary>
        /// The administrative users
        /// </summary>
        ADMIN,
        ///
        /// The normarl user including customer
        ///
        USER
    }
}
