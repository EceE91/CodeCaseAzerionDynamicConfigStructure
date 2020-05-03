using CodeCaseAzerionDynamicConfigStructure.DAL;
using CodeCaseAzerionDynamicConfigStructure.Model;
using CodeCaseAzerionDynamicConfigStructure.UI.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CodeCaseAzerionDynamicConfigStructure.UnitTest
{
    public class CodeCaseAzerionDynamicConfigStructureTest_ForList
    {
        [Fact]
        public void Test_ListDynamicConfigRecords()
        {
            var recordList = new List<Model.Record>()
            {
                new Model.Record(){
                    Id="1",
                    ApplicationName = "SERVICE-A",
                    IsActive = true,
                    Name = "SiteName",
                    Value = "voidu.com",
                    Type = "String"
                },
                new Model.Record(){
                    Id="2",
                    ApplicationName = "SERVICE-B",
                    IsActive = true,
                    Name = "IsBasketEnabled",
                    Value = "1",
                    Type = "Boolean"
                }

            };

            // Arrange            
            var mockLogger = new Mock<ILogger<BaseController<Model.Record>>>();
            var mockRepo = new Mock<RecordRepository>("mongodb://localhost:27017/test?retryWrites=true&w=majority", "configuration", "records");

            var cs = mockRepo.Setup(repo => repo.GetList())
                .Returns(recordList);

            var controller = new RecordController(mockRepo.Object, mockLogger.Object);
            var result = controller.Index();
            Assert.IsType<Microsoft.AspNetCore.Mvc.ViewResult>(result);
            var viewRes = result as Microsoft.AspNetCore.Mvc.ViewResult;
            Assert.NotNull(viewRes.Model);
            Assert.Equal(2, ((List<Model.Record>)viewRes.Model).Count);           
        }
    }
}
