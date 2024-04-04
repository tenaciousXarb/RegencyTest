using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsApp.DataAccess
{
    public class StudentModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Gender { get; set; }

        public DateTime DOB { get; set; }

        public int ClassId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        [ForeignKey("ClassId")]
        public ClassModel ClassModel { get; set; }
    }
}
