using System;
using System.ComponentModel.DataAnnotations;

namespace aBlog.DataModel.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public DateTime DateCreated { get; set; }

        [Required]
        public string Content { get; set; }

        public Post Post { get; set; }

        [Required]
        public int PostId { get; set; }

    }
}
