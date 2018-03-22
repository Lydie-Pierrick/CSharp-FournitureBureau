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

        public Article(int getSetRefArticle, string getSetDescription, int getSetRefSubFamily, int getSetRefBrand, double getSetPriceHT, int getSetAmount, int getSetRefFamily)
        {
            GetSetRefArticle = getSetRefArticle;
            GetSetDescription = getSetDescription;
            GetSetRefSubFamily = getSetRefSubFamily;
            GetSetRefBrand = getSetRefBrand;
            GetSetPriceHT = getSetPriceHT;
            GetSetAmount = getSetAmount;
            GetSetRefFamily = getSetRefFamily;
        }

        private int RefArticle;
        private string Description;
        private int RefFamily;
        private int RefSubFamily;
        private int RefBrand;
        private double PriceHT;
        private int Amount;

        public int GetSetRefArticle
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

        public int GetSetRefSubFamily
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

        public int GetSetRefBrand
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

        public int GetSetRefFamily
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
