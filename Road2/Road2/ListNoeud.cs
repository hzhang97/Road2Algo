using System;
using System.Collections.Generic;

namespace Road2
{
    public class ListNoeud
    {
        List<CaseNoeud> liste;
        Boolean statusFinis;

        public ListNoeud()
        {
            liste = new List<CaseNoeud>();
            statusFinis = false;
        }

        public List<CaseNoeud> Liste
        {
            get { return this.liste; }
        }
        public Boolean StatutFinis
        {
            get { return this.statusFinis; }
            set { this.statusFinis = value; }
        }

        public void AddNoeud(CaseNoeud noeud)
        {
            liste.Add(noeud);
        }

        //public static explicit operator ListNoeud(void v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
