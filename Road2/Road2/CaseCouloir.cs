using System;
using System.Collections.Generic;

namespace Road2
{
    public class CaseCouloir : Case
    {
        List<CaseNoeud> noeudVoisin;

        public CaseCouloir(int lig, int col) : base (lig, col)
        {
            this.Couloir = true;
        }

        public List<CaseNoeud> NoeudVoisin
        {
            get { return this.noeudVoisin; }
            set { this.noeudVoisin = value; }
        }
    }
}
