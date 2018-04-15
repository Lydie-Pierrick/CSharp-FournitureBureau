namespace Mercure
{
    class Article
    {
        private string RefArticle;
        private string Description;
        private string Brand;
        private string Family;
        private string SubFamily;
        private string PriceHT;
        private int Quantity;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Article()
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="RefArticle"> Ref of article </param>
        /// <param name="Description"> Description of article </param>
        /// <param name="Family"> Family name </param>
        /// <param name="SubFamily"> Subfamily name</param>
        /// <param name="Brand">  Brand name </param>
        /// <param name="PriceHT"> Price of article </param>
        /// <param name="Quantity"> Quantity of article </param>
        public Article(string RefArticle, string Description, string Family, string SubFamily, string Brand, string PriceHT, int Quantity)
        {
            GetSetRefArticle = RefArticle;
            GetSetDescription = Description;
            GetSetFamily = Family;
            GetSetSubFamily = SubFamily;
            GetSetBrand = Brand;
            GetSetPriceHT = PriceHT;
            GetSetQuantity = Quantity;
        }

        /// <summary>
        /// Getter Setter of reference of article
        /// </summary>
        public string GetSetRefArticle
        {
            get
            {
                return RefArticle;
            }

            set
            {
                RefArticle = value;
            }
        }

        /// <summary>
        /// Getter Setter of description
        /// </summary>
        public string GetSetDescription
        {
            get
            {
                return Description;
            }

            set
            {
                Description = value;
            }
        }

        /// <summary>
        /// Getter Setter of subfamily name
        /// </summary>
        public string GetSetSubFamily
        {
            get
            {
                return SubFamily;
            }

            set
            {
                SubFamily = value;
            }
        }

        /// <summary>
        /// Getter Setter of family name
        /// </summary>
        public string GetSetFamily
        {
            get
            {
                return Family;
            }

            set
            {
                Family = value;
            }
        }

        /// <summary>
        /// Getter Setter of brand name
        /// </summary>
        public string GetSetBrand
        {
            get
            {
                return Brand;
            }

            set
            {
                Brand = value;
            }
        }

        /// <summary>
        /// Getter Setter of price
        /// </summary>
        public string GetSetPriceHT
        {
            get
            {
                return PriceHT;
            }

            set
            {
                PriceHT = value;
            }
        }

        /// <summary>
        /// Getter Setter of quantity
        /// </summary>
        public int GetSetQuantity
        {
            get
            {
                return Quantity;
            }

            set
            {
                Quantity = value;
            }
        }

        /// <summary>
        /// Override of ToString()
        /// </summary>
        /// <returns> Referernce of article </returns>
        public override string ToString()
        {
            return RefArticle;
        }
    }        
}
