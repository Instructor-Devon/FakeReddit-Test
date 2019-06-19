using System.ComponentModel.DataAnnotations;

namespace EFFunzies.Models
{
    public class Vote
    {
        [Key]
        public int VoteId {get;set;}
        public int UserId {get;set;}
        public int MessageId {get;set;}
        public bool IsUpvote {get;set;}
        // Navigation Props
        public Message VotedMessage {get;set;}
        public User Voter {get;set;}
    }
}