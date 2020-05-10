using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ProjetGSB.Mobile.ClassesMetier
{
    public class DataAntibio
    {
        public List<Antibio> lesAntibiotiques;
        public List<Categorie> lesCategories;
        public HttpClient wc;
        public DataAntibio()
        {
            wc = new HttpClient();
        }
        public async Task SetLesCategories()
        {
            lesCategories = new List<Categorie>();
            // récupération des catégories
            var reponse = await wc.GetStringAsync("http://10.0.2.2/api_gsb_antibio/getallcategories.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse);
                var list = donnees["results"]["categorie"];
                foreach (var item in list)
                {
                    Categorie unecateg = new Categorie()
                    {
                        IdCateg = Convert.ToInt32(item["idCateg"].Value.ToString()),
                        Libelle = item["libelle"].Value.ToString()
                    };

                    lesCategories.Add(unecateg);
                }
        }
        public async Task SetLesAntibiotiques()
        {
            lesAntibiotiques = new List<Antibio>();
            // récupération des antibiotiques
            var reponse2 = await wc.GetStringAsync("http://10.0.2.2/api_gsb_antibio/getallantibio.php");
            var donnees = JsonConvert.DeserializeObject<dynamic>(reponse2);
            var list = donnees["results"]["antibiotique"];
            foreach (var item in list)
            {
                if(item["doseParPrise"].Value != null && item["doseParKg"].Value == null)
                {
                    Categorie laCateg = GetCategorieDeLantibio(item["codeCategorie"].Value.ToString()) ;
                    AntibioParPrise unABParPrise = new AntibioParPrise()
                    {
                        DosePrise = Convert.ToSingle(item["doseParPrise"].Value.ToString()),
                        LaCategorie = laCateg,
                        Libelle = item["libelleMedoc"].Value.ToString(),
                        NombreParJour = Convert.ToInt32(item["nbParJour"].Value.ToString()),
                        Unite = item["unite"].Value.ToString()
                    };
                    lesAntibiotiques.Add(unABParPrise);
                }
                else if (item["doseParKg"].Value != null && item["doseParPrise"].Value == null)
                {
                    Categorie laCateg = GetCategorieDeLantibio(item["codeCategorie"].Value.ToString());
                    AntibioParKilo unABParKilo = new AntibioParKilo()
                    {
                        DoseKilo = Convert.ToSingle(item["doseParKg"].Value.ToString()),
                        LaCategorie = laCateg,
                        Libelle = item["libelleMedoc"].Value.ToString(),
                        NombreParJour = Convert.ToInt32(item["nbParJour"].Value.ToString()),
                        Unite = item["unite"].Value.ToString()
                    };
                    lesAntibiotiques.Add(unABParKilo);
                }
            }
        }
        public List<Antibio> GetAntibiotiqueUneCateg(string libelleCategorie)
        {
            List<Antibio> liste = new List<Antibio>();
            foreach (Antibio a in lesAntibiotiques)
            {
                if (a.LaCategorie.Libelle == libelleCategorie)
                {
                    liste.Add(a);
                }
            }
            return liste;
        }
        public List<Antibio> SearchAntibio(string chaineRech, int tailleChaine)
        {
            List<Antibio> listeResultat = new List<Antibio>();
            foreach (Antibio ab in lesAntibiotiques)
            {
                if (ab.Libelle.Substring(0, tailleChaine).ToLower() == chaineRech.ToLower())
                {
                    listeResultat.Add(ab);
                }
            }
            return listeResultat;
        }

        // AJOUT MADAME CASTAING
        //static public List<AntibioParKilo> getAntibioParKiloParCategorie(Categorie uneCategorie)
        //{
        //    List<AntibioParKilo> lesAntibioParKilo = new List<AntibioParKilo>();
        //    foreach(Antibio ab in lesAntibiotiques)
        //    {
        //        if(ab is AntibioParKilo && ab.LaCategorie.Libelle == uneCategorie.Libelle)
        //        {
        //            AntibioParKilo abk = (AntibioParKilo)ab;
        //            lesAntibioParKilo.Add(abk);
        //        }
        //    }
        //    return lesAntibioParKilo;
        //}

        public Categorie GetCategorieDeLantibio(string idCateg)
        {
            Categorie uneCateg = new Categorie();
            foreach (Categorie c in lesCategories)
            {
                if(c.IdCateg.ToString() == idCateg)
                {
                    return c;
                }
            }
            return uneCateg;
        }
    }
}