using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BISolutions.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class MainController : ControllerBase
    {
        [HttpPost("firstSolution")]
        public float FirstSolution(float[] array)
        {
            return Math.Abs(array
                .Where(x => x % 2 != 0)
                .Select((item, index) => new { item, index })
                .Where(x => x.index % 2 != 0).Sum(x => x.item));
        }

        [HttpPost("secondSolution")]
        public LinkedList<int> SecondSolution(SecondSolutionLists lists)
        {
            if (lists.First == null || lists.Second == null || !lists.First.Any() || !lists.Second.Any())
            {
                return null;
            }
            else
            {
                LinkedList<int> result = new LinkedList<int>();
                int maxCount = lists.First.Count() > lists.Second.Count() ? lists.First.Count() : lists.Second.Count();
                int carry = 0, temp = 0;
                for (int i = 0; i < maxCount; ++i)
                {
                    temp = lists.First.ElementAtOrDefault(i) + lists.Second.ElementAtOrDefault(i);
                    result.AddFirst((temp + carry) % 10);
                    carry = (temp + carry) / 10;
                }
                return result;
            }
            
        }

        [HttpGet("thirdSolution")]
        public bool ThirdSolution(string word)
        {
            if(string.IsNullOrEmpty(word))
                return false;

            return word.SequenceEqual(word.Reverse());
        }
    }
}
