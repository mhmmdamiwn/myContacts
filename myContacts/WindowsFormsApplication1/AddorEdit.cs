using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class AddorEdit : Form
    {
        public int contactID = 0;
        IContactRepository repository;
        public AddorEdit()
        {
            InitializeComponent();
            repository = new ContactRepository();
        }

        private void AddorEdit_Load(object sender, EventArgs e)
        {
            if (contactID == 0)
            {
                this.Text = "Add";
            }
            else
            {
                this.Text = "Edit";
                DataTable dt = repository.SelectRow(contactID);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtAge.Value = int.Parse(dt.Rows[0][3].ToString());
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtPhonenumber.Text = dt.Rows[0][5].ToString();
            }
        }
        bool isValid()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("please enter the Name", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtFamily.Text == "")
            {
                MessageBox.Show("please enter the Family name", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((int)txtAge.Value <=0)
            {
                MessageBox.Show("please enter the Age", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPhonenumber.Text == "")
            {
                MessageBox.Show("please enter the Phonenumber", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("please enter the Email", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                bool isSucceed;

                if (contactID == 0)
                {
                    isSucceed=repository.Insert(txtName.Text, txtFamily.Text, txtEmail.Text, (int)txtAge.Value, txtPhonenumber.Text);
                }
                else
                {
                    isSucceed = repository.Update(contactID, txtName.Text, txtFamily.Text, txtEmail.Text, (int)txtAge.Value, txtPhonenumber.Text);
                }
                if (isSucceed == true)
                {
                    MessageBox.Show("Progress Succeed", "New User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("Progress Failed", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
