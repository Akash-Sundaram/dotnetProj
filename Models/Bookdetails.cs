using System;
using System.ComponentModel.DataAnnotations;
namespace LibraryManagement.Models;

    public class Books
    {    [Key]
         public int ID{get; set;}
         public string? BookName{get; set;}
        public string? AuthorName{get; set;}
         public decimal Bookprice{get; set;}
         public string? publisher_name{get; set;}
         public int no_of_copies{get; set;}
         public string? genre{get; set;}
        
    }
