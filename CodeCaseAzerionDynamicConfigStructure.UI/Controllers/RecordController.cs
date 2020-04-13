using CodeCaseAzerionDynamicConfigStructure.DAL;
using CodeCaseAzerionDynamicConfigStructure.Model;

namespace CodeCaseAzerionDynamicConfigStructure.UI.Controllers
{
    public class RecordController : BaseController<Record>
    {
        public RecordController(RecordRepository recordRepository) : base(recordRepository)
        {
        }
    }
}
