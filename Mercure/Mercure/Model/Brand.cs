using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercure.Model
{
    class Brand
    {
        private int IdBrand;
        private string NameBrand;

        public Brand(int getSetIdBrand, string getSetNameBrand)
        {
            GetSetIdBrand = getSetIdBrand;
            GetSetNameBrand = getSetNameBrand;
        }

        public int GetSetIdBrand
        {
            get
            {
                return IdBrand;
            }

            set
            {
                IdBrand = value;
            }
        }

        public string GetSetNameBrand
        {
            get
            {
                return NameBrand;
            }

            set
            {
                NameBrand = value;
            }
        }
    }
}
