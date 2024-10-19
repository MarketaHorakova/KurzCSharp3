namespace ToDoList.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTOs;
using ToDoList.Domain.Models;
using System.Linq;
using System;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemsController : ControllerBase
{
    public static readonly List<ToDoItem> items = [];

    [HttpPost]
    public IActionResult Create(ToDoItemCreateRequestDto request)
    {
        //map to Domain object as soon as possible
        var item = request.ToDomain();

        //try to create an item
        try
        {
            item.ToDoItemId = items.Count == 0 ? 1 : items.Max(o => o.ToDoItemId) + 1;
            items.Add(item);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }

        //respond to client
        return CreatedAtAction(nameof(Read), new { id = item.ToDoItemId }, item); //201

    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItemGetResponseDto>> Read()
    {
        List<ToDoItem> itemsToGet;
        try
        {
            itemsToGet = items;
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); //500
        }
        //respond to client
        return (itemsToGet is null)
            ? NotFound() //404
            : Ok(itemsToGet.Select(ToDoItemGetResponseDto.FromDomain)); //200
    }

    [HttpGet("{toDoItemId:int}")]
    public IActionResult ReadById(int toDoItemId)
    {
        try
        {
            var item = items.Find(i => i.ToDoItemId == toDoItemId);

            if (item == null)
            {
                return NotFound(); // 404
            }

            var response = ToDoItemGetResponseDto.FromDomain(item);
            return Ok(response); // 200
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); // 500
        }
    }

    [HttpPut("{toDoItemId:int}")]
    public IActionResult UpdateById(int toDoItemId, [FromBody] ToDoItemUpdateRequestDto request)
    {
        try
        {
            var index = items.FindIndex(i => i.ToDoItemId == toDoItemId);

            if (items[index] == null)
            {
                return NotFound(); // 404
            }

            // Aktualizace položky dle indexu
            items[index].Name = request.Name;
            items[index].Description = request.Description;
            items[index].IsCompleted = request.IsCompleted;

            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); // 500
        }
    }

    [HttpDelete("{toDoItemId:int}")]
    public IActionResult DeleteById(int toDoItemId)
    {
        try
        {
            var item = items.Find(i => i.ToDoItemId == toDoItemId);

            if (item == null)
            {
                return NotFound(); // 404
            }

            items.Remove(item);
            return NoContent(); // 204
        }
        catch (Exception ex)
        {
            return Problem(ex.Message, null, StatusCodes.Status500InternalServerError); // 500
        }
    }
}
