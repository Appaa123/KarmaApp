using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KarmaAPI.DTOS
{
    public class TaskDTO
    {
        
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public int TimeRequired { get; set; }

        public string Comments { get; set; }
    }
}