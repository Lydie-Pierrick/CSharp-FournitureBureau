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
        private string Description;
        private string Reference;
        private string Brand;
        private string Familly;
        private string SubFamilly;
        private double PriceHT;

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

        public string GetSetReference
        {
            get
            {
                return Reference;
            }

            set
            {
                Reference = value;
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

        public string GetSetFamilly
        {
            get
            {
                return Familly;
            }

            set
            {
                Familly = value;
            }
        }

        public string GetSetSubFamilly
        {
            get
            {
                return SubFamilly;
            }

            set
            {
                SubFamilly = value;
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
    }
}
