using System;
using System.Collections.Generic;

namespace Road2
{
    public class Plan
    {
        // grille contenant la liste des cases
        List<ICase> grille;
        List<CaseNoeud> listeNoeud;
        List<CaseCouloir> listeCouloir;
        List<CaseEscalier> listeEsc;
        List<PtCle> listeCle;
        int nbCol;

        public Plan(List<ICase> grille, int nbCol)
        {
            this.grille = grille;
            this.nbCol = nbCol;
        }

        public Itineraire Chemin(PtCle depart, PtCle arrivee)
        {
            // contient la liste de tous les itinéraires possible
            List<Itineraire> listeIti = new List<Itineraire>();
            Itineraire iti = new Itineraire();

            // lorsque que les 2 points ne sont pas dans le même couloir 
            if (CompareList(depart.PtCouloir.NoeudVoisin, arrivee.PtCouloir.NoeudVoisin) == false)
            {
                List<ListNoeud> listeDeListe;
                listeDeListe = RechercheItiNoeud(depart, arrivee);
                for (int i = 0; i <listeDeListe.Count; i++)
                {
                    listeIti.Add(GenerationIti(listeDeListe[i], depart, arrivee));
                }
            }
            else
            {
                List<CaseCouloir> listeCase = GenerationListCouloir(depart.PtCouloir, arrivee.PtCouloir);
                listeCase.Add(arrivee.PtCouloir);
                for (int j = 0; j < listeCase.Count; j++)
                {
                    iti.AddCase(listeCase[j]);
                }
                listeIti.Add(iti);
            }

            iti = ItineraireFinal(listeIti);
            return iti;
        }

        // méthode qui va chercher tout les itinéraires possibles pour les noeuds 
        public List<ListNoeud> RechercheItiNoeud(PtCle depart, PtCle arrivee)
        {
            // contient liste de tous les itinéraires possibles
            List<ListNoeud> listeDeListe = new List<ListNoeud>();

            List<CaseNoeud> listeCaseNoeudDep = depart.PtCouloir.NoeudVoisin;
            List<CaseNoeud> listeCaseNoeudArr = arrivee.PtCouloir.NoeudVoisin;

            // taille de la liste de noeud de la case départ
            int tailleListeNoeudDepart = listeCaseNoeudDep.Count;
            // nombre d'éléments dans la liste des listes
            int m = listeDeListe.Count;

            // création de liste selon le nombre de noeuds de départ
            // ajout de ces listes dans la liste des listes
            for (int i = 0; i < tailleListeNoeudDepart; i++)
            {
                ListNoeud liste = new ListNoeud();
                liste.AddNoeud(listeCaseNoeudDep[i]);
                listeDeListe.Add(liste);
                m = listeDeListe.Count;
            }

            // boolean vérifiant sur les derniers éléments sont ceux de la destination
            Boolean check;
            // acquisition des différents itinéraires de noeuds possibles
            do
            {
                // liste de transition
                List<ListNoeud> listeTran = new List<ListNoeud>();

                for (int i = 0; i < listeDeListe.Count; i++)
                {
                    // liste qui contient les caseNoeuds de 1 itinéraire
                    ListNoeud liste = listeDeListe[i];

                    // vérifie si la liste est terminé
                    if (liste.StatutFinis == false)
                    {
                        // index du dernier élément de la liste en cours
                        int indexDernierEle = liste.Liste.Count - 1;
                        CaseNoeud dernierNoeud = liste.Liste[indexDernierEle];

                        // prends en liste les voisins du dernier point
                        List<CaseNoeud> voisins = dernierNoeud.NoeudVoisin;

                        // boucle qui va considérer chaque voisin et va les ajouter à la liste s'il correspond aux critères
                        // critère: différents des case départs et des caseNoeuds déjà contenus dans la liste
                        for (int j = 0; j < voisins.Count; j++)
                        {
                            // duplication de la liste en cours pour pouvoir ajouter les nouveaux itinéraires possibles
                            ListNoeud copie = liste;

                            // caseNoeud voisin
                            CaseNoeud voisin = voisins[j];

                            // si la CaseNoeud n'est pas dans la liste et parmi les CaseNoeud de départ
                            if ((copie.Liste.Contains(voisin) == false) && (listeCaseNoeudDep.Contains(voisin) == false))
                            {
                                // ajout de l'élément dans la liste duplicata
                                copie.AddNoeud(voisin);

                                // si la dernière caseNoeud l'un des points d'arrivées alors on considère que la liste est teminée
                                if (listeCaseNoeudArr.Contains(voisin) == true)
                                {
                                    copie.StatutFinis = true;
                                }

                                // ajout de la nouvelle liste créée
                                listeTran.Add(copie);
                            }
                        }
                    }
                    else
                    {
                        // ajout de la liste déjà terminé
                        listeTran.Add(liste);
                    }
                }
                // liste des listes est mise à jour
                listeDeListe = listeTran;

                // par défault tous les itinéraires sont terminés
                check = true;

                // si 1 seul élément n'est pas fini alors la boucle continue
                for (int l = 0; l< listeDeListe.Count; l++)
                {
                    if (listeDeListe[l].StatutFinis == false)
                    {
                        check = false;
                    }
                }

            } while (check == false);

            // méthode qui verifie si tous les ititnéraires possibles arrivent à destination
            return listeDeListe;
        }

        // méthode qui compare 2 list pour voir si elles sont contiennent les mêmes éléments
        public Boolean CompareList(List<CaseNoeud> c1, List<CaseNoeud> c2)
        {
            Boolean equal = false;
            if (c1.Count == c2.Count)
            {
                List<CaseNoeud> list = new List<CaseNoeud>();
                //c2.Where(x => c1.Contains(x));
                for (int i = 0; i < c1.Count; i++)
                {
                    if (c1.Contains(c2[i]) == true)
                    {
                        list.Add(c2[i]);
                    }
                }
                if (list.Count == c2.Count)
                {
                    equal = true;
                }
            }

            return equal;
        }

        // méthode qui génère un itinéraire possible avec en entrée une liste de CaseNoeud
        public Itineraire GenerationIti(ListNoeud listeNoeud, PtCle depart, PtCle arrivee)
        {
            Itineraire iti = new Itineraire();
            List<CaseCouloir> listeCaseCouloir = new List<CaseCouloir>();

            // liste contenant la case départ jusqu'au premier noeud
            listeCaseCouloir = GenerationListCouloir(depart.PtCouloir, listeNoeud.Liste[0]);

            for (int i =0; i < listeCaseCouloir.Count; i++)
            {
                iti.AddCase(listeCaseCouloir[i]);
            }

            // boucle pour rajouter toutes les CaseCouloir qui sont entre les CaseNoeud
            for (int j =1; j < listeNoeud.Liste.Count; j++)
            {
                listeCaseCouloir = GenerationListCouloir(listeNoeud.Liste[j - 1], listeNoeud.Liste[j]);

                for (int k = 0; k < listeCaseCouloir.Count; k++)
                {
                    iti.AddCase(listeCaseCouloir[k]);
                }
            }

            // ajout des CaseCouloir entre le dernier noeud et le point d'arrivée
            listeCaseCouloir = GenerationListCouloir(listeNoeud.Liste[listeNoeud.Liste.Count - 1], arrivee.PtCouloir);
            for (int l = 0; l < listeCaseCouloir.Count; l++)
            {
                iti.AddCase(listeCaseCouloir[l]);
            }

            // ajout du point d'arrivée
            iti.AddCase(arrivee.PtCouloir);

            return iti;
        }

        // méthode qui retourne liste de case sauf le dernier élément 
        public List<CaseCouloir> GenerationListCouloir(CaseCouloir depart, CaseCouloir arrivee)
        {
            List<CaseCouloir> listCaseCouloir = new List<CaseCouloir>();
            int index;

            if (depart.Col == arrivee.Col)
            {
                int col = depart.Col;
                if ((arrivee.Lig - depart.Lig) > 0)
                {
                    for (int lig = depart.Lig; lig < arrivee.Lig; lig++)
                    {
                        index = (lig - 1) * nbCol + (col-1);
                        //Case c = ;
                        listCaseCouloir.Add(grille[index] as CaseCouloir);
                    }
                }
                else
                {
                    for (int lig = depart.Lig; arrivee.Lig < lig; lig--)
                    {
                        index = (lig - 1) * nbCol + (col - 1);
                        listCaseCouloir.Add(grille[index] as CaseCouloir);
                    }
                }

            }

            else
            {
                int lig = depart.Lig;
                if ((arrivee.Col - depart.Col)> 0)
                {
                    for (int col = depart.Col; col < arrivee.Col; col++)
                    {
                        index = (lig - 1) * nbCol + (col - 1);
                        listCaseCouloir.Add(grille[index] as CaseCouloir);
                    }
                }
                else
                {
                    for (int col = depart.Col; arrivee.Col < col; col--)
                    {
                        index = (lig - 1) * nbCol + (col - 1);
                        listCaseCouloir.Add(grille[index] as CaseCouloir);
                    }
                }
            }
            return listCaseCouloir;
        }

        // méthode qui retourne l'itinéraire le plus court
        public Itineraire ItineraireFinal(List<Itineraire> liste)
        {
            int n = 0;
            if (liste.Count > 1)
            {
                for (int i = 1; i < liste.Count; i++)
                {
                    if (liste[i].Distance < liste[n].Distance)
                    {
                        n = i;
                    }
                }
            }
            return liste[n];
        }
    }

}
