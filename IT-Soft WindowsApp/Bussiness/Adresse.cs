using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Soft_WindowsApp.Bussiness
{
    public class Adresse
    {
        private int numImmeuble;
        private String nomRue;
        private int numAppt;
        private String codePostal;
        private String ville;
        private Listesdesprovinces province;

        public int NumImmeuble
        {
            get
            {
                return numImmeuble;
            }

            set
            {
                numImmeuble = value;
            }
        }

        public string NomRue
        {
            get
            {
                return nomRue;
            }

            set
            {
                nomRue = value;
            }
        }

        public int NumAppt
        {
            get
            {
                return numAppt;
            }

            set
            {
                numAppt = value;
            }
        }

        public String CodePostal
        {
            get
            {
                return codePostal;
            }

            set
            {
                codePostal = value;
            }
        }

        public string Ville
        {
            get
            {
                return ville;
            }

            set
            {
                ville = value;
            }
        }

        public Listesdesprovinces Province
        {
            get
            {
                return province;
            }

            set
            {
                province = value;
            }
        }

        public Adresse(int numImmeuble, String nomRue, int numAppt, String codePostal, String ville, Listesdesprovinces province)
        {
            this.NumImmeuble = numImmeuble;
            this.NomRue = nomRue;
            this.NumAppt = numAppt;
            this.CodePostal = codePostal;
            this.ville = ville;
            this.Province = province;
        }

        public Adresse() { }
    }
}
