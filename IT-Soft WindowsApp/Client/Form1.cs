using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IT_Soft_WindowsApp.Bussiness;
using System.Diagnostics;

namespace IT_Soft_WindowsApp
{
    public partial class Form1 : Form
    {
        List<PersonnelPermanent> ListeDesPersonnelPermanent = new List<PersonnelPermanent>();
        List<PersonnelTemporaire> ListeDesPersonnelTemporaire = new List<PersonnelTemporaire>();
        int recordNumbPermanent;
        int recordNumbTemporaire;
        int indexPermanent = 0;
        int indexTemporaire = 0;
        public bool IsEmailValid(string mail)
        {

            return (mail.Contains("@"));
        }

        public bool IsTelOrNasValide(string phone, int n)
        {
            return (phone.Length == n);
        }


        public bool IsCodePostalValid(string cPostal)
        {
            char[] tabcp = cPostal.ToCharArray(0, 6);
            bool[] zipcode = new bool[6];
            for (int i = 0; i < 6; i++)
                zipcode[i] = Char.IsNumber(tabcp[i]);
            if (!(zipcode[0] || zipcode[2] || zipcode[4]) && (zipcode[1] && zipcode[3] && zipcode[5]))
                return true;
            else
                return false;
        }

        //public bool Iscpvalid(string cpostal)
        //{
        //    cpostal.
        //}

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            PersonnelPermanent PermanentA = new PersonnelPermanent();
            PersonnelTemporaire TemporaireA = new PersonnelTemporaire();

            //Ajouter les infos a l'objet PermanentA
            if (comboBoxTypePersonnel.Text == "Permanent")
            {
                PermanentA.Id = Convert.ToInt32(textBoxID.Text);
                PermanentA.Nom = textBoxname.Text;
                PermanentA.Prenom = textBoxprenom.Text;
                if (!IsTelOrNasValide(textBoxnas.Text, 9))
                {
                    MessageBox.Show("Le NAS non valide ! \n Veuillez entrer un NAS valide!");
                }
                else
                {
                    PermanentA.Nas = textBoxnas.Text;
                    if (!IsTelOrNasValide(textBoxTel.Text, 10))
                    {
                        MessageBox.Show("Le téléphone non valide !");
                    }
                    else
                    {
                        PermanentA.Cellulaire = textBoxTel.Text;
                        if (!IsEmailValid(textBoxMail.Text))
                        {
                            MessageBox.Show(" Adresse e-mail non valide!\n Veuillez entrer une adresse valide !!");
                        }
                        else
                        {
                            PermanentA.Mail = textBoxMail.Text;
                            PermanentA.DateNaissance = new Date(dateTimepdatenaissance.Value.Day, dateTimepdatenaissance.Value.Year, dateTimepdatenaissance.Value.Month);
                            PermanentA.DateEmbauche = new Date(dateTimePickDateEmbauche.Value.Day, dateTimePickDateEmbauche.Value.Year, dateTimePickDateEmbauche.Value.Month);
                            PermanentA.Fonction = (FonctionsPermanents)comboBoxEmpFonction.SelectedIndex;
                            PermanentA.SalaireAnnuel = Convert.ToDouble(textBoxSalaireAnnuel.Text);
                            // ******** Entrer l'adresse:
                            if (textBoxCodePostal.TextLength == 6)
                            {
                                if (!IsCodePostalValid(textBoxCodePostal.Text))
                                {
                                    MessageBox.Show("Le code postal n'est pas valide!");
                                }
                                else
                                {

                                    MessageBox.Show("Code postal valide");
                                    PermanentA.AdressePostal = new Adresse(Convert.ToInt32(textBoxNumImmeuble.Text), textBoxAddresserue.Text
                                    , Convert.ToInt32(textBoxNumAppt.Text), textBoxCodePostal.Text, textBoxVille.Text,
                                    (Listesdesprovinces)comboBoxProvince.SelectedIndex);
                                    this.ListeDesPersonnelPermanent.Add(PermanentA);
                                    MessageBox.Show("Employé ajouté!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez entrer le code postal sous le format suivant : L0L0L0 !!");
                            }
                        }
                    }
                }
            }
            //****************************************************************************************************************************
            //Ajouter les infos a l'objet TemporaireA

            else if (comboBoxTypePersonnel.Text == "Temporaire")
            {
                TemporaireA.Id = Convert.ToInt32(textBoxID.Text);
                TemporaireA.Nom = textBoxname.Text;
                TemporaireA.Prenom = textBoxprenom.Text;
                if (!IsTelOrNasValide(textBoxnas.Text, 9))
                {
                    MessageBox.Show("Le NAS non valide ! \n Veuillez entrer un NAS valide!");
                }
                else
                {
                    TemporaireA.Nas = textBoxnas.Text;
                    if (!IsTelOrNasValide(textBoxTel.Text, 10))
                    {
                        MessageBox.Show("Le téléphone non valide !");
                    }
                    else
                    {
                        TemporaireA.Cellulaire = textBoxTel.Text;
                        if (!IsEmailValid(textBoxMail.Text))
                        {
                            MessageBox.Show(" Adresse e-mail non valide!\n Veuillez entrer une adresse valide !!");
                        }
                        else
                        {
                            TemporaireA.Mail = textBoxMail.Text;
                            TemporaireA.DateNaissance = new Date(dateTimepdatenaissance.Value.Day, dateTimepdatenaissance.Value.Year, dateTimepdatenaissance.Value.Month);
                            TemporaireA.DateEmbauche = new Date(dateTimePickDateEmbauche.Value.Day, dateTimePickDateEmbauche.Value.Year, dateTimePickDateEmbauche.Value.Month);
                            TemporaireA.TauxHoraire = Convert.ToDouble(textBoxTauxHoraire.Text);
                            TemporaireA.NombreHeure = Convert.ToDouble(textBoxNombreheure.Text);
                            // ******** Entrer l'adresse:            
                            if (textBoxCodePostal.TextLength == 6)
                            {
                                if (!IsCodePostalValid(textBoxCodePostal.Text))
                                {
                                    MessageBox.Show("Le code postal n'est pas valide!");
                                }
                                else
                                {
                                    MessageBox.Show("Code postal valide");
                                    TemporaireA.AdressePostal = new Adresse(Convert.ToInt32(textBoxNumImmeuble.Text), textBoxAddresserue.Text
                            , Convert.ToInt32(textBoxNumAppt.Text), textBoxCodePostal.Text, textBoxVille.Text,
                            (Listesdesprovinces)comboBoxProvince.SelectedIndex);
                                    this.ListeDesPersonnelTemporaire.Add(TemporaireA);
                                    MessageBox.Show("Employé ajouté");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erreur ! Code postal non valide !!");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir le type de personnel !");
                comboBoxEmpFonction.Focus();
            }
        }

        private void comboBoxTypePersonnel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypePersonnel.SelectedIndex)
            {
                case 0:
                    textBoxSalaireAnnuel.Enabled = false;
                    textBoxTauxHoraire.Enabled = false;
                    textBoxNombreheure.Enabled = false;
                    comboBoxEmpFonction.Enabled = false;
                    break;
                case 1:

                    textBoxSalaireAnnuel.Enabled = true;
                    comboBoxEmpFonction.Enabled = true;
                    textBoxTauxHoraire.Enabled = false;
                    textBoxNombreheure.Enabled = false;
                    break;
                case 2:

                    textBoxSalaireAnnuel.Enabled = false;
                    comboBoxEmpFonction.Enabled = false;
                    textBoxTauxHoraire.Enabled = true;
                    textBoxNombreheure.Enabled = true;
                    break;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ajouter les personnels dans la combobox
            foreach (EnumTypePersonnel element in Enum.GetValues(typeof(EnumTypePersonnel)))
            {
                comboBoxTypePersonnel.Items.Add(element);
            }

            //Ajouter les fonctions dans combobox fonction
            foreach (FonctionsPermanents element in Enum.GetValues(typeof(FonctionsPermanents)))
            {
                comboBoxEmpFonction.Items.Add(element);
            }

            //Ajouter les provinces dans la combobox province
            foreach (Listesdesprovinces element in Enum.GetValues(typeof(Listesdesprovinces)))
            {
                comboBoxProvince.Items.Add(element);
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (comboBoxTypePersonnel.SelectedIndex == 1)
            {
                ListeDesPersonnelPermanent.RemoveAt(indexPermanent);
                MessageBox.Show("Personnel supprimé avec succée");
            }
                else if (comboBoxTypePersonnel.SelectedIndex == 2)
            {
                ListeDesPersonnelTemporaire.RemoveAt(indexTemporaire);
                MessageBox.Show("Personnel supprimé avec succée");
            }
            else
            {
                MessageBox.Show("Veuillez choisir le type du personnel avant de supprimer !");
            }
                
            
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            recordNumbPermanent = indexPermanent + 1;
            recordNumbTemporaire = indexTemporaire + 1;
            if (comboBoxTypePersonnel.SelectedIndex == 1)
            {
                MessageBox.Show("On modifie l'enregistrement : " + recordNumbPermanent);
                ListeDesPersonnelPermanent[indexPermanent].Id = Convert.ToInt32(textBoxID.Text);
                ListeDesPersonnelPermanent[indexPermanent].Nom = textBoxname.Text;
                ListeDesPersonnelPermanent[indexPermanent].Prenom = textBoxprenom.Text;
                ListeDesPersonnelPermanent[indexPermanent].Nas = textBoxnas.Text;
                ListeDesPersonnelPermanent[indexPermanent].Cellulaire = textBoxTel.Text;
                ListeDesPersonnelPermanent[indexPermanent].Mail = textBoxMail.Text;
                ListeDesPersonnelPermanent[indexPermanent].SalaireAnnuel = Convert.ToDouble(textBoxSalaireAnnuel.Text);
                ListeDesPersonnelPermanent[indexPermanent].Fonction = (FonctionsPermanents)comboBoxEmpFonction.SelectedIndex;
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NumImmeuble = Convert.ToInt32(textBoxNumImmeuble.Text);
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NomRue = textBoxAddresserue.Text;
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NumAppt = Convert.ToInt32(textBoxNumAppt.Text);
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.Ville = textBoxVille.Text;
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.CodePostal = textBoxCodePostal.Text;
                ListeDesPersonnelPermanent[indexPermanent].AdressePostal.Province = (Listesdesprovinces)comboBoxProvince.SelectedIndex;
            }
            else if (comboBoxTypePersonnel.SelectedIndex == 2)
            {
                MessageBox.Show("On modifie l'enregistrement : " + recordNumbTemporaire);
                ListeDesPersonnelTemporaire[indexTemporaire].Id = Convert.ToInt32(textBoxID.Text);
                ListeDesPersonnelTemporaire[indexTemporaire].Nom = textBoxname.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].Prenom = textBoxprenom.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].Nas = textBoxnas.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].Cellulaire = textBoxTel.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].Mail = textBoxMail.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].TauxHoraire = Convert.ToDouble(textBoxTauxHoraire.Text);
                ListeDesPersonnelTemporaire[indexTemporaire].NombreHeure = Convert.ToDouble(textBoxNombreheure.Text);
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.NumImmeuble = Convert.ToInt32(textBoxNumImmeuble.Text);
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.NomRue = textBoxAddresserue.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.NumAppt = Convert.ToInt32(textBoxNumAppt.Text);
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.Ville = textBoxVille.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.CodePostal = textBoxCodePostal.Text;
                ListeDesPersonnelTemporaire[indexTemporaire].AdressePostal.Province = (Listesdesprovinces)comboBoxProvince.SelectedIndex;
            }
            else
            {
                MessageBox.Show("Veuillez selectionnez le type du personnel avant de modifier! ");
            }
        }

        private void buttonAfficher_Click(object sender, EventArgs e)
        {
            if (this.ListeDesPersonnelPermanent.Capacity != 0)
            {
                foreach (PersonnelPermanent PermanentA in this.ListeDesPersonnelPermanent)
                {
                    this.listBoxPersonnelPermanent.Items.Add(PermanentA);
                }
            }
             if (this.ListeDesPersonnelTemporaire.Capacity != 0)
            {
                foreach (PersonnelTemporaire TemporaireA in this.ListeDesPersonnelTemporaire)
                {
                    this.listBoxPersonnelTemporaire.Items.Add(TemporaireA);
                }
            }
            else
            {
                MessageBox.Show("Il n'y a pas d'informations à afficher!");
            }
        }

        private void buttonTrier_Click(object sender, EventArgs e)
        {
            PersonnelPermanent PermanentA = new PersonnelPermanent();
            PersonnelTemporaire TemporaireA = new PersonnelTemporaire();
            List<String> PersonnalName = new List<string>();
            List<int> PersonnalNas = new List<int>();
            if (comboBoxTypePersonnel.SelectedIndex == 1)
            {
                foreach (PersonnelPermanent value in ListeDesPersonnelPermanent)
                {
                    PersonnalName.Add(value.Nom);
                    PersonnalNas.Add(Convert.ToInt32(value.Nas));
                }
                if (radioBtnNasTrier.Checked == true)
                {
                    listBoxPersonnelPermanent.Text = "";
                    PersonnalNas.Sort();
                    foreach (int value in PersonnalNas)
                    {
                        MessageBox.Show("Les employés triés par NAS :\n" + value);
                        listBoxPersonnelPermanent.Items.Add(value);
                    }
                }
                else if (radioBtnNometPrenomTrier.Checked == true)
                {
                    listBoxPersonnelPermanent.Text = "";
                    PersonnalName.Sort();
                    foreach (string value in PersonnalName)
                    {
                        MessageBox.Show("Les noms sont triés !");
                        listBoxPersonnelPermanent.Items.Add(value);
                    }
                }
            }
            // ******************
            else if (comboBoxTypePersonnel.SelectedIndex == 2)
            {
                foreach (PersonnelTemporaire value in ListeDesPersonnelTemporaire)
                {
                    PersonnalName.Add(value.Nom);
                    PersonnalNas.Add(Convert.ToInt32(value.Nas));
                }
                if (radioBtnNasTrier.Checked == true)
                {
                    listBoxPersonnelTemporaire.Text = "";
                    PersonnalNas.Sort();
                    foreach (int value in PersonnalNas)
                    {
                        MessageBox.Show("Les employés triés par NAS :\n" + value);
                        listBoxPersonnelTemporaire.Items.Add(value);
                    }
                }
                else if (radioBtnNometPrenomTrier.Checked == true)
                {
                    listBoxPersonnelTemporaire.Text = "";
                    PersonnalName.Sort();
                    foreach (string value in PersonnalName)
                    {
                        MessageBox.Show("Les noms sont triés !");
                        listBoxPersonnelTemporaire.Items.Add(value);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir soit : Permanent ou Temporaire");
            }
        }

        private void buttonChercher_Click(object sender, EventArgs e)
        {
            if (comboBoxTypePersonnel.SelectedIndex == 1)
            {
                PersonnelPermanent PermanentA = new PersonnelPermanent();
                bool trouver = false;
                if (radioBtnNas.Checked == true)
                {
                    foreach (PersonnelPermanent element in ListeDesPersonnelPermanent)
                    {
                        if (element.Nas == textBoxChercher.Text)
                        {
                            trouver = true;
                            PermanentA = element;
                        }
                    }
                    if (trouver)
                    {
                        listBoxPersonnelPermanent.Text = "";
                        MessageBox.Show("Element trouvé");
                        listBoxPersonnelPermanent.Items.Add(PermanentA.ToString());
                    }

                    else
                    {
                        trouver = false;
                        MessageBox.Show("Utilisateur introuvable avec le nas entré !");
                    }

                }

                else if (radioBtnNometPrenom.Checked == true)
                {
                    foreach (PersonnelPermanent element in ListeDesPersonnelPermanent)
                    {
                        if (element.Nom == textBoxChercher.Text)
                        {
                            trouver = true;
                            PermanentA = element;
                        }
                    }
                    if (trouver)
                    {
                        listBoxPersonnelTemporaire.Text = "";
                        MessageBox.Show("Element trouvé");
                        listBoxPersonnelPermanent.Items.Add(PermanentA.ToString());
                    }
                    else
                    {
                        trouver = false;
                        MessageBox.Show("Utilisateur introuvable avec le nom entré");
                    }
                }

            }
            //**************************************** list Temporaire
            else if (comboBoxTypePersonnel.SelectedIndex == 2)
            {
                PersonnelTemporaire TemporaireA = new PersonnelTemporaire();
                bool trouver = false;
                if (radioBtnNas.Checked == true)
                {
                    foreach (PersonnelTemporaire element in ListeDesPersonnelTemporaire)
                    {
                        if (element.Nas == textBoxChercher.Text)
                        {
                            trouver = true;
                            TemporaireA = element;
                        }
                    }
                    if (trouver)
                    {
                        MessageBox.Show("Element trouvé");
                        listBoxPersonnelTemporaire.Items.Add(TemporaireA.ToString());
                    }
                    else
                    {
                        trouver = false;
                        MessageBox.Show("Utilisateur introuvable avec le nas entré !");
                    }

                }
                else if (radioBtnNometPrenom.Checked == true)
                {
                    foreach (PersonnelTemporaire element in ListeDesPersonnelTemporaire)
                    {
                        if (element.Nom == textBoxChercher.Text)
                        {
                            trouver = true;
                            TemporaireA = element;
                        }
                    }
                    if (trouver)
                    {
                        MessageBox.Show("Element trouvé");
                        listBoxPersonnelTemporaire.Items.Add(TemporaireA.ToString());

                    }
                    else
                    {
                        trouver = false;
                        MessageBox.Show("Utilisateur introuvable avec le nom entré");
                    }

                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir soit : Permanent ou Temporaire");
            }
        }

        private void listBoxPersonnelPermanent_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexPermanent = listBoxPersonnelPermanent.SelectedIndex;
            MessageBox.Show("ListBox Students index : " + indexPermanent);
            textBoxID.Text = Convert.ToString(ListeDesPersonnelPermanent[indexPermanent].Id);
            textBoxname.Text = ListeDesPersonnelPermanent[indexPermanent].Nom;
            textBoxprenom.Text = ListeDesPersonnelPermanent[indexPermanent].Prenom;
            textBoxnas.Text = ListeDesPersonnelPermanent[indexPermanent].Nas;
            textBoxTel.Text = ListeDesPersonnelPermanent[indexPermanent].Cellulaire;
            textBoxMail.Text = ListeDesPersonnelPermanent[indexPermanent].Mail;
            textBoxNumImmeuble.Text = Convert.ToString(ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NumImmeuble);
            textBoxAddresserue.Text = ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NomRue;
            textBoxNumAppt.Text = Convert.ToString(ListeDesPersonnelPermanent[indexPermanent].AdressePostal.NumAppt);
            textBoxVille.Text = ListeDesPersonnelPermanent[indexPermanent].AdressePostal.Ville;
            textBoxCodePostal.Text = ListeDesPersonnelPermanent[indexPermanent].AdressePostal.CodePostal;
            comboBoxProvince.Text = Convert.ToString(this.ListeDesPersonnelPermanent[indexPermanent].AdressePostal.Province);
            comboBoxEmpFonction.Text = Convert.ToString(this.ListeDesPersonnelPermanent[indexPermanent].Fonction);
            textBoxSalaireAnnuel.Text = Convert.ToString(ListeDesPersonnelPermanent[indexPermanent].SalaireAnnuel);
        }

        private void listBoxPersonnelTemporaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexTemporaire = listBoxPersonnelTemporaire.SelectedIndex;
            MessageBox.Show("ListBox Students index : " + indexPermanent);
            textBoxID.Text = Convert.ToString(ListeDesPersonnelTemporaire[indexPermanent].Id);
            textBoxname.Text = ListeDesPersonnelTemporaire[indexPermanent].Nom;
            textBoxprenom.Text = ListeDesPersonnelTemporaire[indexPermanent].Prenom;
            textBoxnas.Text = ListeDesPersonnelTemporaire[indexPermanent].Nas;
            textBoxTel.Text = ListeDesPersonnelTemporaire[indexPermanent].Cellulaire;
            textBoxMail.Text = ListeDesPersonnelTemporaire[indexPermanent].Mail;
            textBoxNumImmeuble.Text = Convert.ToString(ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.NumImmeuble);
            textBoxAddresserue.Text = ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.NomRue;
            textBoxNumAppt.Text = Convert.ToString(ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.NumAppt);
            textBoxVille.Text = ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.Ville;
            textBoxCodePostal.Text = ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.CodePostal;
            comboBoxProvince.Text = Convert.ToString(this.ListeDesPersonnelTemporaire[indexPermanent].AdressePostal.Province);
            textBoxTauxHoraire.Text = Convert.ToString(ListeDesPersonnelTemporaire[indexTemporaire].TauxHoraire);
            textBoxNombreheure.Text = Convert.ToString(ListeDesPersonnelTemporaire[indexPermanent].NombreHeure);
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxname.Text = "";
            textBoxprenom.Text = "";
            textBoxTel.Text = "";
            textBoxTauxHoraire.Text = "";
            textBoxnas.Text = "";
            textBoxMail.Text = "";
            textBoxNombreheure.Text = "";
            textBoxNumAppt.Text = "";
            textBoxNumImmeuble.Text = "";
            textBoxVille.Text = "";
            textBoxSalaireAnnuel.Text = "";
            textBoxCodePostal.Text = "";
            textBoxChercher.Text = "";
            textBoxAddresserue.Text = "";
            comboBoxProvince.Text = "";
            comboBoxEmpFonction.Text = "";
            textBoxChercher.Text = "";
            listBoxPersonnelPermanent.Items.Clear();
            listBoxPersonnelTemporaire.Items.Clear();
        }

        private void buttonSortir_Click(object sender, EventArgs e)
        {
            if (textBoxID.Text != "" || textBoxname.Text!="" || textBoxprenom.Text!="" || textBoxMail.Text!="" || textBoxTel.Text !="" || textBoxnas.Text!="")
            {
                string q = Convert.ToString(MessageBox.Show("Êtes-vous sur vouloir quitter sans terminer ?", "Quitter", MessageBoxButtons.YesNo, MessageBoxIcon.Warning));
                    if (q == "Yes")
                    {
                        this.Close();
                    }                
            }
            else
            {
                this.Close();
            }
            
        }

        private void buttonSauvgarder_Click(object sender, EventArgs e)
        {
            FileHandler.WriteToFilePersonnelPermanent(ListeDesPersonnelPermanent);
            FileHandler.WriteToFilePersonnelTemporaire(ListeDesPersonnelTemporaire);
            
        }

        public static void DisplaylistboxPermanent(List<PersonnelPermanent> ListeDesPersonnelsPermanents, ListBox listBoxPersonnelPermanent)
        {
            foreach (PersonnelPermanent PermanentA in ListeDesPersonnelsPermanents)
            {
                listBoxPersonnelPermanent.Items.Add(PermanentA);
            }
        }

        public static void DisplaylistBoxTemporaire(List<PersonnelTemporaire> ListeDesPersonnelsTemporaires,ListBox listBoxDespersonnelTemporaire)
        {
            foreach(PersonnelTemporaire TemporaireA in ListeDesPersonnelsTemporaires)
            {
                listBoxDespersonnelTemporaire.Items.Add(TemporaireA);
            }
        }

        private void buttonCharger_Click(object sender, EventArgs e)
        {
            
            // listBoxPersonnelTemporaire.Items.Add(FileHandler.ReadFromListeDesPersonnelsTemporaires());
            this.ListeDesPersonnelPermanent.Clear();
            this.listBoxPersonnelPermanent.Items.Clear();

            this.ListeDesPersonnelPermanent = FileHandler.ReadFroFilePersonnelPermanent();
            DisplaylistboxPermanent(ListeDesPersonnelPermanent, listBoxPersonnelPermanent);
            //***************************************
            this.ListeDesPersonnelTemporaire.Clear();
            this.listBoxPersonnelTemporaire.Items.Clear();
            this.ListeDesPersonnelTemporaire = FileHandler.ReadFromListeDesPersonnelsTemporaires();
            DisplaylistBoxTemporaire(ListeDesPersonnelTemporaire, listBoxPersonnelTemporaire);
        }
        private void fichierTexteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void pleinÉcranToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.TopMost = true;
            WindowState = FormWindowState.Maximized;
            

        }

        private void documentProjetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dans le cas ou le projet ne s'ouvre, cela veut dire que vous n'avez pas le document "Projet" dans le disque D
            Process.Start("D:/Projet.docx");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void écranRéduiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.TopMost = true;
            WindowState = FormWindowState.Normal;
        }
    }
}
