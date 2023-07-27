using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FeedbackManagementSystem.Models;

namespace FeedbackManagementSystem.Controllers;

using BOL;
using BLL;

public class TopicListController : Controller
{
    private readonly ILogger<TopicListController> _logger;

    public TopicListController(ILogger<TopicListController> logger)
    {
        _logger = logger;
    }

    public IActionResult TopicList()
    {
        List<TopicList> tlist = Service.GetAllTopic();
        
        this.ViewData["Topiclist"]=tlist;

        return View();
    }
}
