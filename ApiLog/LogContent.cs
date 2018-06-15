using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLog
{
    public class LogContent
    {
        public ObjectId _id { get; set; }
        public int UserId { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }

        public LogContent() {}

        public LogContent(int userId, string url, string username)
        {
            Username = username;
            Url = url;
            UserId = userId;
        }
    }

}
