using System;
using System.Collections.Generic;

namespace VirtualShop
{
    public class Ads
    {
        private string companyName;
        private string adsContent;
        private bool isActive;

        public event AdsEventHandler AdsEH;

        public Ads()
        {
        }

        public Ads(string companyName, string adsContent, bool isActive)
        {
            this.companyName = companyName;
            this.adsContent = adsContent;
            this.isActive = isActive;
        }

        public string CompanyName
        {
            get { return this.companyName; }
            set { this.companyName = value; }
        }

        public string AdsContent
        {
            get { return this.adsContent; }
            set { this.adsContent = value; }
        }

        protected void AdsTypeChanged(Ads ads)
        {
            if (AdsEH != null)
            {
                Console.WriteLine("Company: {0} ads content: {1}", ads.companyName, ads.adsContent);
                AdsEventArgs args = new AdsEventArgs(ads.companyName, ads.adsContent);
                AdsEH(this, args);
            }
        }

        public void CheckForActiveAds(IEnumerable<Ads> adsList)
        {
            foreach (var ads in adsList)
            {
                if (ads.isActive)
                {
                    AdsTypeChanged(ads);
                }
            }
        }
    }
}
