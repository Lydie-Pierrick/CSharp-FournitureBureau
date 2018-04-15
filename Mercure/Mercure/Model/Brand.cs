namespace Mercure.Model
{
    class Brand
    {
        private int IdBrand;
        private string NameBrand;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Brand()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IdBrand"> Brand ID </param>
        /// <param name="NameBrand"> Brand name</param>
        public Brand(int IdBrand, string NameBrand)
        {
            GetSetIdBrand = IdBrand;
            GetSetNameBrand = NameBrand;
        }

        /// <summary>
        /// Getter Setter of brand ID
        /// </summary>
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


        /// <summary>
        /// Getter Setter of brand name
        /// </summary>
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

        /// <summary>
        /// Override ToString()
        /// </summary>
        /// <returns> Brand name </returns>
        public override string ToString()
        {
            return NameBrand;
        }
    }
}
