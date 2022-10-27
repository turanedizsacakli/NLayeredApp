﻿using Northwind.Business.Abstract;
using Northwind.Business.Concrete;
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private IProductService _productService;
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgwProduct.DataSource = _productService.GetAll();
            
        }
                
    }
}
