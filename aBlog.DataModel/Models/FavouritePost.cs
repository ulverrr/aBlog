using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Threading.Tasks;

namespace aBlog.DataModel.Models
{
    public class FavouritePost
    {
        public Post Post { get; set; }
        public ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 1)]
        public int PostId { get; set; }

        [Key]
        [Column(Order = 2)]
        public string UserId { get; set; }
    }
}
