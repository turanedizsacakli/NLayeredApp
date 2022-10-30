using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
using Northwind.Business.DependencyResolvers.Ninject.InstanceFactory;
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
            //ninject came...
            //_productService = new ProductManager(new EfProductDal());
            //_categoryService = new CategoryManager(new EfCategoryDal());
            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();
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
            try
            {
                _productService.Add(new Product
                {
                    ProductName = tbxName.Text,
                    UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                    CategoryId = Convert.ToInt32(tbxCategoryId.Text),
                    QuantityPerUnit = tbxQuantityPerUnit.Text,

                });
                MessageBox.Show(" Product is added... ");
                LoadProducts();

                tbxName.Text = "";
                tbxUnitPrice.Text = "";
                tbxCategoryId.Text = "";
                tbxQuantityPerUnit.Text = "";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgwProduct.CurrentRow != null)
            {
                try
                {
                    _productService.Delete(new Product
                    {
                        ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value)
                    });
                    MessageBox.Show("Product deleted...");
                    LoadProducts();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }

            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProduct.CurrentRow.Cells[0].Value),
                ProductName = tbxUpdateName.Text,
                CategoryId = Convert.ToInt32(tbxUpdateCategoryId.Text),
                UnitPrice = Convert.ToDecimal(tbxUpdateUnitPrice.Text),
                QuantityPerUnit = tbxUpdateQuantityPerUnit.Text

            });

            MessageBox.Show("Product updated...");
            LoadProducts();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxUpdateName.Text = dgwProduct.CurrentRow.Cells[1].Value.ToString();
            tbxUpdateCategoryId.Text = dgwProduct.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateUnitPrice.Text = dgwProduct.CurrentRow.Cells[3].Value.ToString();
            tbxUpdateQuantityPerUnit.Text = dgwProduct.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
