using System;

namespace VirtualShop
{
    public class AlgorithmOfEGN
    {
        public bool IsEGNValid(string egn)
        {
            // проверяваме дали е въведена няква стойност
            if (string.IsNullOrEmpty(egn)) return false;

            // проверяваме дали низът се състои точно от 10 символа
            if (egn.Length != 10) { return false; }

            // проверяваме дали низът се състои само от цифри
            double num;

            if (!double.TryParse(egn, out num)) { return false; }

            // низът е проверен, слователно пристъпваме към главната задача
            int[] weights = { 2, 4, 8, 5, 10, 9, 7, 3, 6 };
            string date = string.Empty;
            DateTime dt;

            // първите две цифри указват годината на раждане
            int year = Int16.Parse(egn.Substring(0, 2));

            // вторите две цифри указват месеца
            int month = Int16.Parse(egn.Substring(2, 2));

            // третите две цифри указват деня
            int day = Int16.Parse(egn.Substring(4, 2));

            if (month > 40)
            {
                date = (month - 40) + "-" + day + "-" + (year + 2000);
            }
            else if (month > 20)
            {
                date = (month - 20) + "-" + day + "-" + (year + 1800);
            }
            else
            {
                date = month + "-" + day + "-" + (year + 1900);
            }

            if (DateTime.TryParse(date, out dt) == false) { return false; }

            int checkSum = Int32.Parse(egn.Substring(9, 1));
            int egnSum = 0;
            int validCheckSum = 0;

            for (int i = 0; i < 9; i++)
            {
                egnSum += int.Parse(egn.Substring(i, 1)) * weights[i];
            }

            validCheckSum = egnSum % 11;

            if (validCheckSum == 10) { validCheckSum = 0; }

            if (checkSum == validCheckSum) { return true; }
            else { return false; }
        }
    }
}
