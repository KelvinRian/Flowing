using Flowing.Domain.Commands.Action;
using Flowing.Domain.Dtos.Actions;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Tests.Domain.Dtos.Actions
{
    public class ActionDtoTests
    {
        [Fact]
        public void ShouldConstructActionDto()
        {
            // Arrange
            var action = new EntityAction(new AddActionCommand { Name = "Test Action" }, Guid.NewGuid());

            // Act
            var actionDto = new ActionDto(action);

            // Assert
            Assert.Equal(action.Id, actionDto.Id);
            Assert.Equal(action.Name, actionDto.Name);
            Assert.Equal(action.Status, actionDto.Status);
        }
    }
}
