using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IT_Soft_WindowsApp.Bussiness
{
    public class Personnel
    {
        private int id;
        private String nom;
        private String prenom;
        private String nas;
        private String cellulaire;
        private String mail;
        private EnumTypePersonnel typepersonnel;
        private Date dateEmbauche;
        private Date dateNaissance;
        private Adresse adressePostal;
        private int idIncrement = 1;

        public Personnel() { }

        public Personnel(int id, String nom, String prenom, String nas, String cellulaire, String mail, EnumTypePersonnel typepersonnel, Date dateEmbauche, Date dateNaissance,
            int numImmeuble, String nomRue, int numAppt, String codePostal, String ville, Listesdesprovinces province)
        {
            this.id = System.Threading.Interlocked.Increment(ref idIncrement);
            //this.id = Sequences.index++;
            this.nom = nom;
            this.prenom = prenom;
            this.nas = nas;
            this.cellulaire = cellulaire;
            this.mail = mail;
            this.typepersonnel = typepersonnel;
            this.dateEmbauche = dateEmbauche;
            this.dateNaissance = dateNaissance;
            this.AdressePostal.NomRue = nomRue;
            this.AdressePostal.NumImmeuble = numImmeuble;
            this.AdressePostal.NumAppt = numAppt;
            this.AdressePostal.CodePostal = codePostal;
            this.AdressePostal.Ville = ville;
            this.AdressePostal.Province = province;
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Nas
        {
            get
            {
                return nas;
            }

            set
            {
                nas = value;
            }
        }

        public string Cellulaire
        {
            get
            {
                return cellulaire;
            }

            set
            {
                cellulaire = value;
            }
        }

        public string Mail
        {
            get
            {
                return mail;
            }

            set
            {
                mail = value;
            }
        }

        public EnumTypePersonnel Typepersonnel
        {
            get
            {
                return typepersonnel;
            }

            set
            {
                typepersonnel = value;
            }
        }

        public Date DateEmbauche
        {
            get
            {
                return dateEmbauche;
            }

            set
            {
                dateEmbauche = value;
            }
        }

        public Date DateNaissance
        {
            get
            {
                return dateNaissance;
            }

            set
            {
                dateNaissance = value;
            }
        }

        public Adresse AdressePostal
        {
            get
            {
                return adressePostal;
            }

            set
            {
                adressePostal = value;
            }
        }
    }
}
