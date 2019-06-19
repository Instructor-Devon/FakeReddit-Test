using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EFFunzies.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}
        public string Content {get;set;}
        public int UserId {get;set;}
        // Navigation Property
        public User Creator {get;set;}
        public List<Vote> VotesRecieved {get;set;}

        // we can do cool stuff here!
        public int? KarmaScore
        {
            get
            {
                if (this.VotesRecieved == null) return null;
                return this.VotesRecieved.Count(v => v.IsUpvote) - this.VotesRecieved.Count(v => !v.IsUpvote);
            }
        }
    }
}