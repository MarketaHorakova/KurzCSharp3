using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;

namespace ToDoList.Test
{
    public class DeleteTests
    {
        [Fact]
        public void Delete_ExistingItem_ReturnsNoContent()
        {
            // Arrange
            var controller = new ToDoItemsController();
            var toDoItem = new ToDoItem { ToDoItemId = 1, Name = "Test Item", Description = "Test Description", IsCompleted = false };
            ToDoItemsController.items.Add(toDoItem);

            // Act
            var resultDelete = controller.DeleteById(1);

            // Assert
            Assert.IsType<NoContentResult>(resultDelete);
            Assert.DoesNotContain(toDoItem, ToDoItemsController.items);
        }

        [Fact]
        public void Delete_NonExistingItem_ReturnsNotFound()
        {
            // Arrange
            var controller = new ToDoItemsController();

            // Act
            var resultDelete = controller.DeleteById(999);

            // Assert
            Assert.IsType<NotFoundResult>(resultDelete);
        }


    }
}
