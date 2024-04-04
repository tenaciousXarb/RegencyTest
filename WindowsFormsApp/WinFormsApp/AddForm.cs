using WinFormsApp.DataAccess;
using WinFormsApp.Repositories;

namespace WinFormsApp
{
    public partial class AddForm : Form
    {
        private ClassRepo classRepo;
        private StudentRepo studentRepo;
        private DateTime selectedDate;

        public AddForm()
        {
            InitializeComponent();
            studentRepo = new StudentRepo();
            classRepo = new ClassRepo();
            var classes = classRepo.Get();

            foreach (var cls in classes)
            {
                clsComboBox.Items.Add(cls);
            }
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            StudentModel studentModel = new StudentModel();
            ClassModel selectedClass = (ClassModel)clsComboBox.SelectedItem;


            studentModel.Name = textBox1.Text;
            studentModel.ClassId = selectedClass.Id;
            studentModel.DOB = selectedDate;
            studentModel.Gender = radioButton1.Checked ? 1 : 2;
            studentModel.CreatedDate = DateTime.Now;



            var addedModel = studentRepo.Add(studentModel);
            if (addedModel != null)
            {
                MessageBox.Show("Student profile added successfully!");
            }
            else
            {
                MessageBox.Show("Student profile could not be added!");
            }
            Close();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
