﻿using Stx.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stx.Shared.Services
{
    public static class StaticDataService
    {
        public class Country
        {
            public static List<CountryMin> Countries()
            {
                return new List<CountryMin> {
                    new CountryMin (4,"Afghanistan"),
                    new CountryMin (8,"Albania"),
                    new CountryMin (10,"Antarctica"),
                    new CountryMin (12,"Algeria"),
                    new CountryMin (16,"American Samoa"),
                    new CountryMin (20,"Andorra"),
                    new CountryMin (24,"Angola"),
                    new CountryMin (28,"Antigua and Barbuda"),
                    new CountryMin (31,"Azerbaijan"),
                    new CountryMin (32,"Argentina"),
                    new CountryMin (36,"Australia"),
                    new CountryMin (40,"Austria"),
                    new CountryMin (44,"Bahamas"),
                    new CountryMin (48,"Bahrain"),
                    new CountryMin (50,"Bangladesh"),
                    new CountryMin (51,"Armenia"),
                    new CountryMin (52,"Barbados"),
                    new CountryMin (56,"Belgium"),
                    new CountryMin (60,"Bermuda"),
                    new CountryMin (64,"Bhutan"),
                    new CountryMin (68,"Bolivia"),
                    new CountryMin (70,"Bosnia and Herzegovina"),
                    new CountryMin (72,"Botswana"),
                    new CountryMin (74,"Bouvet Island"),
                    new CountryMin (76,"Brazil"),
                    new CountryMin (84,"Belize"),
                    new CountryMin (86,"British Indian Ocean Territory"),
                    new CountryMin (90,"Solomon Islands"),
                    new CountryMin (92,"Virgin Islands (British)"),
                    new CountryMin (96,"Brunei Darussalam"),
                    new CountryMin (100,"Bulgaria"),
                    new CountryMin (104,"Myanmar"),
                    new CountryMin (108,"Burundi"),
                    new CountryMin (112,"Belarus"),
                    new CountryMin (116,"Cambodia"),
                    new CountryMin (120,"Cameroon"),
                    new CountryMin (124,"Canada"),
                    new CountryMin (132,"Cabo Verde"),
                    new CountryMin (136,"Cayman Islands"),
                    new CountryMin (140,"Central African Republic"),
                    new CountryMin (144,"Sri Lanka"),
                    new CountryMin (148,"Chad"),
                    new CountryMin (152,"Chile"),
                    new CountryMin (156,"China"),
                    new CountryMin (158,"Taiwan (Province of China)"),
                    new CountryMin (162,"Christmas Island"),
                    new CountryMin (166,"Cocos (Keeling) Islands"),
                    new CountryMin (170,"Colombia"),
                    new CountryMin (174,"Comoros"),
                    new CountryMin (175,"Mayotte"),
                    new CountryMin (178,"Congo"),
                    new CountryMin (180,"Congo (the Democratic Republic of the)"),
                    new CountryMin (184,"Cook Islands"),
                    new CountryMin (188,"Costa Rica"),
                    new CountryMin (191,"Croatia"),
                    new CountryMin (192,"Cuba"),
                    new CountryMin (196,"Cyprus"),
                    new CountryMin (203,"Czechia"),
                    new CountryMin (204,"Benin"),
                    new CountryMin (208,"Denmark"),
                    new CountryMin (212,"Dominica"),
                    new CountryMin (214,"Dominican Republic"),
                    new CountryMin (218,"Ecuador"),
                    new CountryMin (222,"El Salvador"),
                    new CountryMin (226,"Equatorial Guinea"),
                    new CountryMin (231,"Ethiopia"),
                    new CountryMin (232,"Eritrea"),
                    new CountryMin (233,"Estonia"),
                    new CountryMin (234,"Faroe Islands"),
                    new CountryMin (238,"Falkland Islands [Malvinas]"),
                    new CountryMin (239,"South Georgia and the South Sandwich Islands"),
                    new CountryMin (242,"Fiji"),
                    new CountryMin (246,"Finland"),
                    new CountryMin (248,"Åland Islands"),
                    new CountryMin (250,"France"),
                    new CountryMin (254,"French Guiana"),
                    new CountryMin (258,"French Polynesia"),
                    new CountryMin (260,"French Southern Territories"),
                    new CountryMin (262,"Djibouti"),
                    new CountryMin (266,"Gabon"),
                    new CountryMin (268,"Georgia"),
                    new CountryMin (270,"Gambia"),
                    new CountryMin (275,"Palestine, State of"),
                    new CountryMin (276,"Germany"),
                    new CountryMin (288,"Ghana"),
                    new CountryMin (292,"Gibraltar"),
                    new CountryMin (296,"Kiribati"),
                    new CountryMin (300,"Greece"),
                    new CountryMin (304,"Greenland"),
                    new CountryMin (308,"Grenada"),
                    new CountryMin (312,"Guadeloupe"),
                    new CountryMin (316,"Guam"),
                    new CountryMin (320,"Guatemala"),
                    new CountryMin (324,"Guinea"),
                    new CountryMin (328,"Guyana"),
                    new CountryMin (332,"Haiti"),
                    new CountryMin (334,"Heard Island and McDonald Islands"),
                    new CountryMin (336,"Holy See"),
                    new CountryMin (340,"Honduras"),
                    new CountryMin (344,"Hong Kong"),
                    new CountryMin (348,"Hungary"),
                    new CountryMin (352,"Iceland"),
                    new CountryMin (356,"India"),
                    new CountryMin (360,"Indonesia"),
                    new CountryMin (364,"Iran (Islamic Republic of)"),
                    new CountryMin (368,"Iraq"),
                    new CountryMin (372,"Ireland"),
                    new CountryMin (376,"Israel"),
                    new CountryMin (380,"Italy"),
                    new CountryMin (384,"Côte d'Ivoire"),
                    new CountryMin (388,"Jamaica"),
                    new CountryMin (392,"Japan"),
                    new CountryMin (398,"Kazakhstan"),
                    new CountryMin (400,"Jordan"),
                    new CountryMin (404,"Kenya"),
                    new CountryMin (408,"Korea (the Democratic People's Republic of)"),
                    new CountryMin (410,"Korea (the Republic of)"),
                    new CountryMin (414,"Kuwait"),
                    new CountryMin (417,"Kyrgyzstan"),
                    new CountryMin (418,"Lao People's Democratic Republic"),
                    new CountryMin (422,"Lebanon"),
                    new CountryMin (426,"Lesotho"),
                    new CountryMin (428,"Latvia"),
                    new CountryMin (430,"Liberia"),
                    new CountryMin (434,"Libya"),
                    new CountryMin (438,"Liechtenstein"),
                    new CountryMin (440,"Lithuania"),
                    new CountryMin (442,"Luxembourg"),
                    new CountryMin (446,"Macao"),
                    new CountryMin (450,"Madagascar"),
                    new CountryMin (454,"Malawi"),
                    new CountryMin (458,"Malaysia"),
                    new CountryMin (462,"Maldives"),
                    new CountryMin (466,"Mali"),
                    new CountryMin (470,"Malta"),
                    new CountryMin (474,"Martinique"),
                    new CountryMin (478,"Mauritania"),
                    new CountryMin (480,"Mauritius"),
                    new CountryMin (484,"Mexico"),
                    new CountryMin (492,"Monaco"),
                    new CountryMin (496,"Mongolia"),
                    new CountryMin (498,"Moldova (the Republic of)"),
                    new CountryMin (499,"Montenegro"),
                    new CountryMin (500,"Montserrat"),
                    new CountryMin (504,"Morocco"),
                    new CountryMin (508,"Mozambique"),
                    new CountryMin (512,"Oman"),
                    new CountryMin (516,"Namibia"),
                    new CountryMin (520,"Nauru"),
                    new CountryMin (524,"Nepal"),
                    new CountryMin (528,"Netherlands"),
                    new CountryMin (531,"Curaçao"),
                    new CountryMin (533,"Aruba"),
                    new CountryMin (534,"Sint Maarten (Dutch part)"),
                    new CountryMin (535,"Bonaire, Sint Eustatius and Saba"),
                    new CountryMin (540,"New Caledonia"),
                    new CountryMin (548,"Vanuatu"),
                    new CountryMin (554,"New Zealand"),
                    new CountryMin (558,"Nicaragua"),
                    new CountryMin (562,"Niger"),
                    new CountryMin (566,"Nigeria"),
                    new CountryMin (570,"Niue"),
                    new CountryMin (574,"Norfolk Island"),
                    new CountryMin (578,"Norway"),
                    new CountryMin (580,"Northern Mariana Islands"),
                    new CountryMin (581,"United States Minor Outlying Islands"),
                    new CountryMin (583,"Micronesia (Federated States of)"),
                    new CountryMin (584,"Marshall Islands"),
                    new CountryMin (585,"Palau"),
                    new CountryMin (586,"Pakistan"),
                    new CountryMin (591,"Panama"),
                    new CountryMin (598,"Papua New Guinea"),
                    new CountryMin (600,"Paraguay"),
                    new CountryMin (604,"Peru"),
                    new CountryMin (608,"Philippines"),
                    new CountryMin (612,"Pitcairn"),
                    new CountryMin (616,"Poland"),
                    new CountryMin (620,"Portugal"),
                    new CountryMin (624,"Guinea-Bissau"),
                    new CountryMin (626,"Timor-Leste"),
                    new CountryMin (630,"Puerto Rico"),
                    new CountryMin (634,"Qatar"),
                    new CountryMin (638,"Réunion"),
                    new CountryMin (642,"Romania"),
                    new CountryMin (643,"Russian Federation"),
                    new CountryMin (646,"Rwanda"),
                    new CountryMin (652,"Saint Barthélemy"),
                    new CountryMin (654,"Saint Helena, Ascension and Tristan da Cunha"),
                    new CountryMin (659,"Saint Kitts and Nevis"),
                    new CountryMin (660,"Anguilla"),
                    new CountryMin (662,"Saint Lucia"),
                    new CountryMin (663,"Saint Martin (French part)"),
                    new CountryMin (666,"Saint Pierre and Miquelon"),
                    new CountryMin (670,"Saint Vincent and the Grenadines"),
                    new CountryMin (674,"San Marino"),
                    new CountryMin (678,"Sao Tome and Principe"),
                    new CountryMin (682,"Saudi Arabia"),
                    new CountryMin (686,"Senegal"),
                    new CountryMin (688,"Serbia"),
                    new CountryMin (690,"Seychelles"),
                    new CountryMin (694,"Sierra Leone"),
                    new CountryMin (702,"Singapore"),
                    new CountryMin (703,"Slovakia"),
                    new CountryMin (704,"Viet Nam"),
                    new CountryMin (705,"Slovenia"),
                    new CountryMin (706,"Somalia"),
                    new CountryMin (710,"South Africa"),
                    new CountryMin (716,"Zimbabwe"),
                    new CountryMin (724,"Spain"),
                    new CountryMin (728,"South Sudan"),
                    new CountryMin (729,"Sudan"),
                    new CountryMin (732,"Western Sahara"),
                    new CountryMin (740,"Suriname"),
                    new CountryMin (744,"Svalbard and Jan Mayen"),
                    new CountryMin (748,"Eswatini"),
                    new CountryMin (752,"Sweden"),
                    new CountryMin (756,"Switzerland"),
                    new CountryMin (760,"Syrian Arab Republic"),
                    new CountryMin (762,"Tajikistan"),
                    new CountryMin (764,"Thailand"),
                    new CountryMin (768,"Togo"),
                    new CountryMin (772,"Tokelau"),
                    new CountryMin (776,"Tonga"),
                    new CountryMin (780,"Trinidad and Tobago"),
                    new CountryMin (784,"United Arab Emirates"),
                    new CountryMin (788,"Tunisia"),
                    new CountryMin (792,"Turkey"),
                    new CountryMin (795,"Turkmenistan"),
                    new CountryMin (796,"Turks and Caicos Islands"),
                    new CountryMin (798,"Tuvalu"),
                    new CountryMin (800,"Uganda"),
                    new CountryMin (804,"Ukraine"),
                    new CountryMin (807,"Republic of North Macedonia"),
                    new CountryMin (818,"Egypt"),
                    new CountryMin (826,"United Kingdom"),
                    new CountryMin (831,"Guernsey"),
                    new CountryMin (832,"Jersey"),
                    new CountryMin (833,"Isle of Man"),
                    new CountryMin (834,"Tanzania, United Republic of"),
                    new CountryMin (840,"United States of America"),
                    new CountryMin (850,"Virgin Islands (U.S.)"),
                    new CountryMin (854,"Burkina Faso"),
                    new CountryMin (858,"Uruguay"),
                    new CountryMin (860,"Uzbekistan"),
                    new CountryMin (862,"Venezuela (Bolivarian Republic of)"),
                    new CountryMin (876,"Wallis and Futuna"),
                    new CountryMin (882,"Samoa"),
                    new CountryMin (887,"Yemen"),
                    new CountryMin (894,"Zambia"),
                };
            }

            static CountryMin GetCareerLevel(short id)
            {
                return Countries().Where(x => x.CountryID == id).FirstOrDefault();
            }
            //static List<short> GetSelected()
            //{
            //    return Countries.Where(x => x.IsSelected).Select(x => x.ID).ToList();
            //}
            //static string GetSelectedCommaSeparated()
            //{
            //    return string.Join(",", GetSelected());
            //}
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

