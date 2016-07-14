using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Welp.Web.Models;
using System.Diagnostics;

namespace Welp.Web.Helpers
{

    [HtmlTargetElement(Attributes = nameof(Authorize))]
    public class AuthorizeTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _accessor;
        public AuthorizeTagHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public bool Authorize { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            bool isAuthenticated = _accessor.HttpContext.User.Identities.Any(i => i.IsAuthenticated);

            if ((Authorize && !isAuthenticated) || (!Authorize && isAuthenticated))
                output.SuppressOutput();
        }
    }

    [HtmlTargetElement(Attributes = nameof(Roles))]
    public class RolesTagHelper : TagHelper
    {
        private readonly IHttpContextAccessor _accessor;
        public RolesTagHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Roles { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var roles = Roles.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim());
            if (roles.Any())
            {
                foreach (var role in roles)
                    if (_accessor.HttpContext.User.IsInRole(role))
                        return;
            }
            output.SuppressOutput();
        }
    }
}
