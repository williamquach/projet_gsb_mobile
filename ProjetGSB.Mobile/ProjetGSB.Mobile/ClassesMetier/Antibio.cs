using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGSB.Mobile.ClassesMetier
{
    public abstract class Antibio
    {
        public string Libelle { get; set; }
        public string Unite { get; set; }
        public Categorie LaCategorie { get; set; }
        public int NombreParJour { get; set; }
        //private string libelle;
        //private string unite;
        //private Categorie laCategorie;
        //private int nombreParJour;
        //public Antibio(string pLibelle, string pUnite, Categorie pCategorie,int pNombre)
        //{
        //    this.libelle = pLibelle;
        //    this.unite = pUnite;
        //    this.laCategorie = pCategorie;
        //    this.nombreParJour = pNombre;
        //}
        //public string getLibelle()
        //{
        //    return this.libelle;
        //}
        //public string getUnite()
        //{
        //    return this.unite;
        //}
        //public Categorie getCategorie()
        //{
        //    return this.laCategorie;
        //}
        //public int getNombre()
        //{
        //    return this.nombreParJour;
        //}

        public override string ToString()
        {
            return this.Libelle.ToUpper();
        }
    }
}
