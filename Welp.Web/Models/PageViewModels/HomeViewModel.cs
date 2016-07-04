using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Welp.Web.Data;
using Welp.Web.Helpers;

namespace Welp.Web.Models.PageViewModels
{
    public class HomeViewModel
    {
        private ApplicationDbContext _context;

        public HomeViewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string TagLine
        {
            get
            {
                return Tools.RandomString(_context.TagLines.Select(tl => Tuple.Create<string, int>(tl.Text, tl.Probability)));
            }
        }

        public string Greeting
        {
            get
            {
                return Tools.GetGreeting();
            }
        }


    }
}
