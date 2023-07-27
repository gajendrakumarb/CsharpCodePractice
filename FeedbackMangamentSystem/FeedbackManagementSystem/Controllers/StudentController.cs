using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FeedbackManagementSystem.Models;

namespace FeedbackManagementSystem.Controllers;

using BOL;
using BLL;

public class StudentController : Controller
{
    private readonly ILogger<StudentController> _logger;

    public StudentController(ILogger<StudentController> logger)
    {
        _logger = logger;
    }

    public IActionResult StudentList()
    {
        List<StudentFeedback> slist = Service.GetAllStudent();
        
        this.ViewData["StudentList"]=slist;

        return View();
    }

      public IActionResult FeedbackForm()
    {
        
        return View();
    }

    [HttpPost]
    public IActionResult AddFeedback(int srno, string d, string stdname, string tname, 
                                    string module, string faculty, int psr, int ps, string comment)
    {
        Service.InsertFeedback(new StudentFeedback{ SrNO=srno, D=d,StudentName=stdname, TopicName=tname,Module=module,Faculty=faculty,PSR=psr,PS=ps,Comment=comment});

        return RedirectToAction("StudentList");
    }
}