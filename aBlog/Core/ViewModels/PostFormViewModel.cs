using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;
using aBlog.Controllers;

namespace aBlog.Core.ViewModels
{
    public class PostFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string UserId { get; set; }

        public DateTime? PostedDateTime { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Antlr.Runtime.Misc.Func<PostsController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Antlr.Runtime.Misc.Func<PostsController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;

                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}
