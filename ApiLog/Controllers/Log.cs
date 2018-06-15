using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.AspNetCore.Cors;

namespace ApiLog.Controllers
{
    [Route("api/Log")]
    public class Log : Controller
    {
        Dataaccess db = new Dataaccess();

        // GET api/values
        [HttpGet]
        public List<LogContent> GetAll()
        { 
            return db.collection.Find(new BsonDocument()).ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<LogContent> GetById(int id)
        {
            return db.collection.Find(x => x.UserId == id).ToList();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] LogContent logContent)
        {
            db.collection.InsertOne(logContent);
        }
    }
}
