using System;
using System.Collections.Generic;

namespace VirtualShop
{
    class AdsStock
    {
        private static List<Ads> adsList = new List<Ads>();

        public static List<Ads> GetAds
        {
            get { return adsList; }
        }

        public void AddAds(Ads ads)
        {
            adsList.Add(ads);
        }

        public static List<Ads> GetAllAds()
        {
            //Tozi metod ne trqbva da se pravi tochno taka... shte se opitam da go opravq po-kusno
            //Pravq nqkakuv sravnitelno burz variant za rotaciq na reklamite, zashtoto nqmame mnogo vreme :D

            int seconds = DateTime.Now.Second;

            adsList.Clear(); //zasega slagam tova, zashtoto inache se natrupvat elementite v List<Ads> GetAds

            //Rotation can be implemented with randomizer if more than 3

            Ads firstAds = new Ads("First company", "Google", seconds <= 20 ? true : false);
            Ads secondAds = new Ads("Second company", "Yahoo", seconds > 40 ? true : false);
            Ads thirdAds = new Ads("Third company", "Microsoft", (seconds > 20 && seconds <= 40) ? true : false);
            adsList.Add(firstAds);
            adsList.Add(secondAds);
            adsList.Add(thirdAds);
            return adsList;
        }
    }
}
