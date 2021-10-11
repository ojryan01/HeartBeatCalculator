using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartBeatCalculator
{
    public class EKGStudyRepository
    {

        public EKGStudy[] InitializeStudy() //we should change study data to a type List because lists are when you have an unknown size
        {

            return new EKGStudy[]
            {
                new EKGStudy(0, "Olivia", 12, {1,2,3,4})
            };
        }
    }
}
