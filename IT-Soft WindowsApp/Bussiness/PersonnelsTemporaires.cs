using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Soft_WindowsApp.Bussiness
{
    public class PersonnelTemporaire : Personnel
    {
        private double tauxHoraire;
        private double nombreHeure;
        private double salaireDSemaines;
        // private Adresse adresse;

        public PersonnelTemporaire() { }

        public double SalaireDSemaines
        {
            get
            {
                return salaireDSemaines;
            }

            set
            {
                salaireDSemaines = value;
            }
        }

        public double TauxHoraire
        {
            get
            {
                return tauxHoraire;
            }

            set
            {
                tauxHoraire = value;
            }
        }

        public double NombreHeure
        {
            get
            {
                return nombreHeure;
            }

            set
            {
                nombreHeure = value;
            }
        }

        public PersonnelTemporaire(int id, String nom, String prenom, String nas, String cellulaire, String mail,
        EnumTypePersonnel typepersonnel, Date dateEmbauche, Date dateNaissance,
        int numImmeuble, String nomRue, int numAppt, String codePostal, String ville, Listesdesprovinces province, double tauxHoraire, double nombreHeure)
            : base(id, nom, prenom, nas, cellulaire, mail, typepersonnel, dateEmbauche, dateNaissance,
                  numImmeuble, nomRue, numAppt, codePostal, ville, province)
        {
            this.TauxHoraire = tauxHoraire;
            this.NombreHeure = nombreHeure;
        }

        public double Calculpayment()
        {
            double total = 0;
            total = tauxHoraire * nombreHeure;
            salaireDSemaines = total * 2;
            return salaireDSemaines;
        }

        override
            public String ToString()
        {
            String state = "Type personnel : Temporaire "
                + "\n ID : " + base.Id
                + "\n Nom : " + base.Nom
                + "\n Prenom : " + base.Prenom
                + "\n Numéro d'assurance social : " + base.Nas
                + "\n Tel : " + base.Cellulaire
                + "\n Adresse e-mail : " + base.Mail
                + "\n Date de naissance : " + base.DateNaissance
                + "\n Date d'embauche : " + base.DateEmbauche
                + "\n Adresse : " + base.AdressePostal.NumImmeuble +" "+ base.AdressePostal.NomRue + " Apt " + base.AdressePostal.NumAppt
                + ", " + base.AdressePostal.Ville +", "+base.AdressePostal.Province+", "+ base.AdressePostal.CodePostal+" | "
                + "\n Taux Horaire : " + this.tauxHoraire
                + "\n Nombre d'heure : " + this.nombreHeure
                + "\n Salaire bimensuel : " + (this.tauxHoraire * this.nombreHeure * 2).ToString("#.##");       
            return state;
        }
    }
}
