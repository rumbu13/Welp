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

    [HtmlTargetElement(Attributes = nameof(DisplayIf))]
    public class DisplayIfTagHelper : TagHelper
    {
        public bool DisplayIf { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (!DisplayIf)
                output.SuppressOutput();
        }
    }

    [HtmlTargetElement(Attributes = nameof(HideIf))]
    public class HideIfTagHelper : TagHelper
    {
        public bool HideIf { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            if (HideIf)
                output.SuppressOutput();
        }
    }


}
