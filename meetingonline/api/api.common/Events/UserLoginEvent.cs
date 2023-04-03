using api.common.Models.Identity;
using api.common.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace api.common.Events
{
    public class UserLoginEvent : INotification
    {
        private const string LoginRequest = "LOGIN";
        private const string LogoutRequest = "LOGOUT";
        private const string Success = "Success";

        public string Action { get; set; }
        public string LoginName { get; set; }
        public string Result { get; set; }
        public IdentityUser User { get; set; }
        public Occurrence ActionTime { get; set; }

        public static UserLoginEvent LoginEvent(string loginName, string result = Success, IdentityUser user = null)
        {
            return new UserLoginEvent
            {
                LoginName =  loginName,
                Action = LoginRequest,
                ActionTime = new Occurrence(),
                User = user,
                Result = result
            };
        }

        public static UserLoginEvent LogoutEvent(string loginName, string result = Success, IdentityUser user = null)
        {
            return new UserLoginEvent
            {
                LoginName = loginName,
                Action = LogoutRequest,
                ActionTime = new Occurrence(),
                User = user,
                Result = result
            };
        }
    }
}
