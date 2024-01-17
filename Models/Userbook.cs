using System;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models;

    public class Userbook
    {   
        
         public string? UserID{get; set;}
         public string? Name{get; set;}
         public string? BookName{get; set;}
         public decimal Bookprice{get; set;}
        

    }