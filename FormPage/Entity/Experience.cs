using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormPage.Entity
{
    public class Experience
    {

        [Key] public int Id { get; set; }

        public string ExpType { get; set; }
       
        public string Appreciation { get; set; }
        [ForeignKey("PersonInfoId")]

        public int PersonInfoId { get; set; }

        public PersonInfo PersonInfo { get; set; }

    }
}
