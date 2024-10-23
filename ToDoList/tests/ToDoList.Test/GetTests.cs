using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.WebApi.Controllers;
using Xunit;
using ToDoList.Domain.Models;

namespace ToDoList.Test
{
    public class GetTests
    {
        [Fact]
        public void Get_AllItems_ReturnsAllItems()
        {
            // Arrange
            var controller = new ToDoItemsController();
            var toDoItem = new ToDoItem();
            ToDoItemsController.items.Add(toDoItem);

            // Act
            var result = controller.Read();
            var value = result.Value;
            var resultResult = result.Result;

            // Assert
            Assert.True(resultResult is OkObjectResult);
            Assert.IsType<OkObjectResult>(resultResult);
        }

        public void Get_ItemById_ItemId()
        {
            // Arrange
            var controller = new ToDoItemsController();
            var toDoItem = new ToDoItem();
            ToDoItemsController.items.Add(toDoItem);

            // Act
            var result = controller.Read();
            var value = result.Value;
            var resultResult = result.Result;

            // Assert
            Assert.True(resultResult is OkObjectResult);
            Assert.IsType<OkObjectResult>(resultResult);
        }
    }
}
