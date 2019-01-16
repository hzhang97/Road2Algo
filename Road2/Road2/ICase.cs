using System;

namespace Road2
{
    public interface ICase
    {
        // coordonnées du point
        int Lig { get; set; }
        int Col { get; set; }
        // nature de la case
        Boolean Couloir { get; set; }
        Boolean Noeud { get; set; }
        Boolean Escalier { get; set; }
        Boolean PtCle { get; set; }
    }
}
