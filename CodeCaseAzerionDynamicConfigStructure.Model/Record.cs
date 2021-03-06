﻿using MongoDB.Bson.Serialization.Attributes;

namespace CodeCaseAzerionDynamicConfigStructure.Model
{
    public class Record : BaseModel
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Value")]
        public string Value { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonElement("IsActive")]
        public bool IsActive { get; set; }

        [BsonElement("ApplicationName")]
        public string ApplicationName { get; set; }
    }
}
