using BusinessLayer;
using System;
using System.Windows.Forms;

namespace WindowsFormApp_PresentationLayer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void _LoadAllContacts()
        {
            dgv_AllContact.DataSource = clsContact.GetAllContact();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            _LoadAllContacts();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int contactID = int.Parse(dgv_AllContact.CurrentRow.Cells[0].Value.ToString());

            Form frm = new frmAddEdit(contactID);
            frm.ShowDialog();
            _LoadAllContacts();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int contactID = int.Parse(dgv_AllContact.CurrentRow.Cells[0].Value.ToString());
            if (clsContact.DeleteContact(contactID))
            {
                _LoadAllContacts();
                MessageBox.Show($"Successfully Delete ContactID {contactID}");
            }
            else
            {
                MessageBox.Show("Faild To Delete Contact.");
            }

        }

        private void btn_AddNewContact_Click(object sender, EventArgs e)
        {

            Form frm = new frmAddEdit();
            frm.ShowDialog();
            _LoadAllContacts();
        }
    }
}
