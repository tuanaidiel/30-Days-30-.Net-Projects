using System.Text.Json;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.Run(async(HttpContext context) =>
{
    if (context.Request.Method == "GET")  //GET: to get or retrieve information from server
    {
        if (context.Request.Path.StartsWithSegments("/"))
        {
            await context.Response.WriteAsync($"The method is: {context.Request.Method}\r");
            await context.Response.WriteAsync($"The URL is: {context.Request.Path}\n");
            await context.Response.WriteAsync($"\nHeaders: \n");

            foreach (var key in context.Request.Headers.Keys)
            {
                await context.Response.WriteAsync($"{key}: {context.Request.Headers[key]}\r\n");
            }
        }
        else if (context.Request.Path.StartsWithSegments("/employees"))
        {
            var employees = EmployeesRepository.GetEmployees();

            foreach (var employee in employees)
            {
                await context.Response.WriteAsync($"{employee.Name}: {employee.Position}\r\n");
            }
        }
    }

    else if (context.Request.Method == "POST") //POST: to create new resources on the server
    {
        if (context.Request.Path.StartsWithSegments("/employees"))
        {
            using var reader = new StreamReader (context.Request.Body);
            var body = await reader.ReadToEndAsync();
            var employee = JsonSerializer.Deserialize<Employee>(body);

            EmployeesRepository.AddEmployee(employee);

        }
    }
});

app.Run();

static class EmployeesRepository
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee(1, "John Doe", "Engineer", 60000),
        new Employee(2, "Abu Bakar", "Manager", 80000),
        new Employee(3, "Bos Nizam", "Freelancer", 100000)
    };

    public static List<Employee> GetEmployees() => employees;

    public static void AddEmployee(Employee? employee)
    {
        if (employee is not null)
        {
            employees.Add(employee);
        }
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string position, double salary)
    {
        Id = id;
        Name = name;
        Position = position;
        Salary = salary;
    }
}