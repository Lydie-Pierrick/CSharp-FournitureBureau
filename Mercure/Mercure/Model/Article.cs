using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mercure
{
    class Article
    {
        public Article()
        { }

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

        private string RefArticle;
        private string Description;
        private string Brand;
        private string Family;
        private string SubFamily;
        private string PriceHT;
        private int Quantity;

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

        public override string ToString()
        {
            return RefArticle;
        }
    }        
}
