using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Classe
    {
        public string nomClasse;
        public List<Eleve> eleves;
        public List<String> matieres;
        public readonly int NbElevesMax = 30;
        public readonly int NbMatieresMax = 10;


        public Classe(string nomClasse)
        {
            this.eleves = new List<Eleve>();
            this.matieres = new List<String>();
            this.nomClasse = nomClasse;
        }

        internal void ajouterEleve(string prenom, string nom)
        {
            try
            {
                eleves.Add(new Eleve(prenom, nom));

                if (NbElevesMax <= eleves.Count)
                {
                    Console.WriteLine($"Le nombre d'élève par classe ne peut pas dépasser {NbElevesMax}.");
                }

                if (eleves.Count <= 0)
                {
                    Console.WriteLine("Le nombre d'élève par classe ne peut pas être nul ou négatif.");
                }

            }
            catch
            {
                Console.WriteLine("Veuillez saisir un nombre d'élève valide.");
            }
        }

        internal void ajouterMatiere(string nomMatiere)
        {
            try
            {
                matieres.Add(nomMatiere);

                if (NbMatieresMax <= matieres.Count)
                {
                    Console.WriteLine($"Le nombre de matière par classe ne doit pas dépasser {NbMatieresMax}.");
                }

                if (matieres.Count <= 0)
                {
                    Console.WriteLine("Le nombre de matière ne peut pas être négatif ou nul.");
                }
            }
            catch
            {
                Console.WriteLine("Veuillez saisir un nombre de matière valide.");
            }
        }

        internal float moyenneGeneral()
        {
            float SommeMoyenne = 0;
            for(int i = 0; i < matieres.Count; i += 1)
            {
                SommeMoyenne += moyenneMatiere(i);
            }
            return (float)(Math.Truncate(100 * (SommeMoyenne / matieres.Count)) / 100);
        }

        internal float moyenneMatiere(int LaMatiere)
        {
            float SommeMoyenne = 0;
            for (int i = 0; i < eleves.Count; i += 1)
            {
                SommeMoyenne += eleves[i].MoyEleveMatiere( LaMatiere);
            }
            return (float)(Math.Truncate(100 * (SommeMoyenne/eleves.Count)) / 100);
        }
    }
}
