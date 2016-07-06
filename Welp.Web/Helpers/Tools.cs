using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Welp.Web.Data;
using Welp.Web.Resources;

namespace Welp.Web.Helpers
{

    public interface IToolsService
    {
        string RandomTagLine { get; }
        string Greeting { get; }
    }

    public class ToolsService : IToolsService
    {
        private ApplicationDbContext _context;

        public ToolsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public string RandomTagLine
        {
            get
            {
                if (!_context.TagLines.Any())
                    return null;

                var cumulatedProbability = _context.TagLines.Sum(t => t.Probability);
                var randomValue = new Random().Next(cumulatedProbability);

                int sum = 0;
                foreach (var message in _context.TagLines.OrderByDescending(t => t.Probability))
                {
                    sum += message.Probability;
                    if (randomValue < sum)
                        return message.Text;
                }

                return _context.TagLines.FirstOrDefault().Text;

            }
        }

        public string Greeting
        {
            get
            {
                var hour = DateTime.Now.Hour;

                if (hour < 12)
                    return Strings.GreetingGoodMorning;
                else if (hour < 17)
                    return Strings.GreetingGoodAfternoon;
                else
                    return Strings.GreetingGoodEvening;
            }
        }
    }
}
