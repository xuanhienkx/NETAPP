﻿//using MediatR;

//namespace BO.Core.Data.Events
//{
//    public class SendEmailEvent : INotification
//    {
//        public SendEmailEvent(string email, string name, EmailContent emailContent)
//        {
//            if (string.IsNullOrEmpty(email))
//            {
//                throw new ArgumentException("message", nameof(email));
//            }

//            Email = email;
//            Name = name;
//            Content = emailContent;
//        }

//        public SendEmailEvent(List<Account> accounts, EmailContent emailContent)
//        {
//            Accounts = accounts;
//            Content = emailContent;
//        }

//        public List<Account> Accounts { get; }
//        public string Email { get; }
//        public string Name { get; }
//        public EmailContent Content { get; }
//    }
//}
