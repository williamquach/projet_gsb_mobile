using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetGSB.Mobile.ClassesMetier;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetGSB.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page_2_Antibio : ContentPage
    {
        public Page_2_Antibio()
        {
            InitializeComponent();
        }
        public Page_2_Antibio(string libCateg, DataAntibio da)
        {
            InitializeComponent();
            cntPage_Posologie.Title = libCateg;
            lblPage.Text = "Antibiotiques";
            if (da.GetAntibiotiqueUneCateg(libCateg).Count != 0)
            {
                lvAntibioParCategChoisie.ItemsSource = da.GetAntibiotiqueUneCateg(libCateg);
            } 
            else
            {
                lblListeVide.IsVisible = true;
            }
        }

        public bool IsDouble(string Nombre)
        {
            try
            {
                double.Parse(Nombre);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void lvAntibioParCategChoisie_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            txtPoids.Text = "";

            Antibio testType_Antibio = (lvAntibioParCategChoisie.SelectedItem as Antibio);

            if (testType_Antibio is AntibioParKilo)
            {
                txtPoids.IsVisible = true;
            }
            else if (testType_Antibio is AntibioParPrise)
            {
                txtPoids.IsVisible = false;
            }
        }

        private async void btnRechercherPrescrip_Clicked(object sender, EventArgs e)
        {
            if (lvAntibioParCategChoisie.SelectedItem == null)
            {
                await DisplayAlert("Erreur", "Veuillez d'abord sélectionner un antibiotique.", "OK");
            } 
            else 
            {
                Antibio lAntibio = lvAntibioParCategChoisie.SelectedItem as Antibio;
                //double testInt = Convert.ToDouble(txtPoids.Text);
                if (txtPoids.Text == "" && lAntibio is AntibioParKilo)
                {
                    await DisplayAlert("Erreur", "Vous avez choisi un antibiotique dont la posologie nécessite l'entrée d'un poids.", "OK");
                }
                else if (lAntibio is AntibioParKilo && IsDouble(txtPoids.Text))
                {
                    AntibioParKilo lantibioParKilo = lvAntibioParCategChoisie.SelectedItem as AntibioParKilo;
                    string doseParKilo = (Convert.ToDouble(txtPoids.Text) * lantibioParKilo.DoseKilo).ToString();
                    string nbParJour = lantibioParKilo.NombreParJour.ToString();
                    string unite = lantibioParKilo.Unite;
                    await DisplayAlert("Prescription", "Pour une prise de l'antibiotique : " + lantibioParKilo.Libelle + "\nIl faut prendre " + doseParKilo + " " + unite + " par prise, " + nbParJour + " fois par jour", "OK");
                    txtPoids.Text = "";
                }
                else if (lAntibio is AntibioParKilo)
                {
                    await DisplayAlert("Erreur", "Vous devez entrer une valeur numérique.", "OK");
                }
                if (lAntibio is AntibioParPrise)
                {
                    AntibioParPrise lantibioParPrise = lvAntibioParCategChoisie.SelectedItem as AntibioParPrise;
                    string doseParPrise = lantibioParPrise.DosePrise.ToString();
                    string nbParJour = lantibioParPrise.NombreParJour.ToString();
                    string unite = lantibioParPrise.Unite;
                    await DisplayAlert("Prescription", "Pour une prise du l'antibiotique : " + lantibioParPrise.Libelle + "\nIl faut prendre " + doseParPrise + " " + unite + " par prise, " + nbParJour + " fois par jour", "OK");

                }
            }
        }

        
    }
}