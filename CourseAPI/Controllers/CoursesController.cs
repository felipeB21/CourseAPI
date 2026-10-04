using CourseAPI;
using CourseAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

[Route("api/courses")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Course>> Get()
    {
        return await _context.Courses.ToListAsync();
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Course? course = await _context.Courses.FindAsync(id);

        if (course != null)
        {
            return Ok(course);
        }

        return NotFound();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Course>> Post([FromBody] CourseRequest course)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Course newCourse = new Course { Title = course.Title, Description = course.Description , ImageUrl = course.ImageUrl, Price = course.Price, UserId = userId! };

        _context.Courses.Add(newCourse);

        await _context.SaveChangesAsync();

        return CreatedAtAction("Get", new { id = newCourse.Id }, newCourse);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Course? course = await _context.Courses.FindAsync(id);

        if (course != null)
        {
            if (course.UserId != userId) return Forbid();
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        return NotFound();
    }

    [Authorize]
    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(
        int id,
        [FromBody] CourseUpdateRequest newCourse)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        Course? course = await _context.Courses.FindAsync(id);

        if (course != null)
        {
            if (course.UserId != userId) return Forbid();
            if (newCourse.Title != null)
            {
                course.Title = newCourse.Title;
            }

            if (newCourse.Description != null)
            {
                course.Description = newCourse.Description;
            }

            if (newCourse.ImageUrl != null)
            {
                course.ImageUrl = newCourse.ImageUrl;
            }

            if (newCourse.Price.HasValue)
            {
                course.Price = newCourse.Price.Value;
            }

            await _context.SaveChangesAsync();

            return Ok(course);
        }

        return NotFound();
    }


}