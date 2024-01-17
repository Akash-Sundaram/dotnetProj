using System;
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;  


namespace LibraryManagement.Models;

    public class Login
    {
        
        public string? Password{get; set;}
        public string? Email{get;set;}
    }
