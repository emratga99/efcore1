using efcore2.Services;
using Microsoft.AspNetCore.Mvc;
using efcore2.Model;
using efcore2.DTOs;

namespace efcore2.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpPost]
    public AddStudentResponse Add([FromBody] AddStudentRequest addRequest)
    {
        return _studentService.Create(addRequest);
    }
    }