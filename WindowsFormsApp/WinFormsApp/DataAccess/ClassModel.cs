using System.ComponentModel.DataAnnotations;

namespace WinFormsApp.DataAccess
{
    public class ClassModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModificationDate { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
