using System.ComponentModel;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormPage.Entity
{
    public class PersonInfo
    {
        public int PersonInfoId { get; set; }
        [Description("الاسم الاول")]
        public string FirstName { get; set; }
        [Description("الاسم الثاني ")]
        public string LastName { get; set; }
        [Description("الاسم الثالث")]
        public string? ThirdName { get; set; }
        [Description(" اللقب")]
        public string SurName { get; set; }
        [Description("المواليد")]
        public DateTime BirthDate { get; set; }
        [Description("رقم الهاتف")]
        public string? PhonNum { get; set; }
        [Description("القومية")]
        public string? Nationalism { get; set; }
        [Description("الديانة")]
        public string? Religion { get; set; }

        public ICollection<Courses> Courses { get; set; }
        public ICollection<Experience> Experience { get; set; }
    }
}
