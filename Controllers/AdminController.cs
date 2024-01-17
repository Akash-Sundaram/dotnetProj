using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
#nullable disable

namespace LibraryManagement.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<AdminController> _logger;

    public AdminController(ApplicationDbContext context,ILogger<AdminController> logger,IWebHostEnvironment hostEnvironment)
    {
        _context=context;
        _logger=logger;
    }
    public IActionResult ManageUser()
    {
        Repository repository=new Repository();
        DataTable dataTable=repository.getUserRecords();
        return View(dataTable);
    }
    
    public IActionResult deleteUser(string userid)
    {
        Repository repository=new Repository();
        repository.removeUser(userid);
        return RedirectToAction("ManageUser","Admin");
    }
}