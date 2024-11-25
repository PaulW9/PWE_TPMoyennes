using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    internal class Eleve
    {
        public string prenom;
        public string nom;
        public List<Note> notes;
        public readonly int nbNotesmax = 200;

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.notes = new List<Note>();
        }

        internal void ajouterNote(Note note)
        {
            try
            {
                notes.Add(note);
                {
                    if (nbNotesmax <= notes.Count)
                    {
                        Console.WriteLine($"Le nombre de note d'un élève ne peut pas être supérieur à {nbNotesmax}.");
                    }

                    if (notes.Count <= 0)
                    {
                        Console.WriteLine("Le nombre de note d'un élève ne peut pas être nul ou négatif.");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Veuillez saisir un nombre de note valide.");
            }
        }

        internal float moyenneGeneral()
        {
            int CptNotes = 0;
            float SommeNotes = 0;
            float MoyEleveMatiere;
            for (int i = 0; i < 10; i += 1)
            {
                try
                {
                    MoyEleveMatiere = this.MoyEleveMatiere(i);

                    if (MoyEleveMatiere != 0 && MoyEleveMatiere >= 3)
                    {
                        SommeNotes += MoyEleveMatiere;
                        CptNotes += 1;
                    }      
                }
                catch
                {
                    Console.WriteLine("Veuillez saisir une moyenne correcte pour l'élève en question.");
                }
            }
            return (float)(Math.Truncate(100 * (SommeNotes / CptNotes)) / 100);
        }

        internal float MoyEleveMatiere(int LaMatiere)
        {
            float SommeNotes = 0;
            int CptNotes = 0;
            for (int i = 0; i < notes.Count; i += 1)
            {
                if (notes[i].matiere == LaMatiere)
                {
                    SommeNotes += notes[i].note;
                    CptNotes += 1;
                }
            }
            if (CptNotes == 0)
                return 0;
            else 
                return (float)(Math.Truncate(100 * (SommeNotes/CptNotes)) / 100);
        }
    }
}
