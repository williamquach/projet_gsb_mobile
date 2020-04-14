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
    public partial class Page_3_Recherche : ContentPage
    {
        DataAntibio da;

        public Page_3_Recherche(DataAntibio data)
        {
            InitializeComponent();
            da = data;
        }
        private void txtRecherche_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtRecherche.Text == "")
            {
                lv_Antibio_Recherches.ItemsSource = null;
            }
            else
            {
                string chaineRecherche = txtRecherche.Text;
                int nbCaractere = chaineRecherche.Length;
                List<Antibio> listeRecherche = da.SearchAntibio(chaineRecherche, nbCaractere);
                lv_Antibio_Recherches.ItemsSource = listeRecherche;
            }
        }

        private void lv_Antibio_Recherches_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            txtPoidsR.Text = "";

            Antibio testType_Antibio = (lv_Antibio_Recherches.SelectedItem as Antibio);

            if (testType_Antibio is AntibioParKilo)
            {
                txtPoidsR.IsVisible = true;
            }
            else if (testType_Antibio is AntibioParPrise)
            {
                txtPoidsR.IsVisible = false;
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

        private async void btnPrescription_Clicked(object sender, EventArgs e)
        {
            if (lv_Antibio_Recherches.SelectedItem == null)
            {
                await DisplayAlert("Erreur", "Veuillez d'abord sélectionner un antibiotique.", "OK");
            }
            else
            {
                Antibio lAntibio = lv_Antibio_Recherches.SelectedItem as Antibio;
                if (txtPoidsR.Text == "" && lAntibio is AntibioParKilo)
                {
                    await DisplayAlert("Erreur", "Vous avez choisi un antibiotique dont la posologie nécessite l'entrée d'un poids.", "OK");
                }
                else if (lAntibio is AntibioParKilo && IsDouble(txtPoidsR.Text))
                {
                    AntibioParKilo lantibioParKilo = lv_Antibio_Recherches.SelectedItem as AntibioParKilo;
                    string doseParKilo = (Convert.ToDouble(txtPoidsR.Text) * lantibioParKilo.DoseKilo).ToString();
                    string nbParJour = lantibioParKilo.NombreParJour.ToString();
                    string unite = lantibioParKilo.Unite;
                    await DisplayAlert("Prescription", "Pour une prise de l'antibiotique : " + lantibioParKilo.Libelle + "\nIl faut prendre " + doseParKilo + " " + unite + " par prise, " + nbParJour + " fois par jour", "OK");
                    txtPoidsR.Text = "";
                }
                else if (lAntibio is AntibioParKilo)
                {
                    await DisplayAlert("Erreur", "Vous devez entrer une valeur numérique.", "OK");
                }
                if (lAntibio is AntibioParPrise)
                {
                    AntibioParPrise lantibioParPrise = lv_Antibio_Recherches.SelectedItem as AntibioParPrise;
                    string doseParPrise = lantibioParPrise.DosePrise.ToString();
                    string nbParJour = lantibioParPrise.NombreParJour.ToString();
                    string unite = lantibioParPrise.Unite;
                    await DisplayAlert("Prescription", "Pour une prise du l'antibiotique : " + lantibioParPrise.Libelle + "\nIl faut prendre " + doseParPrise + " " + unite + " par prise, " + nbParJour + " fois par jour", "OK");

                }
            }
        }
    }
}