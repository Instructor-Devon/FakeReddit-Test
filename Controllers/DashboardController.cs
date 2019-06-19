using System.Collections.Generic;
using System.Linq;
using EFFunzies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFFunzies.Controllers
{
    [Route("dashboard")]
    public class DashboardController : UserAccessController
    {
        private MyContext dbContext;
        public DashboardController(MyContext context)
        {
            dbContext = context;
        }
        // localhost:5000/dashboard
        [HttpGet("")]
        public ViewResult Index()
        {
            List<Message>messages = dbContext.Messages
                .Include(m => m.Creator)
                .Include(m => m.VotesRecieved).ToList();

            return View(messages);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            ViewBag.UserId = SessionUser;
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult Create(Message newMessage)
        {
            if(ModelState.IsValid)
            {
                // construct our message object
                // newMessage.UserId = (int)SessionUser;

                dbContext.Messages.Add(newMessage);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.UserId = SessionUser;
            return View("New");
        }

        [HttpGet("vote/{isUpvote}/{messageId}")]
        public IActionResult Vote(bool isUpvote, int messageId)
        {
            // make a vote!
            Vote vote = new Vote();
            // we need a user id!
            vote.UserId = (int)SessionUser;
            // we need a message id!
            vote.MessageId = messageId;
            // we need to know if down/upvote
            vote.IsUpvote = isUpvote;

            dbContext.Votes.Add(vote);
            dbContext.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}