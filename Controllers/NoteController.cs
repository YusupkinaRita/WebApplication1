using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private static List<Note> _tasks = new()
        {
            new Note { Title = "task1", IsCompleted = false },
            new Note { Title = "task2", IsCompleted = true },
            new Note { Title = "task3", IsCompleted = false }
        };

        
        [HttpGet]
        public List<Note> GetAll()
        {
            return _tasks;
        }

        [HttpPost]
        public IActionResult AddTask([FromBody] string title)
        {
            var task = new Note { Title = title };
            _tasks.Add(task);
            return Ok(task);
        }

        [HttpPut]
        public IActionResult Update([FromBody] string title)
        {
            var task = _tasks.FirstOrDefault(t => t.Title == title);
            if (task == null)
                return NotFound($"Задача '{title}' не найдена");

            task.IsCompleted = !task.IsCompleted;

            return Ok(task);
        }



        [HttpDelete]
        public IActionResult Delete([FromBody] string title)
        {
            var task = _tasks.FirstOrDefault(t => t.Title == title);
            if (task == null)
                return NotFound($"Задача '{title}' не найдена");

            _tasks.Remove(task);
            return Ok($"Задача '{title}' удалена");
        }
    }
}
