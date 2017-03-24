using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace aBlog.Test.Extensions
{
    public static class ApiControllerExtensions
    {
        public static void MockCurrentUser(this ApiController controller, string userId, string username)
        {
            var identity = new GenericIdentity(username);
            identity.AddClaim(
                new Claim(ClaimTypes.Name
                            , username));
            identity.AddClaim(
               new Claim(ClaimTypes.NameIdentifier
                            , userId));

            var principal = new GenericPrincipal(identity, null);
            controller.User = principal;
        }
    }
}
