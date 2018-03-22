using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercure.Model
{
    class SubFamily
    {
        private int IdSubFamily;
        private string SubFamilyName;

        public SubFamily(int idSubFamily, string subFamilyName)
        {
            IdSubFamily = idSubFamily;
            SubFamilyName = subFamilyName;
        }

        public int GetSetIdSubFamily
        {
            get
            {
                return IdSubFamily;
            }

            set
            {
                IdSubFamily = value;
            }
        }

        public string GetSetSubFamilyName
        {
            get
            {
                return SubFamilyName;
            }

            set
            {
                SubFamilyName = value;
            }
        }
    }
}
