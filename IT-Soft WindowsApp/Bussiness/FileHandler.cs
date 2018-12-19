using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace IT_Soft_WindowsApp.Bussiness
{
    public class FileHandler
    {
        private static String filePathPermanent = @"../PermanentFilePath.txt";
        private static String filePathTemporaire = @"../TemporaireFilePath.txt";
        //*********************************************************************************************************************
        public static void WriteToFilePersonnelPermanent(List<PersonnelPermanent> ListeDesPersonnelPermanent)
        {
            using (StreamWriter writer = File.CreateText(filePathPermanent))
            {
                foreach (PersonnelPermanent PermanentA in ListeDesPersonnelPermanent)
                {
                    writer.WriteLine(PermanentA.Id + "|"
                        + PermanentA.Nom + "|"
                        + PermanentA.Prenom + "|"
                        + PermanentA.Nas + "|"
                        + PermanentA.Cellulaire + "|"
                        + PermanentA.Mail + "|"
                        + PermanentA.DateNaissance + "|"
                        + PermanentA.DateEmbauche + "|"
                        + PermanentA.AdressePostal.NumImmeuble + "|"
                        + PermanentA.AdressePostal.NomRue + "|"
                        + PermanentA.AdressePostal.NumAppt + "|"
                        + PermanentA.AdressePostal.CodePostal + "|"
                        + PermanentA.AdressePostal.Ville + "|"
                        + PermanentA.AdressePostal.Province + "|"
                        + PermanentA.Fonction + "|"
                        + PermanentA.SalaireAnnuel + "|"
                       );
                }
            }
        }
        //*********************************************************************************************************************
        public static void WriteToFilePersonnelTemporaire(List<PersonnelTemporaire> ListeDesPersonnelTemporaire)
        {
            using (StreamWriter writer = File.CreateText(filePathTemporaire))
            {
                foreach (PersonnelTemporaire TemporaireA in ListeDesPersonnelTemporaire)
                {
                    writer.WriteLine(TemporaireA.Id + "|"
                        + TemporaireA.Nom + "|"
                        + TemporaireA.Prenom + "|"
                        + TemporaireA.Nas + "|"
                        + TemporaireA.Cellulaire + "|"
                        + TemporaireA.Mail + "|"
                        + TemporaireA.DateNaissance + "|"
                        + TemporaireA.DateEmbauche + "|"
                        + TemporaireA.AdressePostal.NumImmeuble + "|"
                        + TemporaireA.AdressePostal.NomRue + "|"
                        + TemporaireA.AdressePostal.NumAppt + "|"
                        + TemporaireA.AdressePostal.CodePostal + "|"
                        + TemporaireA.AdressePostal.Ville + "|"
                        + TemporaireA.AdressePostal.Province + "|"
                        + TemporaireA.TauxHoraire + "|"
                        + TemporaireA.NombreHeure + "|");
                }
            }
        }

        //*********************************************************************************************************************
        public static List<PersonnelPermanent> ReadFroFilePersonnelPermanent()
        {
            List<PersonnelPermanent> ListeDesPersonnelPermanent = new List<PersonnelPermanent>();
            StreamReader readerPT = new StreamReader(filePathPermanent);
            String Line = null;
            while ((Line = readerPT.ReadLine()) != null)
            {
                PersonnelPermanent PermanentA = new PersonnelPermanent();
                String[] fields = Line.Split('|');
                PermanentA.Id = Int32.Parse(fields[0]);
                PermanentA.Nom = fields[1];
                PermanentA.Prenom = fields[2];
                PermanentA.Nas= fields[3];
                PermanentA.Cellulaire = fields[4];
                PermanentA.Mail = fields[5];
                String[] Datenaissance = fields[6].Split('/');
                PermanentA.DateNaissance = new Date(Int32.Parse(Datenaissance[0]),
                                                        Int32.Parse(Datenaissance[1]),
                                                        Int32.Parse(Datenaissance[2])
                                                      );
                String[] Dateembauche = fields[7].Split('/');
                PermanentA.DateEmbauche = new Date(Int32.Parse(Dateembauche[0]),
                                                        Int32.Parse(Dateembauche[1]),
                                                        Int32.Parse(Dateembauche[2])
                                                      );
                PermanentA.AdressePostal = new Adresse(Convert.ToInt32(fields[8]), fields[9], Convert.ToInt32(fields[10]),
                        fields[11], fields[12], (Listesdesprovinces)Enum.Parse(typeof(Listesdesprovinces), fields[13]));
                PermanentA.Fonction = (FonctionsPermanents)Enum.Parse(typeof(FonctionsPermanents), fields[14]);
                PermanentA.SalaireAnnuel = Convert.ToDouble(fields[15]);
                ListeDesPersonnelPermanent.Add(PermanentA);
            }
            readerPT.Close();



            return ListeDesPersonnelPermanent;
        }

        //*********************************************************************************************************************
        public static List<PersonnelTemporaire> ReadFromListeDesPersonnelsTemporaires()
        {
            List<PersonnelTemporaire> ListeDesPersonnelTemporaire = new List<PersonnelTemporaire>();
            StreamReader readerPT = new StreamReader(filePathTemporaire);
            String Line = null;
            while ((Line = readerPT.ReadLine()) != null)
            {
                PersonnelTemporaire TemporaireA = new PersonnelTemporaire();
                String[] fields = Line.Split('|');
                TemporaireA.Id = Int32.Parse(fields[0]);
                TemporaireA.Nom = fields[1];
                TemporaireA.Prenom = fields[2];
                TemporaireA.Nas = fields[3];
                TemporaireA.Cellulaire = fields[4];
                TemporaireA.Mail = fields[5];
                String[] Datenaissance = fields[6].Split('/');
                TemporaireA.DateNaissance = new Date(Int32.Parse(Datenaissance[0]),
                                                        Int32.Parse(Datenaissance[1]),
                                                        Int32.Parse(Datenaissance[2])
                                                      );
                String[] Dateembauche = fields[7].Split('/');
                TemporaireA.DateEmbauche = new Date(Int32.Parse(Dateembauche[0]),
                                                        Int32.Parse(Dateembauche[1]),
                                                        Int32.Parse(Dateembauche[2])
                                                      );
                TemporaireA.AdressePostal = new Adresse(Convert.ToInt32(fields[8]), fields[9], Convert.ToInt32(fields[10]),
                        fields[11], fields[12], (Listesdesprovinces)Enum.Parse(typeof(Listesdesprovinces), fields[13]));
                TemporaireA.TauxHoraire = Convert.ToDouble(fields[14]);
                TemporaireA.NombreHeure = Convert.ToDouble(fields[15]);
                //listBoxPartTime.Items.Add(aPartTime);
                ListeDesPersonnelTemporaire.Add(TemporaireA);
            }
            readerPT.Close();



            return ListeDesPersonnelTemporaire;
        }

    }
}
