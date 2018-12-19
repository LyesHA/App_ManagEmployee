using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Soft_WindowsApp.Bussiness
{
    public class PersonnelPermanent : Personnel
    {
        private double salaireAnnuel;
        private double salaireDSemaines;
        private FonctionsPermanents fonction;
        // private Adresse adresse;

        public PersonnelPermanent() { }

        public PersonnelPermanent(double salaireAnnuel, double salaireDSemaines, FonctionsPermanents fonction)
        {
            this.salaireAnnuel = salaireAnnuel;
            this.salaireDSemaines = salaireDSemaines;
            this.fonction = fonction;
        }

        public double SalaireAnnuel
        {
            get
            {
                return salaireAnnuel;
            }

            set
            {
                salaireAnnuel = value;
            }
        }

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

        public FonctionsPermanents Fonction
        {
            get
            {
                return fonction;
            }

            set
            {
                fonction = value;
            }
        }

        public PersonnelPermanent(int id, String nom, String prenom, String nas, String cellulaire, String mail,
        EnumTypePersonnel typepersonnel, Date dateEmbauche, Date dateNaissance,
        int numImmeuble, String nomRue, int numAppt, String codePostal, String ville, Listesdesprovinces province, FonctionsPermanents fonction, double salaireAnnuel)
            : base(id, nom, prenom, nas, cellulaire, mail, typepersonnel, dateEmbauche, dateNaissance,
                  numImmeuble, nomRue, numAppt, codePostal, ville, province)
        {
            this.fonction = fonction;
            this.salaireAnnuel = salaireAnnuel;
        }

        public double Calculpayment()
        {
            double total = 0;
            total = salaireAnnuel / 52;
            salaireDSemaines = total * 2;
            return salaireDSemaines;
        }

        override
            public String ToString()
        {
            String state = "Type personnel : Permanent "
                + "\nID : " + base.Id
                + "\n Nom : " + base.Nom
                + "\n Prenom : " + base.Prenom
                + "\n Numéro d'assurance social : " + base.Nas
                + "\n Numéro téléphone : " + base.Cellulaire
                + "\n Adresse e-mail : " + base.Mail
                + "\n Date de naissance :" + base.DateNaissance
                + "\n Date d'embauche : " + base.DateEmbauche
                + "\n Adresse : " + base.AdressePostal.NumImmeuble + " " + base.AdressePostal.NomRue + " Apt " + base.AdressePostal.NumAppt
                + ", " + base.AdressePostal.Ville + ", " + base.AdressePostal.Province + ", " + base.AdressePostal.CodePostal+ " | "
                + "\n Fonction : " + this.fonction
                + "\n Salaire : " + this.salaireAnnuel
                + "\n Salaire bimensuel : " + (this.salaireAnnuel / 52 * 2).ToString("#.##");
            return state;
        }
    }
}
