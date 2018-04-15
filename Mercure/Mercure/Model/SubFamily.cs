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

        /// <summary>
        /// Default constructor
        /// </summary>
        public SubFamily()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IdSubFamily"> Subfamily ID </param>
        /// <param name="NameBrand"> Subfamily name</param>
        public SubFamily(int IdSubFamily, string SubFamilyName)
        {
            GetSetIdSubFamily = IdSubFamily;
            GetSetSubFamilyName = SubFamilyName;
        }

        /// <summary>
        /// Getter Setter of subfamily ID
        /// </summary>
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

        /// <summary>
        /// Getter Setter of subfamily name
        /// </summary>
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

        /// <summary>
        /// Override ToString()
        /// </summary>
        /// <returns> Subfamily name </returns>
        public override string ToString()
        {
            return SubFamilyName;
        }
    }
}
