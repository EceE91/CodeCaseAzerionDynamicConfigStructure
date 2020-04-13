using CodeCaseAzerionDynamicConfigStructure.Model;
using MongoDB.Driver;
using System.Collections.Generic;

namespace CodeCaseAzerionDynamicConfigStructure.DAL
{
    public class RecordRepository : BaseRepository<Record>
    {
        public RecordRepository(string mongoDBConnectionString, string dbName, string collectionName) : base(mongoDBConnectionString, dbName, collectionName)
        {
        }

        public Record GetByName(string name, string applicationName)
        {
            return mongoCollection.Find<Record>(x => x.Name == name && x.ApplicationName == applicationName && x.IsActive).FirstOrDefault();
        }

        public List<Record> GetListByApplicationName(string applicationName)
        {
            return mongoCollection.Find<Record>(x => x.ApplicationName == applicationName && x.IsActive).ToList();
        }
    }
}
