using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OdeToFood.Models;

namespace OdeToFood.Tests.Features
{
    class RestarauntRater
    {
        private Models.Restaraunt data;
       

        public RestarauntRater(Restaraunt data)
        {
            // TODO: Complete member initialization
            this.data = data;
        }
        public RatingResult ComputeRating(int p)
        {
            var result = new RatingResult();
            result.Rating = 4;
            return result;
        }

    }
}
