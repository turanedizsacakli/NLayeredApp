using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Entities.Concrete;
using Nothwind.DataAccess.Abstract;
using Nothwind.DataAccess.Concrete.EntityFramework;
using Nothwind.DataAccess.Concrete.NhProductDal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Northwind.WebFormsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private IProductService _productService;
        private ICategoryService _categoryService;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadCategories();
        }

        private void LoadCategories()
        {
            cbxCategory.DataSource = _categoryService.GetAll();
            cbxCategory.DisplayMember = "CategoryName";
            cbxCategory.ValueMember = "CategoryId";

        }

        private void LoadProducts()
        {
            dgwProduct.DataSource = _productService.GetAll();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
            dgwProduct.DataSource = _productService.GetProductsByCategory(Convert.ToInt32(cbxCategory.SelectedValue));
            }
            catch
            {

            }
                       
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxSearch.Text))
            {
                dgwProduct.DataSource = _productService.GetProductsByProductName(tbxSearch.Text);
            }
            else
            {
                LoadProducts();
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productService.Add(new Product
            {
                ProductName = tbxName.Text,
                UnitPrice = Convert.ToDecimal( tbxUnitPrice.Text),
                CategoryId = Convert.ToInt32(tbxCategoryId.Text),
                QuantityPerUnit=tbxQuantityPerUnit.Text,
                
            });
            MessageBox.Show(" Product is added... ");
            LoadProducts();

            tbxName.Text = "";
            tbxUnitPrice.Text = "";
            tbxCategoryId.Text = "";
            tbxQuantityPerUnit.Text = "";

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
            });
            MessageBox.Show("Product deleted...");
            LoadProducts();
        }
    }
}
