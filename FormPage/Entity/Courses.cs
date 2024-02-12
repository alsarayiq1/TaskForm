using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormPage.Entity
{
    public class Courses
    {
        [Key] public int Id { get; set; }   
        public string? CoursesType { get; set; }
        public DateTime StartedDate { get; set; }
        public DateTime FinishDate { get; }
        [ForeignKey("PersonInfoId")]
        public int PersonInfoId { get; set; }
        public PersonInfo PersonInfo { get; set; }
    }
}
