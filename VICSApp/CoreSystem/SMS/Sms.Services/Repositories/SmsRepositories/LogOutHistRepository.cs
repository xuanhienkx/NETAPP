﻿using System.Data.Entity;
using SMS.Data.Services.Contexts;
using SMS.Data.Services.EF.Repositories.SmsRepositories;
using SMS.DataAccess.Models;

namespace SMS.Data.Services.Repositories.SmsRepositories
{
    public class LogOutHistRepository : Repository<SmsLogOutHist>, ILogOutHistRepository
    {
        private readonly ISmsDataContext _smsDataContext;

        public LogOutHistRepository(ISmsDataContext smsDataContext):base(smsDataContext as DbContext)
        {
            _smsDataContext = smsDataContext;
        }
    }
}