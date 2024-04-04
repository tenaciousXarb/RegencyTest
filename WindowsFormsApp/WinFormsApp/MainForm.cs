using System.Data;
using WinFormsApp.Repositories;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private StudentRepo studentRepo;
        private ClassRepo classRepo;
        public MainForm()
        {
            Initialization();
            InitializeComponent();
        }

        private void Initialization()
        {
            studentRepo = new StudentRepo();
            classRepo = new ClassRepo();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //nothing
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            string grade = dataGridView1.Rows[e.RowIndex].Cells["ClassName"].Value.ToString();

            var cid = classRepo.Get().Where(e => e.Name == grade).FirstOrDefault().Id;
            var student = studentRepo.Get().Where(e => e.Name == name & e.ClassId == cid).FirstOrDefault();
            Hide();

            // Check if the clicked cell is in the button column
            if (e.ColumnIndex == dataGridView1.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                EditForm editForm = new EditForm(student.Id);
                editForm.Show();
            }

            if (e.ColumnIndex == dataGridView1.Columns["DetailsButton"].Index && e.RowIndex >= 0)
            {
                DetailsForm detailsForm = new DetailsForm(student.Id);
                detailsForm.Show();
            }

            if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                DeleteForm deleteForm = new DeleteForm(student.Id);
                deleteForm.Show();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            Hide();
            addForm.Show();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            ResetDataGrid();
            Initialization();
            var students = studentRepo.Get();

            // Add columns to DataGridView
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("ClassName", "Class");
            dataGridView1.Columns.Add("DOB", "Date of Birth");
            dataGridView1.Columns.Add("Gender", "Gender");


            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.HeaderText = "";
            buttonColumn.Name = "EditButton";
            buttonColumn.Text = "Edit";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);


            DataGridViewButtonColumn buttonColumn2 = new DataGridViewButtonColumn();
            buttonColumn2.HeaderText = "Action";
            buttonColumn2.Name = "DetailsButton";
            buttonColumn2.Text = "Details";
            buttonColumn2.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn2);


            DataGridViewButtonColumn buttonColumn3 = new DataGridViewButtonColumn();
            buttonColumn3.HeaderText = "";
            buttonColumn3.Name = "DeleteButton";
            buttonColumn3.Text = "Delete";
            buttonColumn3.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn3);


            foreach (var student in students)
            {
                var studentClass = classRepo.Get(student.ClassId);
                var className = studentClass == null ? string.Empty : studentClass.Name;

                var gender = student.Gender == 1 ? "Male" : "Female";

                dataGridView1.Rows.Add(student.Name, className, student.DOB.ToString("dd-MM-yyyy"), gender);
            }
        }

        private void ResetDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }
    }
}
