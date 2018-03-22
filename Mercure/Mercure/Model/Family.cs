using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercure.Model
{
    class Family
    {
        private int IdFamily;
        private string FamilyName;

        public Family(int getSetIdFamily, string getSetFamilyName)
        {
            GetSetIdFamily = getSetIdFamily;
            GetSetFamilyName = getSetFamilyName;
        }

        public int GetSetIdFamily
        {
            get
            {
                return IdFamily;
            }

            set
            {
                IdFamily = value;
            }
        }

        public string GetSetFamilyName
        {
            get
            {
                return FamilyName;
            }

            set
            {
                FamilyName = value;
            }
        }
    }
}
