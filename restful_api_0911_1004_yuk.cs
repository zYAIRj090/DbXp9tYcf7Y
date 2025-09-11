// 代码生成时间: 2025-09-11 10:04:13
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// 控制器基类
[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    // 模拟数据库操作
    protected static List<TodoItem> db = new List<TodoItem>();

    public BaseController()
    {
        if (!db.Any())
        {
            db.AddRange(new[]
            {
                new TodoItem { Id = 1, Name = "Item 1" },
                new TodoItem { Id = 2, Name = "Item 2" },
                new TodoItem { Id = 3, Name = "Item 3" }
            });
        }
    }
}

// TodoItem 类
public class TodoItem
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// TodoController 类
[ApiController]
[Route("api/[controller]/[action]")]
public class TodoController : BaseController
{
    // GET: api/todo
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            var items = db.ToList();
            return Ok(items);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // GET: api/todo/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var item = db.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // POST: api/todo
    [HttpPost]
    public IActionResult Post([FromBody] TodoItem value)
    {
        try
        {
            if (value == null)
            {
                return BadRequest("Invalid data");
            }
            db.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // PUT: api/todo/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TodoItem value)
    {
        try
        {
            if (value == null || value.Id != id)
            {
                return BadRequest("Invalid data");
            }
            var item = db.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            item.Name = value.Name;
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    // DELETE: api/todo/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            var item = db.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            db.Remove(item);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
