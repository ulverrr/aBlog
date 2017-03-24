using System;
using System.ComponentModel.DataAnnotations;

namespace aBlog.DataModel.Models
{
    public class Post
    {
        public int Id { get; set; }

        public bool IsCanceled { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime PostedDateTime { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Cancel()
        {
            IsCanceled = true;
        }
    }
}