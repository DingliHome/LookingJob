using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Job.Crawler;
using Job.Crawler.CrawlerAction;

namespace Job.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var zhaoPin = new Job51();
          
                var crawlerJob = zhaoPin.CrawlerJob("无锡", ".net", "1");
             
            Console.Read();
        }
    }
}
