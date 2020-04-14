using System;
using System.Collections.Generic;
using System.Text;

namespace Antibio.Models
{
    public abstract class Antibio
    {
        private String libelle;
        private String unite;
        private Categorie laCategorie;
        private int nombreParJour;
        public Antibio(String pLibelle, String pUnite, Categorie pCategorie,int pNombre)
        {
            this.libelle = pLibelle;
            this.unite = pUnite;
            this.laCategorie = pCategorie;
            this.nombreParJour = pNombre;
        }
        public String getLibelle()
        {
            return this.libelle;
        }
        public String getUnite()
        {
            return this.unite;
        }
        public Categorie getCategorie()
        {
            return this.laCategorie;
        }
        public int getNombre()
        {
            return this.nombreParJour;
        }
        public override string ToString() 
        {
            string retour = this.libelle;
            return retour;
        }
    }
}
