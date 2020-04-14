using CodeCaseAzerionDynamicConfigStructure.UI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using CodeCaseAzerionDynamicConfigStructure.DAL;

namespace CodeCaseAzerionDynamicConfigStructure.UnitTest
{
    public class DynamicConfigStructureTest_ForCreate
    {
        [Fact]
        public void Test_CreateNewDynamicConfig()
        {
            var recordModel = new Model.Record()
            {
                ApplicationName = "SERVICE-A",
                IsActive = true,
                Name = "SiteName",
                Value = "voidu.com",
                Type = "String"
            };

            // Arrange            
            var mockLogger = new Mock<ILogger<BaseController<Model.Record>>>();            
            var mockRepo = new Mock<RecordRepository>("mongodb://localhost:27017/test?retryWrites=true&w=majority", "configuration", "records");
            
            var cs = mockRepo.Setup(repo => repo.Create(recordModel))
                .Returns(NewlyCreatedRecord());

            var controller = new RecordController(mockRepo.Object, mockLogger.Object);
            var resultForCreate = controller.Create(recordModel);
            Assert.IsType<Microsoft.AspNetCore.Mvc.RedirectToActionResult>(resultForCreate.Result);
            Assert.Equal(1, resultForCreate.Id);
        }

        private Model.Record NewlyCreatedRecord()
        {
            var recordModel = new Model.Record()
            {
                Id="1",
                ApplicationName = "SERVICE-A",
                IsActive = true,
                Name = "SiteName",
                Value = "voidu.com",
                Type = "String"
            };

            return recordModel;
        }
    }
}
