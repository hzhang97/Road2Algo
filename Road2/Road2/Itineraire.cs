using System;
using System.Collections.Generic;

namespace Road2
{
    public class Itineraire
    {
        List<CaseCouloir> iti;
        int distance;

        public Itineraire()
        {
            iti = new List<CaseCouloir>();
            distance = 0;
        }

        public int Distance
        {
            get { return this.distance; }
        }

        public void AddCase(CaseCouloir caseC)
        {
            iti.Add(caseC);
            distance++;
        }
    }
}
