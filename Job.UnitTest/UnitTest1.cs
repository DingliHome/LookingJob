using System;
using Job.Crawler.CrawlerAction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Job.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var zhaoPin = new Job51();

            var crawlerJob = zhaoPin.CrawlerJob("无锡", ".net", "1");

            Assert.AreNotEqual(crawlerJob.Count, 0);

        }

        [TestMethod]
        public void TestForException()
        {
            
        }

    }
}
