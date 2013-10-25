using System;

namespace AboutPhone
{
    public class Battery
    {
        private string model; //read only
        private float idleTime; //read-write
        private float talkTime; //read-write
        private BatteryType batteryType = BatteryType.not_specified; // read only

        //Define constructors
        public Battery(string model)
        {
            isBatteryModelCorect(model);
            this.model = model;
        }

        public Battery(string model, BatteryType batteryType)
        {
            isBatteryModelCorect(model);
            this.model = model;
            this.batteryType = batteryType;
        }

        //Define properties
        public string Model
        {
            get { return this.model; }
        }

        public float IdleTime
        {
            get { return this.idleTime; }
            set
            {
                isIdleAndTalkTimeCorect(value);
                this.idleTime = value;
            }
        }

        public float TalkTime
        {
            get {return this.talkTime; }
            set
            {
                isIdleAndTalkTimeCorect(value);
                this.talkTime = value;
            }
        }

        public BatteryType BatteryType
        {
            get { return this.batteryType; }
        }

        //Methods that check input information
        private static void isBatteryModelCorect(string model)
        {
            if (model.Length <= 2)
            {
                throw new ApplicationException("Battery model must contain more from two characters!");
            }
        }

        private static void isIdleAndTalkTimeCorect(float time)
        {
            if (time < 1)
            {
                throw new ApplicationException("Battery life must more from one hour");
            }
        }
    }
}
