using System;
namespace Road2
{
    public class CaseCouloir : Case
    {
        public CaseCouloir(int lig, int col) : base (lig, col)
        {
            this.Couloir = true;
        }
    }
}
