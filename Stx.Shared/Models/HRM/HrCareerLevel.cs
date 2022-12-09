using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Stx.Shared.Models.HRM
{
    public class HrCareerLevel
    {
        public HrCareerLevel()
        {

        }

        public HrCareerLevel(short id, string careerLevel)
        {
            ID = id;
            CareerLevel = careerLevel;
        }

        [NotMapped]
        public bool IsSelected { get; set; }
        public short ID { get; set; }
        public string CareerLevel { get; set; }
    }
}
