using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public List<ICase> CreationGrille(List<(int lig, int col, string type)> list)
        {
            List<ICase> grille = new List<ICase>();

            foreach ((int lig, int col, string type) caseGrille in list)
            {
                switch (caseGrille.type)
                {
                    case "couloir":
                        grille.Add(new CaseCouloir(caseGrille.lig, caseGrille.col));
                        break;
                    case "escalier":
                        grille.Add(new CaseEscalier(caseGrille.lig, caseGrille.col));
                        break;
                    case "cle":
                        grille.Add(new PtCle(caseGrille.lig, caseGrille.col));
                        break;
                    default:
                        grille.Add(new CaseNoeud(caseGrille.lig, caseGrille.col));
                        break;
                }
            }
            return grille;
        }
    }
}
