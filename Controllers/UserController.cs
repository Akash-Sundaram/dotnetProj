// using System;
// using Microsoft.AspNetCore.Mvc;
// using LibraryManagement.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace LibraryManagement.Controllers;
// public class UserController : Controller
// {
//  public IActionResult Index()
//     {
//         return View(Repository.AllUsers);
//     }
// [HttpGet]

//         public IActionResult Registration()
//         {
//             return View();
//         }  
//  [HttpPost]

//         public IActionResult Registration(User user)
//         {
//             Repository.Create(user);
//             return View("Thanks", user);
//         }
//         public IActionResult DeleteRecords()
//         {
//             return View();
//         }
// [HttpPost]
//         public IActionResult DeleteRecords(User user)
//         {
//             int result=Repository.delete(user);
//             if(result==1){
//                 return View("deleted",user);
//             }
//             return View();

                
            
//         }
//         public IActionResult UpdateRecords()
//         {
//             return View();
//         }
// [HttpPost]
//         public IActionResult UpdateRecords(User user)
//         {
//             int result = Repository.update(user);
//             if(result==1)
//                 return View("success");
//             else
//                 return View("fails");
//         } 

// }
