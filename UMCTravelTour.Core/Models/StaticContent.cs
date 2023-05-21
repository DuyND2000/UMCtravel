using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UMCTravelTour.Core.Models
{
    public class StaticContent
    {
        [Key]
        [MaxLength(2)]
        public string LanguageCode { get; set; }
        //Navigation
        public string NavigationHome { get; set; } = "HOME";
        public string NavigationExplore { get; set; } = "EXPLORE";
        public string NavigationTour { get; set; } = "TOUR";
        public string NavigationTourDesign { get; set; } = "TOUR DESIGN";
        public string NavigationHotel { get; set; } = "HOTEL";
        public string NavigationDestination { get; set; } = "DESTINATION";
        public string NavigationRestaurant { get; set; } = "RESTAURANT";
        public string NavigationAbout { get; set; } = "ABOUT";
        public string NavigationAboutTermsAndConditions { get; set; } = "TERMS & CONDITIONS";
        public string NavigationAboutPrivacyPolicy { get; set; } = "PRIVACY POLICY";
        public string NavigationContact { get; set; } = "CONTACT";
        public string NavigationLogin { get; set; } = "LOGIN";
        public string NavigationFacebookLink { get; set; } = "#your-link";
        public string NavigationTwitterLink { get; set; } = "#your-link";

        //Header home
        public string GreatWord { get; set; } = "TRAVEL";
        public string DynamicWord1 { get; set; } = "NOW";
        public string DynamicWord2 { get; set; } = "ALWAYS";
        public string DynamicWord3 { get; set; } = "WITH YOU";
        public string Quote { get; set; } = "A journey of a thousand miles begins with a single step";
        public string QuoteAuthor { get; set; } = "Lao Tzu";

        //Footer
        public string FooterDescriptionTitle { get; set; } = "Few word about us";
        public string FooterDescription { get; set; } = "Description placeholder";
        public string FooterLink { get; set; } = "#your-link";
        public string FooterLinkText { get; set; } = "DreamTour";
        public string FooterTermsAndConditions { get; set; } = "Terms & Conditions";
        public string FooterPrivacyPolicy { get; set; } = "Privacy Policy";
        public string FooterTool1Link { get; set; } = "#your-link";
        public string FooterTool1Text { get; set; } = "Footer Tool #1";
        public string FooterTool2Link { get; set; } = "#your-link";
        public string FooterTool2Text { get; set; } = "Footer Tool #2";
        public string FooterTool3Link { get; set; } = "#your-link";
        public string FooterTool3Text { get; set; } = "Footer Tool #3";
        public string FooterAffiliate1Link { get; set; } = "#your-link";
        public string FooterAffiliate1Text { get; set; } = "Footer Affiliated #1";
        public string FooterAffiliate2Link { get; set; } = "#your-link";
        public string FooterAffiliate2Text { get; set; } = "Footer Affiliated #2";
        public string FooterAffiliate3Link { get; set; } = "#your-link";
        public string FooterAffiliate3Text { get; set; } = "Footer Affiliated #3";
        public string FooterCopyright { get; set; } = "Copyright © 2023";
        public string NameOfTravel { get; set; } = "UMC Travel";
    }
}
