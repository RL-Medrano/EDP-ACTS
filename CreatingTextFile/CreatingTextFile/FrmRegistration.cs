using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreatingTextFile
{
    public partial class FrmRegistration : Form
    {
        public FrmRegistration()
        {
            InitializeComponent();
            string[] programs = {
                "BS Information Technology",
                "BS Information System",
                "BS Computer Engineering",
                "BS Computer Science"
            };
            foreach (string program in programs)
            {
                cbProgram.Items.Add(program);
            }

            string[] gender = {
                "Male",
                "Female"
            };
            foreach (string genders in gender)
            {
                cbGender.Items.Add(genders);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string StudentNumber = txtStudentNumber.Text;
            string LastName = txtLastName.Text;
            string Age = txtAge.Text;
            string Programs = cbProgram.Text;
            string FirstName = txtFirstName.Text;
            string MiddleInitial = txtMiddleInitial.Text;
            string ContactNumber = txtContactNumber.Text;
            string Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
            string Gender = cbGender.Text;

            FrmFileName frm = new FrmFileName();
            frm.ShowDialog();

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, FrmFileName.SetFileName)))
            {
                string[] StudInfo = {
                    "Student No.: " + StudentNumber,
                    "Full Name: " + LastName + ", " + FirstName + " " + MiddleInitial,
                    "Program: " + Birthday,
                    "Gender: " + Gender,
                    "Age :" + Age,
                    "Birthday :" + Birthday,
                    "Contact No. :" + ContactNumber
                };
                foreach (string students in StudInfo)
                {
                    outputFile.WriteLine(students);
                }
            }
        }
    }
}
