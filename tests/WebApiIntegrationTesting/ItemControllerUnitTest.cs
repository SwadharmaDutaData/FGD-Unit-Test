using System;
using System.Threading.Tasks;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Itefaces;
using Xunit;

namespace WebApiIntegrationTesting
{
    public class ItemControllerUnitTest
    {
        private readonly Mock<IItemRepository> repositoryStub = new();
        private readonly Random random = new();

        [Fact]
        public async Task GetItemAsync_WithUnexistingItem_ReturnBadRequest()      
        {
            // Arange
            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync((Item)null);
            
            var controller = new ItemController(repositoryStub.Object);

            // Act
            var result = await controller.GetItemAsync(Guid.NewGuid());

            // Assert 
            Assert.IsType<BadRequestResult>(result.Result);
        }
        
        [Fact]
        public async Task GetItemAsync_WithExistingItem_ReturnOkObjectResult()
        {
            // Arrange
            var expectedItem = GenerateItem();

            repositoryStub.Setup(repo => repo.GetItemAsync(It.IsAny<Guid>()))
                .ReturnsAsync(expectedItem); 
            
            var controller = new ItemController(repositoryStub.Object);

            // Act 
            var result = await controller.GetItemAsync(Guid.NewGuid());

            // Assert
            // Assert.IsType<Item>(result.Value);
            // var item = (result as ActionResult<Item>).Value;
            // Assert.Equal(expectedItem.Id, item.Id);
            // Assert.Equal(expectedItem.Name, item.Name);
            // Assert.Equal(expectedItem.Description, item.Description);
            // Assert.Equal(expectedItem.Price, item.Price);
            // Assert.Equal(expectedItem.CreatedDate, item.CreatedDate);
            result.Result.Should().BeOfType<OkObjectResult>();
        }
        
        private Item GenerateItem()
        {
            return new Item
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                Price = random.Next(1000),
                CreatedDate = DateTimeOffset.UtcNow 
            };
        }
    }
}
