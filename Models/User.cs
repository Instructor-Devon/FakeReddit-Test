using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFFunzies.Models
{
    public class LogRegModel
    {
        public User NewUzser {get;set;}
        public LoginUser LogUser {get;set;}
    }
    public class User
    {
        [Key]
        public int UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        [EmailAddress]
        public string Email {get;set;}
        [MinLength(8, ErrorMessage="Password must be at least 8 characters")]
        public string Password {get;set;}
        [NotMapped]
        [Compare("Password")]
        public string Confirm {get;set;}
        // Navigation Property
        public List<Message> MessagesCreated {get;set;}
        public List<Vote> VotesIssued {get;set;}
    }
    public class LoginUser
    {
        [EmailAddress]
        public string LogEmail {get;set;}
        public string LogPassword {get;set;}
    }
}