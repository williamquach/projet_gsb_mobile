using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ProjetGSB.Mobile.ClassesMetier;
using System.Net.Http;

namespace ProjetGSB.Mobile
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static INavigation GlobalNavigation { get; private set; }

        //-------------------
        public MainPage()
        {
            InitializeComponent();
            Charger();
        }
        DataAntibio da;
        private async void Charger()
        {
            //HttpClient wc = new HttpClient();
            //HttpClient wc1 = new HttpClient();
            //await DataAntibio.Initialisation(wc);

            //await DataAntibio.test(wc1);
            da = new DataAntibio();
            //await da.test();
            await da.SetLesCategories();
            await ChargerAntibios();
            lvCategories.ItemsSource = da.GetLesCategories();

        }
        private async Task ChargerAntibios()
        {
            await da.SetLesAntibiotiques();
        }
            private async void lvCategories_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (lvCategories.SelectedItem != null)
            {
                string libCategorie = (lvCategories.SelectedItem as Categorie).Libelle; ;
                await Navigation.PushAsync(new ProjetGSB.Mobile.Pages.Page_2_Antibio(libCategorie,da), true);
            }
        }

        private async void btnRechercheAntibio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProjetGSB.Mobile.Pages.Page_3_Recherche(da), true);
        }

        
    }
}
