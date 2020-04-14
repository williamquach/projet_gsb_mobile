using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetGSB.Mobile.ClassesMetier
{
    public class Categorie
    {
        public int IdCateg { get; set; }
        public string Libelle{ get; set; }
        public override string ToString()
        {
            return this.Libelle.ToUpper();
        }
    }

}
