using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Welp.Web.Resources;

namespace Welp.Web.Helpers
{
    public static class Tools
    {
        public static string RandomString(IEnumerable<Tuple<string, int>> messages)
        {
            if (messages == null || !messages.Any())
                return null;

            var sortedMessages = messages.OrderByDescending(m => m.Item2).ToArray();

            if (sortedMessages.Length == 1)
                return messages.First().Item1;

            var cumulatedProbability = sortedMessages.Sum(m => m.Item2);

            var randomValue = new Random().Next(cumulatedProbability);
            int sum = 0;

            foreach (var message in sortedMessages)
            {
                sum += message.Item2;
                if (randomValue < sum)
                    return message.Item1;
            }
            return sortedMessages.Last().Item1;
        }

        public static string GetGreeting()
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
