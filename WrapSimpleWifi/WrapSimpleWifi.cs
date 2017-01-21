
using System;
using System.Collections.Generic;
using SimpleWifi;


namespace WrapSimpleWifi
{
    public class ManageWifi
    {
        //ислкючения
        public static ArgumentException badPassword = new ArgumentException("Wrong Password!");
        public static ArgumentException unkownErorr = new ArgumentException("Unknown Erorr!");
        public static ArgumentException badName = new ArgumentException("Wifi not found! Name of Wifi is incorrect!");

        //объекты SimpleWifi
        public List<AccessPoint> lWifi;
        Wifi wifi;

        public bool wifiOn(string name, string password)
        {

            lWifi = wifi.GetAccessPoints();
            bool searchWifi = false;

            foreach (AccessPoint ap in lWifi)
            {
                if (ap.Name == name)
                {
                    searchWifi = true;

                    AuthRequest autrequest = new AuthRequest(ap);
                    autrequest.Password = password;

                    if (!ap.Connect(autrequest))
                        if (!ap.Connect(autrequest, true))
                        {
                            if (!ap.IsValidPassword(password))
                                throw (badPassword);
                            else throw (unkownErorr);
                        }
                }

            }
            if (!searchWifi) throw (badName);
            return true;

        }
        public void WifiOff(string name)
        {
            lWifi = wifi.GetAccessPoints();

            foreach (AccessPoint ap in lWifi)
            {
                if (ap.Name == name)
                    if (ap.IsConnected) wifi.Disconnect();
                    else throw (badName);
            }
        }
        public void refreshlWifi()
        {
            lWifi = wifi.GetAccessPoints();
        }
        public  ManageWifi()
        {
            wifi = new Wifi();
            lWifi = new List<AccessPoint>();
        }
    }
}
