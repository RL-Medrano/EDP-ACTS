using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace infoRecords
{
    public partial class PersonalInfo : Form
    {
        string recordconn = "Server = localhost\\SQLEXPRESS;initial Catalog=dbRecords;Trusted_Connection=true;";
        public PersonalInfo()
        {
            InitializeComponent();
        }
        private void checklist()
        {
            lvRecords.Items.Clear();
            using (SqlConnection sqlcon = new SqlConnection(recordconn))
            {
                sqlcon.Open();
                using (SqlCommand sqlcon2 = new SqlCommand("SELECT* FROM tbliRecords", sqlcon))
                {
                    {
                        SqlDataReader reader = sqlcon2.ExecuteReader();
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader.GetInt32(0).ToString());
                            item.SubItems.Add(reader.GetString(1));
                            item.SubItems.Add(reader.GetString(2));
                            item.SubItems.Add(reader.GetString(3).ToString());
                            item.SubItems.Add(reader.GetString(4));
                            lvRecords.Items.Add(item);
                        }

                    }
                }
            }
        }
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            using(SqlConnection cnt1 = new SqlConnection(recordconn))
            {
                cnt1.Open();
                using (SqlCommand sqlcon1 = new SqlCommand("INSERT INTO tbliRecords(FirstName, LastName, Age, Address) VALUES ('" + txtFirstName.Text + "','" + txtLastName.Text + "','" + Convert.ToInt32(txtAge.Text) + "','" + txtAddress.Text + "')", cnt1))
                {
                    sqlcon1.ExecuteNonQuery();
                    MessageBox.Show("Recorded Successfully");
                    checklist();
                    clearList();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using(SqlConnection cnt2 = new SqlConnection(recordconn))
            {
                cnt2.Open();
                using (SqlCommand sqlcon2 = new SqlCommand("UPDATE tbliRecords SET FirstName ='"+txtFirstName.Text+"' ,LastName = '"+txtLastName.Text +"',Age ='" +Convert.ToInt32(txtAge.Text)+"',Address ='"+txtAddress.Text+ "' WHERE ID = " + lblID.Text, cnt2))
                {
                    sqlcon2.ExecuteNonQuery();
                    MessageBox.Show("Updated Successfully");
                    checklist();
                    clearList();
                }
            }
        }
        private void btnDeleteItems_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(recordconn))
            {
                sqlcon.Open();
                using (SqlCommand sqlcon2 = new SqlCommand( "DELETE FROM tbliRecords WHERE ID = " +lblID.Text, sqlcon))
                {
                    sqlcon2.ExecuteNonQuery();
                    MessageBox.Show("Deleted Successfully");
                    checklist();
                    clearList();
                }
            }
        }
        private void clearList()
        {
            lblID.Text = "";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtAddress.Clear();
        }
        private void lvRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvRecords.SelectedItems.Count > 0)
            {
                lblID.Text = lvRecords.SelectedItems[0].SubItems[0].Text;
                txtFirstName.Text = lvRecords.SelectedItems[0].SubItems[1].Text;
                txtLastName.Text = lvRecords.SelectedItems[0].SubItems[2].Text;
                txtAge.Text = lvRecords.SelectedItems[0].SubItems[3].Text;
                txtAddress.Text = lvRecords.SelectedItems[0].SubItems[4].Text; 
            }
            else
            {
                clearList();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PersonalInfo_Load(object sender, EventArgs e)
        {
            checklist();
        }
    }
}
