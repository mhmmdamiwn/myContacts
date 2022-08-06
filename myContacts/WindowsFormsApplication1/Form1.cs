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
    public partial class Form1 : Form
    {
        IContactRepository Repository;
        public int contactID=0;
        public Form1()
        {
            InitializeComponent();
            Repository = new ContactRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            dgContacts.DataSource = Repository.SelectAll();
            dgContacts.Columns[0].Visible = false;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddorEdit frm = new AddorEdit();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDeletee_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure of deleting this person?", "warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    contactID = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    Repository.Delete(contactID);
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("Choose the Row you wanna delete first!", "warning", MessageBoxButtons.OK);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow != null)
            {
                AddorEdit frm = new AddorEdit();
                contactID = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                frm.contactID = contactID;
                frm.ShowDialog();
                BindGrid();
                

            }
            else
            {
                MessageBox.Show("Choose the Row you wanna Edit first!", "warning", MessageBoxButtons.OK);
            }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgContacts.DataSource= Repository.Search(textBox1.Text);

        }
    }
}
