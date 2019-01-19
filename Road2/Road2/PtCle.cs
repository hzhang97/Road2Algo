using System;
using System.Collections.Generic;

namespace Road2
{
    public class PtCle : Case
    {
        CaseCouloir ptCouloir;//= new CaseCouloir()

        public PtCle(int lig, int col) : base(lig, col)
        {
            this.PtCle = true;
        }

        public CaseCouloir PtCouloir
        {
            get { return this.ptCouloir; }
            set { this.ptCouloir = value; }
        }
    }
}
