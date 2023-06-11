using Stefan_11a_20.Controller;
using Stefan_11a_20.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Stefan_11a_20.View
{
    public partial class ShoeForm : Form
    {
        ShoeLogic shoConreoller = new ShoeLogic();
        TypeLogic typeController = new TypeLogic();
        public ShoeForm()
        {
            InitializeComponent();
        }
        private void LoadRecord(Shoe sho)
        {
            txtId.Text = sho.Id.ToString();
            txtBrand.Text = sho.Brand;
            txtSize.Text = sho.Size.ToString();
            txtPrice.Text = sho.Price.ToString();
            combType.Text = typeController.GetTypeById(int.Parse(txtId.Text));
            listBoxDescription.Items.Add(sho.Discription.ToString());
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) || txtBrand.Text == "")
            {
                MessageBox.Show("ADD data");
                txtId.Focus();
                txtId.BackColor = Color.Red;
                return;
            }
            txtId.BackColor = Color.White;
            Shoe newSho = new Shoe();
            newSho.Id = int.Parse(txtId.Text);
            newSho.Brand = txtBrand.Text;
            newSho.Size = int.Parse(txtSize.Text);
            newSho.Price = double.Parse(txtPrice.Text);
            newSho.TypeId = (int)combType.SelectedValue;
            newSho.Discription = listBoxDescription.Text;

            shoConreoller.Create(newSho);
            MessageBox.Show("Added!");
        }

        private void ShoeForm_Load(object sender, EventArgs e)
        {
            List<ShoeType> allTypes = typeController.GetAllTypes();
            combType.DataSource = allTypes;
            combType.DisplayMember = "Type";
            combType.ValueMember = "Id";
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Shoe> allsho = shoConreoller.GetAll();
            listBoxAll.Items.Clear();
            foreach (var item in allsho)
            {
                listBoxAll.Items.Add($"{item.Id}. {item.Brand}- {item.Size}- {item.Price} $");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter ID!!!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Shoe findSho = shoConreoller.Get(findId);
            if (findSho == null)
            {
                MessageBox.Show("Can't find this ID");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            txtId.BackColor = Color.White;
            LoadRecord(findSho);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int findId;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter ID!!!");
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);

            }
            Shoe findSho = shoConreoller.Get(findId);
            if (findSho == null)
            {
                MessageBox.Show("Can't find this ID");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                txtId.BackColor = Color.White;
                findSho.Id = int.Parse(txtId.Text);
                findSho.Brand = txtBrand.Text;
                findSho.Size = int.Parse(txtSize.Text);
                findSho.Price = int.Parse(txtPrice.Text);
                findSho.Discription = listBoxDescription.ToString();
                MessageBox.Show("Ready");
            }
        }

        private void bdtnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Enter ID");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
                txtId.BackColor = Color.White;
            }
            Shoe findSho = shoConreoller.Get(findId);
            if (findSho == null)
            {
                MessageBox.Show("Can't find this ID");
                txtId.BackColor = Color.Red;
                return;
            }
            else
            {
                DialogResult answear = MessageBox.Show("Do you want to delete ?", "Question", MessageBoxButtons.YesNo);
                if (answear == DialogResult.Yes)
                {
                    shoConreoller.Delete(findId);
                    MessageBox.Show("Successfully deletedD");
                }
                else
                {
                    return;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtBrand.Clear();
            txtSize.Clear();
            txtPrice.Clear();
            combType.Text = "";
            listBoxDescription.Items.Clear();
            listBoxAll.Items.Clear();
        }
    }
}
