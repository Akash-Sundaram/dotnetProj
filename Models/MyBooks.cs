using System;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models;

    public class MyBook
    {    [Key]
         public int BookID{get; set;}
         public int UserID{get; set;}
         public string? BookName{get; set;}
        
        
    }