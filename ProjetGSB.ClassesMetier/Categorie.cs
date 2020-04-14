using System;
using System.Collections.Generic;
using System.Text;

namespace Antibio.Models
{
    public class Categorie
    {
        private string libelle;
        public Categorie(string pLibelle)
        {
            this.libelle = pLibelle;
        }
        public string getLibelle()
        {
            return this.libelle;
        }      
        public override string ToString()
        {
            return this.libelle;
        }
    }

}
