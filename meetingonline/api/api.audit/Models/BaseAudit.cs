using api.common.Models.Identity;
using api.common.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.audit.Models
{
    internal abstract class BaseAudit
    {
        protected BaseAudit(IdentityUser user, HttpContext httpContext)
        {
            if (httpContext is null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            User = user;
            Request = Request.From(httpContext.Request);
            Connection = Connection.From(httpContext.Connection);
            Created = new Occurrence();
        }

        public Request Request { get; internal set; }
        public Connection Connection { get; internal set; }
        public IdentityUser User { get; internal set; }
        public Occurrence Created { get; internal set; }
    }
}
