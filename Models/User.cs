using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_for_signup_using_MVC.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }


        [DisplayName("First name")]
        [Required(ErrorMessage ="First name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabetic characters are allowed")]
        public string first_name { get; set; }




        [DisplayName("Last name")]
        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Only alphabetic characters are allowed")]       
        public string last_name { get; set; }




        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime date_of_birth { get; set; }



        
        [DisplayName("Gender")]
        [Required(ErrorMessage = "Please select your gender")]
        public string gender { get; set; }




        [DisplayName("Phone number")]
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        public string phone_number { get; set; }




        [DisplayName("Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string email_address { get; set; }



        [DisplayName("Address")]
        [Required(ErrorMessage = "Address is required")]
        public string address { get; set; }



        [DisplayName("State")]
        [Required(ErrorMessage = "State is required")]
        public string state { get; set; }
        



        [DisplayName("City")]
        [Required(ErrorMessage = "City is required")]
        public string city { get; set; }



        [DisplayName("Username")]
        [Required(ErrorMessage = "Username is required")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter valid email format")]
        public string username { get; set; }



        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", 
        ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, one special character, and be at least 8 characters long.")]
        public string password { get; set; }




        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please confirm your password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }




        [DisplayName("Profile photo")]
        
        public string profile_photo { get; set; }

    }

    
}