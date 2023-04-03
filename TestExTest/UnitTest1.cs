using Microsoft.AspNetCore.Mvc;
using Moq;
using TestEx.Controllers;
using TestEx.Models;
using TestEx.Repository;

namespace TestExTest
{
    public class UnitTest1
    {
        private Mock<ITodoRepository> _mockRepository = new Mock<ITodoRepository>();
        private TodosController _todoController;
        public UnitTest1()
        {
            _todoController = new TodosController(_mockRepository.Object);
        }
        
        [Fact]
        public async Task Test1()
        {
            var todoDTO = new TodoDTOCreate()
            {
                Name = "Test"
            };

            var todoEnt = new Todo()
            {
                Id = 1,
                Name = "Test",
                IsActive = true
            };

            _mockRepository.Setup(x => x.AddOrUpdateAsync(It.IsAny<Todo>()))
                .ReturnsAsync(todoEnt);


            var response = await _todoController.Post(todoDTO);

            Assert.NotNull(response);
            Assert.IsType<OkObjectResult>(response.Result);
            Assert.NotNull(response.Value);
        }
    }
}