using System;
namespace Road2
{
    public class Case : ICase
    {
        //coordonnées 
        protected int lig;
        protected int col;
        protected Boolean couloir, ptCle, escalier, noeud;

        public Case()
        {
            lig = 0;
            col = 0;
            couloir = false;
            ptCle = false;
            escalier = false;
            noeud = false;
        }

        public Case(int lig, int col)
        {
            this.lig = lig;
            this.col = col;
            couloir = false;
            ptCle = false;
            escalier = false;
            noeud = false;
        }

        // set pas nécessaire comme l'utilisateur n'est pas supposé le modifier
        public int Lig
        {
            get { return this.lig; }
            set { this.lig = value; }
        }
        public int Col
        {
            get { return this.col; }
            set { this.col = value; }
        }

        public Boolean Couloir
        {
            get { return this.couloir; }
            set { this.couloir = value; }
        }
        public Boolean Noeud
        {
            get { return this.noeud; }
            set { this.noeud = value; }
        }
        public Boolean Escalier
        {
            get { return this.escalier; }
            set { this.escalier = value; }
        }
        public Boolean PtCle
        {
            get { return this.ptCle; }
            set { this.ptCle = value; }
        }

    }
}