using Microsoft.AspNetCore.Mvc;
using StudentManagemnetSystem.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controllers
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StudentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if(!ModelState.IsValid || string.IsNullOrEmpty(student.Name) || student.Age <= 0)
            {
                ModelState.AddModelError("", "Name must not be empty and age must be positive");
                return View(student);
            }

            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(
                JsonSerializer.Serialize(student),
                Encoding.UTF8,
                "application/json"
            );

            var response await client.PostAsync("https//localhost:5001/api/students", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Thank You");
            }

            ModelState.AddModelErro("", "Failed to add student. Please try again");
            return View(student);
        }


        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}