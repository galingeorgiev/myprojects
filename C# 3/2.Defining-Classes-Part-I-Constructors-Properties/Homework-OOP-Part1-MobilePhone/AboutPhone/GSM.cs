/*Define a class that holds information about a mobile
 *phone device: model, manufacturer, price, owner,
 *battery characteristics (model, hours idle and hours
 *talk) and display characteristics (size and number of
 *colors). Define 3 separate classes (class GSM holding
 *instances of the classes Battery and Display).
 *
 *Assume that model and manufacturer are mandatory (the
 *others are optional). All unknown data fill with null.
 */

using System;
using System.Collections.Generic;

namespace AboutPhone
{
    public class GSM
    {
        private string model; //reda only
        private string manufacturer; //reda only
        private int? price = null; //read-write
        private string owner = null; //read-write only
        private Battery battery = null; //model is read only fields, idle and talk time are read-write fields
        private Display display = null; //read only fields

        /*Add a static field and a property IPhone4S in the
         * GSM class to hold the information about iPhone 4S.*/
        private static Battery iphone4Sbattery = new Battery("iphone special model", BatteryType.LiPolymer);
        private static Display iphone4Sdisplay = new Display(4, 65536);
        private static GSM iphone4S = new GSM("IPhone 4S", "Apple")
                                    { owner = "[not specified]", price = 1500, battery = iphone4Sbattery, display = iphone4Sdisplay };
        
        private List<Call> callHistory = new List<Call>(); //read-write

        //Define constructors
        public GSM(string model, string manufacturer)
        {
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, int price) : this(model, manufacturer)
        {
            this.price = price;
        }

        public GSM(string model, string manufacturer, int price, Battery battery, Display display) : this(model, manufacturer, price)
        {
            this.battery = battery;
            this.display = display;
        }

        //Define properties
        public string Model
        {
            get { return this.model; }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
        }

        public int? Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public string Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }

        public static GSM Iphone4S
        {
            get { return iphone4S; }
        }

        /*Add a property CallHistory in the GSM class to
         * hold a list of the performed calls. Try to use the
         * system class List<Call>.*/
        public Call CallHistory
        {
            get { return this.callHistory[callHistory.Count - 1]; }
            set { this.callHistory.Add(value); }
        }

        //Define methods

        /*Add a method in the GSM class for displaying all
         * information about it. Try to override ToString().*/
        public override string ToString()
        {
            return string.Format("Mobile phone manufacturer: {0}; Model: {1}; Price: {2:c}; Owner: {3}",
                this.manufacturer, this.model, this.price ?? 0, this.owner ?? "[not specified]");
        }

        /*Add methods in the GSM class for adding and
         * deleting calls from the calls history. Add
         * a method to clear the call history.*/
        public void AddInCallHistory(Call newCall)
        {
            this.CallHistory = newCall;
        }

        public void RemoveFromCallHistory(int positionInHistory)
        {
            this.callHistory.RemoveAt(positionInHistory);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        /*Add a method that calculates the total price of the
         * calls in the call history. Assume the price per minute
         * is fixed and is provided as a parameter.*/
        public float CallsTotalPrice(float pricePerMinute)
        {
            int totalDuration = 0;
            foreach (var call in callHistory)
            {
                totalDuration = totalDuration + call.Duration;
            }

            return ((float)totalDuration / 60) * pricePerMinute;
        }
    }
}