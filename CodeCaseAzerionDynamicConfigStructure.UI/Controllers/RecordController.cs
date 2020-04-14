using CodeCaseAzerionDynamicConfigStructure.DAL;
using CodeCaseAzerionDynamicConfigStructure.Model;
using Microsoft.Extensions.Logging;

namespace CodeCaseAzerionDynamicConfigStructure.UI.Controllers
{
    public class RecordController : BaseController<Record>
    {

        public RecordController(RecordRepository recordRepository, ILogger<BaseController<Record>> logger) : base(recordRepository, logger)
        {
        }
    }
}
