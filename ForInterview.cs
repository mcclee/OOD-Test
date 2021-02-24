using System;
using System.Collections.Generic;
using System.Text;

namespace OOD
{
    class ForInterview
    {
        Queue<int> Class;
        HashSet<int> a;
        Dictionary<int, string> dict;
        DateTime dat = new DateTime(2012, 1, 17, 9, 30, 0);
        string city = "Chicago";
        int temp = -16;
        
        private static ForInterview LockerManager;
        private ILockerRule Rule { get; set; }
        private List<Locker> lockers;
        private ForInterview()
        {
            string output = String.Format("At {0} in {1}, the temperature was {2} degrees.",
                                      dat, city, temp);
        }
        public static ForInterview getLocker()
        {
            if (LockerManager == null)
            {
                LockerManager = new ForInterview();
            }
            return LockerManager;
        }

        public void SetRule(ILockerRule rule)
        {
            Rule = rule;
        }
        
    }
}
