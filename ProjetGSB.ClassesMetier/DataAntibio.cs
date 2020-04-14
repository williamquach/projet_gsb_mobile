using System;
using System.Collections.Generic;
using System.Text;

namespace Antibio.Models
{
    public class DataAntibio
    {
        static private List<Antibio> lesAntibiotiques;
        static private List<Categorie> lesCategories;
        static public void initialiser()
        {
            DataAntibio.lesCategories = new List<Categorie>();
            Categorie uneCategorie1 = new Categorie("Aminoglycosides");
            DataAntibio.lesCategories.Add(uneCategorie1);
            Categorie uneCategorie2 = new Categorie("AntiFongiques");
            DataAntibio.lesCategories.Add(uneCategorie2);
            Categorie uneCategorie3 = new Categorie("Antiviraux");
            DataAntibio.lesCategories.Add(uneCategorie3);
            Categorie uneCategorie4 = new Categorie("Carbapénèmes");
            DataAntibio.lesCategories.Add(uneCategorie4);
            Categorie uneCategorie5 = new Categorie("Céphalosporines");
            DataAntibio.lesCategories.Add(uneCategorie5);
            Categorie uneCategorie6 = new Categorie("Macrolides");
            DataAntibio.lesCategories.Add(uneCategorie6);
            Categorie uneCategorie7 = new Categorie("Pénicillines");
            DataAntibio.lesCategories.Add(uneCategorie7);
            Categorie uneCategorie8 = new Categorie("Quinolones");
            DataAntibio.lesCategories.Add(uneCategorie8);
            Categorie uneCategorie9 = new Categorie("Sulfamidés");
            DataAntibio.lesCategories.Add(uneCategorie9);
            Categorie uneCategorie10 = new Categorie("Autres");
            DataAntibio.lesCategories.Add(uneCategorie10);

            DataAntibio.lesAntibiotiques = new List<Antibio>();
            AntibioParKilo unAntibioParKilo;
            unAntibioParKilo = new AntibioParKilo("Amiklin", "mg", uneCategorie1,1,15);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
            unAntibioParKilo = new AntibioParKilo("Garamycine", "mg", uneCategorie1,1,6);
            DataAntibio.lesAntibiotiques.Add(unAntibioParKilo);
        }
        static public List<Categorie> getLesCategories()
        {
            return DataAntibio.lesCategories;
        }
        static public List<Antibio> getAntibiotiquesUneCateg(Categorie c)
        {
            List<Antibio> liste = new List<Antibio>();
            foreach (Antibio a in DataAntibio.lesAntibiotiques)
            {
                if (a.getCategorie().getLibelle() == c.getLibelle())
                {
                    liste.Add(a);
                }
            }
            return liste;
        }
    }
}
