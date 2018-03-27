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

        public Article(string RefArticle, string Description, string RefSubFamily, string RefBrand, double PriceHT, int Amount, string RefFamily)
        {
            GetSetRefArticle = RefArticle;
            GetSetDescription = Description;
            GetSetRefSubFamily = RefSubFamily;
            GetSetRefBrand = RefBrand;
            GetSetPriceHT = PriceHT;
            GetSetAmount = Amount;
            GetSetRefFamily = RefFamily;
        }

        private string RefArticle;
        private string Description;
        private string RefFamily;
        private string RefSubFamily;
        private string RefBrand;
        private double PriceHT;
        private int Amount;

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

        public string GetSetRefSubFamily
        {
            get
            {
                return RefSubFamily;
            }

            set
            {
                RefSubFamily = value;
            }
        }

        public string GetSetRefBrand
        {
            get
            {
                return RefBrand;
            }

            set
            {
                RefBrand = value;
            }
        }

        public double GetSetPriceHT
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

        public int GetSetAmount
        {
            get
            {
                return Amount;
            }

            set
            {
                Amount = value;
            }
        }

        public string GetSetRefFamily
        {
            get
            {
                return RefFamily;
            }

            set
            {
                RefFamily = value;
            }
        }
    }        
}
