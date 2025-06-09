using BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormApp_PresentationLayer
{
    public partial class frmAddEdit : Form
    {
        private enMode _Mode;
        private clsContact _Contact;
        private int  _ContactID;
        public frmAddEdit(int contactID = -1)
        {
            _ContactID = contactID;

            if (_ContactID != -1) 
                _Mode = enMode.Update;
            else
                _Mode = enMode.Add;
            
            InitializeComponent();
        }
        private void frmAddEdit_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            cb_Country.SelectedIndex = 0;

            if (_Mode == enMode.Add)
            {
                _Contact = new clsContact();
                lbl_RemoveImage.Visible = false;
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if (_Mode == enMode.Update && _Contact != null)
            {
                this.Text = "Update Contact";

                lbl_ContactID.Text = _Contact.ID.ToString();
                tb_FirstName.Text = _Contact.FirstName;
                tb_LastName.Text = _Contact.LastName;
                tb_Email.Text = _Contact.Email;
                tb_Phone.Text = _Contact.Phone;
                tb_Address.Text = _Contact.Address;

                dtp_DateOfBirth.Value = _Contact.DateOfBirth;
                
                lbl_RemoveImage.Visible = (_Contact.ImagePath != "");
                
                if (_Contact.ImagePath != "")
                {
                    pictureBox1.Load(_Contact.ImagePath);
                }

                cb_Country.SelectedIndex = cb_Country.FindString(clsCountry.Find(_Contact.CountryID).Name);
            }
        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cb_Country.Items.Add(row["CountryName"]);
            }
        }
        private void lbl_RemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            lbl_RemoveImage.Visible = false;
        }
        private void lbl_SetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog1.FileName;

                pictureBox1.Load(selectedFilePath);
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cb_Country.Text).ID;

            _Contact.FirstName = tb_FirstName.Text;
            _Contact.LastName = tb_LastName.Text;
            _Contact.Email = tb_Email.Text;
            _Contact.Phone = tb_Phone.Text;
            _Contact.Address = tb_Address.Text;
            _Contact.DateOfBirth = dtp_DateOfBirth.Value;
            _Contact.CountryID = CountryID;

            if (pictureBox1.ImageLocation != null)
            {
                _Contact.ImagePath = pictureBox1.ImageLocation; 
            }
            else 
            { 
                _Contact.ImagePath = "";
            }

            if (_Contact.Save())
            {
                this.Text = "Update Contact";
                _Mode = enMode.Update;
                lbl_ContactID.Text = _Contact.ID.ToString();
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }
        }
    }
}
