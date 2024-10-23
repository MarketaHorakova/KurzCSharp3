using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using ToDoList.Domain.Models;
using ToDoList.Domain.DTOs;

namespace ToDoList.Test
{
    public class PutTests
    {
        [Fact]
        public void Put_OneItem_ItemId()
        {
            // Arrange
            var controller = new ToDoItemsController();
            var toDoItem = new ToDoItem { ToDoItemId = 1, Name = "Test Item", Description = "Test Description", IsCompleted = false };
            ToDoItemsController.items.Add(toDoItem);

            var updateRequest = new ToDoItemUpdateRequestDto
            {
                Name = "Updated Name",
                Description = "Updated Description",
                IsCompleted = true
            };

            // Act
            var resultPut = controller.UpdateById(1, updateRequest);

            // Assert
            Assert.IsType<NoContentResult>(resultPut);
            var updatedItem = ToDoItemsController.items.Find(i => i.ToDoItemId == 1);
            Assert.Equal("Updated Name", updatedItem.Name);
            Assert.Equal("Updated Description", updatedItem.Description);
            Assert.True(updatedItem.IsCompleted);
        }
    }
}
