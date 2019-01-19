using System;
namespace Road2
{
    public class CaseEscalier : Case
    {
        CaseCouloir ptCouloir;

        public CaseEscalier(int lig, int col) : base(lig, col)
        {
            this.Escalier = true;
        }

        public CaseCouloir PtCouloir
        {
            get { return this.ptCouloir; }
            set { this.ptCouloir = value; }
        }
    }
}
