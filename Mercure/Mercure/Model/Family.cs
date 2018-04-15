namespace Mercure.Model
{
    class Family
    {
        private int IdFamily;
        private string FamilyName;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Family()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IdBrand"> Family ID </param>
        /// <param name="NameBrand"> Family name</param>
        public Family(int IdFamily, string FamilyName)
        {
            GetSetIdFamily = IdFamily;
            GetSetFamilyName = FamilyName;
        }

        /// <summary>
        /// Getter Setter of family ID
        /// </summary>
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

        /// <summary>
        /// Getter Setter of family name
        /// </summary>
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

        /// <summary>
        /// Override ToString()
        /// </summary>
        /// <returns> Family name </returns>
        public override string ToString()
        {
            return FamilyName;
        }
    }
}
