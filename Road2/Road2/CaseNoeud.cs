using System;
namespace Road2
{
    public class CaseNoeud : CaseCouloir
    {
        public CaseNoeud(int lig, int col) : base(lig, col)
        {
            this.Noeud = true;
        }
    }
}
