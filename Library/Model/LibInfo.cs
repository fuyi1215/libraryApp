using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Library
{
    public class LibInfo
    {
        public LibInfo()
        {
        }
        public static Dictionary<string, string> LibraryList = new Dictionary<string, string>
        {
            {"Butler Public Library", "ButlerPublicLibrary.json"},
            {"Benton Harbor Public Library", "BentonHarborPublicLibrary.json"},
            {"Brooks-Iroquois-Washington Public Library", "BrooksIroquoisWashingtonPublicLibrary.json"},
            {"Crawfordsville District Public Library", "CrawfordsvilleDistrictPublicLibrary.json"},
            {"Flora Monroe Township Public Library","FloraMonroeTownshipPublicLibrary.json"},
            {"Francesville Salem Township Public Library", "FrancesvilleSalemTownshipPublicLibrary.json"},
            {"Greentown Public Library", "GreentownPublicLibrary.json"},
            {"Lincoln Heritage Public Library", "LincolnHeritagePublicLibrary.json"},
            //{"Parke County Public Library", "ParkeCountyPublicLibrary.json"},
            {"Perry County Public Library", "PerryCountyPublicLibrary.json"},

        };

        public static string NewUrl { set; get; } = string.Empty;
        public static Color Backgroundcolor { set; get; }
        public static readonly string Imagefolderclinetlogos = "Library.Assets.ClientLogos.";
        public class Time
        {
            public string MondayOpen { get; set; }
            public string MondayClose { get; set; }
            public string TuesdayOpen { get; set; }
            public string TuesdayClose { get; set; }
            public string WednesdayOpen { get; set; }
            public string WednesdayClose { get; set; }
            public string ThursdayOpen { get; set; }
            public string ThursdayClose { get; set; }
            public string FridayOpen { get; set; }
            public string FridayClose { get; set; }
            public string SaturdayOpen{ get; set; }
            public string SaturdayClose { get; set; }
            public string SundayOpen { get; set; }
            public string SundayClose { get; set; }
        }
        public class Address
        {
            
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string zipCode { get; set; }


        }
      
        public class Item
        {
            public string Id { get; set; }
            public string branchName { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string phoneNumber { get; set; }
            public string Fax { get; set; }
            public string email { get; set; }
            public string LocationCode { get; set; }
            public string image { get; set; }
            public Time Time { get; set; }
            public Address Address { get; set; }

        }

        public class RootObject
        {
            public string borderColor { get; set; }
            public string backGroundColor { get; set; }
            public string TextColor { get; set; }
            public string NewUrl { get; set; }
            public string CalendarUrl { get; set; }
            public string Catalogs { get; set; }
            public string Barcodetype { get; set; }
            public string LibName { get; set; }
            public List<Item> Items { get; set; }
            public string BarcodeStar { get; set; } = String.Empty;
            public string BarcodeEnd { get; set; } = String.Empty;
            public bool CharAllowed { get; set; } = false;




            public Color tobackgroundColor()
            {
                return Color.FromHex(backGroundColor);
            }
            public Color toTextColor()
            {
                return Color.FromHex(TextColor);
            }

        }


    }
}
