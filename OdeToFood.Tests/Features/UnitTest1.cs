using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Models;
using System.Collections.Generic;


//Comments about the test
//deacribe what test would solve


namespace OdeToFood.Tests.Features
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = new Restaraunt();
            data.Reviews = new List<RestarauntReview>();
            data.Reviews.Add(new RestarauntReview() { Rating = 4 });


            var rater = new RestarauntRater(data);
            var result = rater.ComputeRating(10);

            Assert.AreEqual(4, result.Rating);
        }
    }
}
