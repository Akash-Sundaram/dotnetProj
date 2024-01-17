using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Data;

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

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDbContext context,ILogger<HomeController> logger,IWebHostEnvironment hostEnvironment)
      {
        _context=context;
        _logger=logger;
      }
    public IActionResult Adminmodules()
    {
        return View();
    }
  
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Login(Login user)
    { 
       Repository data=new Repository();   
        if((Convert.ToString(user.Email)=="akash@admin.com")&&(Convert.ToString(user.Password)=="Akashcj@285"))
        {
            TempData["Login"]="Logged in Successfully";
            HttpContext.Session.SetString("User1",user.Email);
            Console.WriteLine(HttpContext.Session.GetString("User1"));
            
            return View("Adminmodules");
        }
        else  if(data.LoginPage(user))
        {
            HttpContext.Session.SetString("User2",user.Email);
            TempData["Login"]="Logged in Successfully";
            string? userx=HttpContext.Session.GetString("User2");
            Console.WriteLine(HttpContext.Session.GetString("User2"));
            Console.WriteLine(userx);
            return View("Usermodules");
        }
        else
        {
            ViewBag.message="Invalid credentials";
            return View("Login");
        }

   
    }

    public IActionResult Signup()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Signup(User user)
     {  
        Console.WriteLine("enter database before insertion of table");
        Repository data=new Repository();
        data.create(user);
        return View("Tq");

    }
    
    public IActionResult Dashboard(string? Bookname,decimal Bookprice)
    {
        string? userx=HttpContext.Session.GetString("User2");
        Console.WriteLine(userx);
        Repository bookdata=new Repository();
        bookdata.Reservation(userx,Bookname,Bookprice);
        IEnumerable<Books> source=_context.Books.ToList();
        return RedirectToAction("reservebook",source);
    }

    public IActionResult Reset()
    {
        return View();
    }
     public IActionResult categories()
    {
         IEnumerable<Books> books=_context.Books.ToList();
         TempData["Add"]="Book added";
        return View(books);
        
    }
    
    public IActionResult tq()
    {
        return View();
    }
    public IActionResult Usermodules()
    {
        return View();
    }
    public IActionResult AddBook()
    {
        if(HttpContext.Session.GetString("User1")!="")
        return View();
        else return Redirect("Login");
    }
    [HttpPost]
    public IActionResult AddBook(Books books)
    {
       _context.Books.Add(books);
       _context.SaveChanges();
       return View();
    } 
    public IActionResult RenewBook()
    {
        return View();
    }
    public IActionResult ReserveBooktable()
    {
        if(HttpContext.Session.GetString("User2")!=""){
        string? email=HttpContext.Session.GetString("User2");
        Repository userbooks=new Repository();
        IEnumerable<Userbook> source= userbooks.ReserveMyBook(email);
       // HttpContext.Session.SetString("User2","");
        return View("DashboardUser",source);
        }
        else if(HttpContext.Session.GetString("User1")!=""){
            Repository userbooks=new Repository();
        IEnumerable<Userbook> source=userbooks.ReserveMyBookforAdmin();
       // HttpContext.Session.SetString("User1","");
        return View("DashboardUser",source);
        }
        return View("Login");
    }
   public IActionResult reservebook()
    {    
        IEnumerable<Books> books=_context.Books.ToList();
        return View(books);
    }
    public IActionResult LogOut()
    {
        HttpContext.Session.SetString("User1","");
        HttpContext.Session.SetString("User2","");
     
        return Redirect("Login");

    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
