using WinFormsApp.Repositories;

namespace WinFormsApp
{
    public partial class DeleteForm : Form
    {
        private StudentRepo studentRepo;
        private Guid sid;
        public DeleteForm(Guid studentId)
        {
            InitializeComponent();

            studentRepo = new StudentRepo();
            var student = studentRepo.Get(studentId);
            sid = student.Id;
            label1.Text = $"Are you sure to delete the profile of {student.Name} (ID: {sid})?";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var student = studentRepo.Get(sid);
            if (studentRepo.Delete(sid))
            {
                MessageBox.Show($"Student profile ({student.Name}) successfully deleted!");
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
