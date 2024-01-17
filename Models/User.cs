using System;
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations; 

namespace LibraryManagement.Models;

    public class User
    {
        
         public string? Name{get; set;}
        public string? UserID{get; set;}
        
        [RegularExpression(@"^.(?=.{8,})(?=.\d)(?=.[a-z])(?=.[A-Z])(?=.[@#$%^&+=]).$", ErrorMessage = "It must contains one uppercase, lowercase,special character and length must be greater than 8 characters ")]
         public string? Password{get; set;}
        public string? Email{get;set;}
    }
