using Stx.Shared.Models.HRM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stx.DataServices.Hrm
{
    public static class StaticData
    {
        public class EmploymentType
        {
            public static List<Stx.Shared.Models.HRM.HrEmploymentType> EmploymentTypes()
            {
                return new List<Shared.Models.HRM.HrEmploymentType>()
                {
                    new Shared.Models.HRM.HrEmploymentType(10,"Full-time"),
                    new Shared.Models.HRM.HrEmploymentType(20,"Part-time"),
                    new Shared.Models.HRM.HrEmploymentType(30,"Contract"),
                    new Shared.Models.HRM.HrEmploymentType(40,"Intern/Trainee"),
                    new Shared.Models.HRM.HrEmploymentType(50,"Temporary"),
                    new Shared.Models.HRM.HrEmploymentType(60,"Freelancer"),
                    new Shared.Models.HRM.HrEmploymentType(70,"Volunteer"),
                    new Shared.Models.HRM.HrEmploymentType(80,"Remote"),
                };
            }

            public static HrEmploymentType GetCareerLevel(short id)
            {
                return EmploymentTypes().Where(x => x.ID == id).FirstOrDefault();
            }
            public static List<short> GetSelected()
            {
                return EmploymentTypes().Where(x => x.IsSelected).Select(x => x.ID).ToList();
            }
            public static string GetSelectedCommaSeparated()
            {
                return string.Join(",", GetSelected());
            }
        }

        public class CareerLevel
        {
            public static List<Stx.Shared.Models.HRM.HrCareerLevel> CareerLevels()
            {
                return new List<Shared.Models.HRM.HrCareerLevel>() {
                    new Shared.Models.HRM.HrCareerLevel(10,"Senior Executive"),
                    new Shared.Models.HRM.HrCareerLevel(20,"Director"),
                    new Shared.Models.HRM.HrCareerLevel(30,"Executive"),
                    new Shared.Models.HRM.HrCareerLevel(40,"Mid Career"),
                    new Shared.Models.HRM.HrCareerLevel(50,"Associate"),
                    new Shared.Models.HRM.HrCareerLevel(60,"Entry Level"),
                    new Shared.Models.HRM.HrCareerLevel(70,"Internship/Student"),
                    new Shared.Models.HRM.HrCareerLevel(80,"Not applicable"),
                };
            }

            public static HrCareerLevel GetCareerLevel(short id)
            {
                return CareerLevels().Where(x => x.ID == id).FirstOrDefault();
            }
            public static List<short> GetSelected()
            {
                return CareerLevels().Where(x => x.IsSelected).Select(x => x.ID).ToList();
            }
            public static string GetSelectedCommaSeparated()
            {
                return string.Join(",", GetSelected());
            }
        }

        public class CorporateType
        {
            public static List<Stx.Shared.Models.HRM.HrCorporateType> CorporateTypes()
            {
                return new List<Shared.Models.HRM.HrCorporateType>()
                {
                    new Shared.Models.HRM.HrCorporateType(10,"Private Employer"),
                    new Shared.Models.HRM.HrCorporateType(20,"Public Employer"),
                    new Shared.Models.HRM.HrCorporateType(30,"Recruitment Agency"),
                    new Shared.Models.HRM.HrCorporateType(40,"Charity"),
                };
            }

            public static HrCorporateType GetCareerLevel(short id)
            {
                return CorporateTypes().Where(x => x.ID == id).FirstOrDefault();
            }

            public static List<short> GetSelected()
            {
                return CorporateTypes().Where(x => x.IsSelected).Select(x=> x.ID).ToList();
            }
            public static string GetSelectedCommaSeparated()
            {
                return string.Join(",", GetSelected());
            }
        }

        public class SkillProficiency
        {
            public static List<Stx.Shared.Common.ComboShort> SkillProficiencies()
            {
                return new List<Stx.Shared.Common.ComboShort>()
                {
                    new Stx.Shared.Common.ComboShort(0,"None"),
                    new Stx.Shared.Common.ComboShort(1,"Beginner"),
                    new Stx.Shared.Common.ComboShort(2,"Intermediate"),
                    new Stx.Shared.Common.ComboShort(3,"Advanced"),
                    new Stx.Shared.Common.ComboShort(4,"Expert"),
                    new Stx.Shared.Common.ComboShort(5,"Master"),
                };
            }

            public static string GetDesc(short id)
            {
                return SkillProficiencies().Where(x => x.Value == id).FirstOrDefault().Text;
            }            
        }

        #region Commented

        //public static List<SelectListItem> TimeZones = new List<SelectListItem>
        //    {
        //       new SelectListItem { Value="-12",Text ="(GMT-12:00) International Date Line West" },
        //                    new SelectListItem { Value="-11",Text ="(GMT-11:00) Midway Island, Samoa" },
        //                    new SelectListItem { Value="-10",Text ="(GMT-10:00) Hawaii" },
        //                    new SelectListItem { Value="-9",Text ="(GMT-09:00) Alaska" },
        //                    new SelectListItem { Value="-8",Text ="(GMT-08:00) Pacific Time (US & Canada)" },
        //                    new SelectListItem { Value="-8",Text ="(GMT-08:00) Tijuana, Baja California" },
        //                    new SelectListItem { Value="-7",Text ="(GMT-07:00) Arizona" },
        //                    new SelectListItem { Value="-7",Text ="(GMT-07:00) Chihuahua, La Paz, Mazatlan" },
        //                    new SelectListItem { Value="-7",Text ="(GMT-07:00) Mountain Time (US & Canada)" },
        //                    new SelectListItem { Value="-6",Text ="(GMT-06:00) Central America" },
        //                    new SelectListItem { Value="-6",Text ="(GMT-06:00) Central Time (US & Canada)" },
        //                    new SelectListItem { Value="-6",Text ="(GMT-06:00) Guadalajara, Mexico City, Monterrey" },
        //                    new SelectListItem { Value="-6",Text ="(GMT-06:00) Saskatchewan" },
        //                    new SelectListItem { Value="-5",Text ="(GMT-05:00) Bogota, Lima, Quito, Rio Branco" },
        //                    new SelectListItem { Value="-5",Text ="(GMT-05:00) Eastern Time (US & Canada)" },
        //                    new SelectListItem { Value="-5",Text ="(GMT-05:00) Indiana (East)" },
        //                    new SelectListItem { Value="-4",Text ="(GMT-04:00) Atlantic Time (Canada)" },
        //                    new SelectListItem { Value="-4",Text ="(GMT-04:00) Caracas, La Paz" },
        //                    new SelectListItem { Value="-4",Text ="(GMT-04:00) Manaus" },
        //                    new SelectListItem { Value="-4",Text ="(GMT-04:00) Santiago" },
        //                    new SelectListItem { Value="-3.5",Text ="(GMT-03:30) Newfoundland" },
        //                    new SelectListItem { Value="-3",Text ="(GMT-03:00) Brasilia" },
        //                    new SelectListItem { Value="-3",Text ="(GMT-03:00) Buenos Aires, Georgetown" },
        //                    new SelectListItem { Value="-3",Text ="(GMT-03:00) Greenland" },
        //                    new SelectListItem { Value="-3",Text ="(GMT-03:00) Montevideo" },
        //                    new SelectListItem { Value="-2",Text ="(GMT-02:00) Mid-Atlantic" },
        //                    new SelectListItem { Value="-1",Text ="(GMT-01:00) Cape Verde Is." },
        //                    new SelectListItem { Value="-1",Text ="(GMT-01:00) Azores" },
        //                    new SelectListItem { Value="0",Text ="(GMT+00:00) Casablanca, Monrovia, Reykjavik" },
        //                    new SelectListItem { Value="0",Text ="(GMT+00:00) Greenwich Mean Time : Dublin, Edinburgh, Lisbon, London" },
        //                    new SelectListItem { Value="1",Text ="(GMT+01:00) Amsterdam, Berlin, Bern, Rome, Stockholm, Vienna" },
        //                    new SelectListItem { Value="1",Text ="(GMT+01:00) Belgrade, Bratislava, Budapest, Ljubljana, Prague" },
        //                    new SelectListItem { Value="1",Text ="(GMT+01:00) Brussels, Copenhagen, Madrid, Paris" },
        //                    new SelectListItem { Value="1",Text ="(GMT+01:00) Sarajevo, Skopje, Warsaw, Zagreb" },
        //                    new SelectListItem { Value="1",Text ="(GMT+01:00) West Central Africa" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Amman" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Athens, Bucharest, Istanbul" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Beirut" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Cairo" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Harare, Pretoria" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Helsinki, Kyiv, Riga, Sofia, Tallinn, Vilnius" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Jerusalem" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Minsk" },
        //                    new SelectListItem { Value="2",Text ="(GMT+02:00) Windhoek" },
        //                    new SelectListItem { Value="3",Text ="(GMT+03:00) Kuwait, Riyadh, Baghdad" },
        //                    new SelectListItem { Value="3",Text ="(GMT+03:00) Moscow, St. Petersburg, Volgograd" },
        //                    new SelectListItem { Value="3",Text ="(GMT+03:00) Nairobi" },
        //                    new SelectListItem { Value="3",Text ="(GMT+03:00) Tbilisi" },
        //                    new SelectListItem { Value="3.5",Text ="(GMT+03:30) Tehran" },
        //                    new SelectListItem { Value="4",Text ="(GMT+04:00) Abu Dhabi, Muscat" },
        //                    new SelectListItem { Value="4",Text ="(GMT+04:00) Baku" },
        //                    new SelectListItem { Value="4",Text ="(GMT+04:00) Yerevan" },
        //                    new SelectListItem { Value="4.5",Text ="(GMT+04:30) Kabul" },
        //                    new SelectListItem { Value="5",Text ="(GMT+05:00) Yekaterinburg" },
        //                    new SelectListItem { Value="5",Text ="(GMT+05:00) Islamabad, Karachi, Tashkent" },
        //                    new SelectListItem { Value="5.5",Text ="(GMT+05:30) Sri Jayawardenapura" },
        //                    new SelectListItem { Value="5.5",Text ="(GMT+05:30) Chennai, Kolkata, Mumbai, New Delhi" },
        //                    new SelectListItem { Value="5.75",Text ="(GMT+05:45) Kathmandu" },
        //                    new SelectListItem { Value="6",Text ="(GMT+06:00) Almaty, Novosibirsk" },
        //                    new SelectListItem { Value="6",Text ="(GMT+06:00) Astana, Dhaka" },
        //                    new SelectListItem { Value="6.5",Text ="(GMT+06:30) Yangon (Rangoon)" },
        //                    new SelectListItem { Value="7",Text ="(GMT+07:00) Bangkok, Hanoi, Jakarta" },
        //                    new SelectListItem { Value="7",Text ="(GMT+07:00) Krasnoyarsk" },
        //                    new SelectListItem { Value="8",Text ="(GMT+08:00) Beijing, Chongqing, Hong Kong, Urumqi" },
        //                    new SelectListItem { Value="8",Text ="(GMT+08:00) Kuala Lumpur, Singapore" },
        //                    new SelectListItem { Value="8",Text ="(GMT+08:00) Irkutsk, Ulaan Bataar" },
        //                    new SelectListItem { Value="8",Text ="(GMT+08:00) Perth" },
        //                    new SelectListItem { Value="8",Text ="(GMT+08:00) Taipei" },
        //                    new SelectListItem { Value="9",Text ="(GMT+09:00) Osaka, Sapporo, Tokyo" },
        //                    new SelectListItem { Value="9",Text ="(GMT+09:00) Seoul" },
        //                    new SelectListItem { Value="9",Text ="(GMT+09:00) Yakutsk" },
        //                    new SelectListItem { Value="9.5",Text ="(GMT+09:30) Adelaide" },
        //                    new SelectListItem { Value="9.5",Text ="(GMT+09:30) Darwin" },
        //                    new SelectListItem { Value="10",Text ="(GMT+10:00) Brisbane" },
        //                    new SelectListItem { Value="10",Text ="(GMT+10:00) Canberra, Melbourne, Sydney" },
        //                    new SelectListItem { Value="10",Text ="(GMT+10:00) Hobart" },
        //                    new SelectListItem { Value="10",Text ="(GMT+10:00) Guam, Port Moresby" },
        //                    new SelectListItem { Value="10",Text ="(GMT+10:00) Vladivostok" },
        //                    new SelectListItem { Value="11",Text ="(GMT+11:00) Magadan, Solomon Is., New Caledonia" },
        //                    new SelectListItem { Value="12",Text ="(GMT+12:00) Auckland, Wellington" },
        //                    new SelectListItem { Value="12",Text ="(GMT+12:00) Fiji, Kamchatka, Marshall Is." },
        //                    new SelectListItem { Value="13",Text ="(GMT+13:00) Nuku'alofa" }
        //    };
        //public struct Messages
        //{
        //    public static string SuccessMessage = "Save successful";
        //    public static string ErrorMessage = "Error occured ";
        //}
        #endregion


    }
}
