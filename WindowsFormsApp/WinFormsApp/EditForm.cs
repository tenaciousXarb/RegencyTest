using WinFormsApp.DataAccess;
using WinFormsApp.Repositories;

namespace WinFormsApp
{
    public partial class EditForm : Form
    {
        private StudentRepo studentRepo;
        private ClassRepo classRepo;
        private Guid sid;
        private DateTime selectedDate;
        public EditForm(Guid studentId)
        {
            sid = studentId;
            InitializeComponent();

            studentRepo = new StudentRepo();
            classRepo = new ClassRepo();

            var classes = classRepo.Get();


            var student = studentRepo.Get(studentId);

            foreach (var cls in classes)
            {
                comboBox1.Items.Add(cls);
            }


            comboBox1.SelectedItem = classRepo.Get(student.ClassId);

            if (student.Gender == 1)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            textBox1.Text = student.Name;

            monthCalendar1.SelectionStart = student.DOB;
            selectedDate = student.DOB;
        }

        private void EditForm_FormClosed(object sender, FormClosedEventArgs e)
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
            var studentModel = studentRepo.Get(sid);

            ClassModel selectedClass = (ClassModel)comboBox1.SelectedItem;

            studentModel.Name = textBox1.Text;
            studentModel.ClassId = selectedClass.Id;
            studentModel.DOB = selectedDate;
            studentModel.Gender = radioButton1.Checked ? 1 : 2;
            studentModel.ModificationDate = DateTime.Now;

            var updated = studentRepo.Update(studentModel);
            if (updated)
            {
                MessageBox.Show("Student profile updated successfully!");
            }
            else
            {
                MessageBox.Show("Student profile could not be updated!");
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

        private void monthCalendar1_Leave(object sender, EventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart;
        }

        private void monthCalendar1_Enter(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = selectedDate;
        }
    }
}
