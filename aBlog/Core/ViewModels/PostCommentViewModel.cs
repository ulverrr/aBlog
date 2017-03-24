using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using aBlog.DataModel.Models;

namespace aBlog.Core.ViewModels
{
    public class PostCommentViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime PostedDateTime { get; set; }
        public string UserName { get; set; }

        public string Heading { get; set; }

        public string Content { get; set; }


        public IEnumerable<Comment> Comment { get; set; }
    }
}
