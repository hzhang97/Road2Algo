using System;
using System.Collections.Generic;

namespace Road2
{
    public class CaseNoeud : CaseCouloir
    {
        private List<CaseNoeud> noeudVoisin;

        public CaseNoeud(int lig, int col) : base(lig, col)
        {
            this.Noeud = true;
        }
        public List<CaseNoeud> NoeudVoisin
        {
            get { return this.noeudVoisin; }
            set { this.noeudVoisin = value; }
        }
    }
}
