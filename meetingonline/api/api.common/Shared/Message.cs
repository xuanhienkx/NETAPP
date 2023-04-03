﻿using System;
using System.Collections.Generic;
using System.Text;

namespace api.common.Shared
{
    public class Message
    {
        public Message(string id, string data)
        {
            Id = id;
            Data = data;
        }

        public Message(string data)
        {
            Data = data;
        }

        public string Id { get; set; }
        public string Data { get; set; }
    }
}
