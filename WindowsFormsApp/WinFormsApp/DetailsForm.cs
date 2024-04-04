using System.Data;
using WinFormsApp.Repositories;

namespace WinFormsApp
{
    public partial class DetailsForm : Form
    {
        private StudentRepo studentRepo;
        private ClassRepo classRepo;
        public DetailsForm(Guid studentId)
        {
            InitializeComponent();
            studentRepo = new StudentRepo();
            classRepo = new ClassRepo();

            var student = studentRepo.Get(studentId);
            var className = classRepo.Get().Where(x => x.Id == student.ClassId).FirstOrDefault().Name;
            string gender = student.Gender == 1 ? "Male" : "Female";

            label8.Text = student.Id.ToString();
            label9.Text = student.Name;
            label10.Text = gender;
            label11.Text = student.DOB.ToString("dd-MM-yyyy");
            label12.Text = className;
            label13.Text = student.CreatedDate?.ToString("dd-MM-yyyy");
            label14.Text = student.ModificationDate == null ? "N/A" : student.ModificationDate?.ToString("dd-MM-yyyy");
        }

        private void DetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MainForm)
                {
                    form.Show();
                    break;
                }
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {
            //nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
