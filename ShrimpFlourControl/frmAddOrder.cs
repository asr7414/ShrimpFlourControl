using ShrimpFlourControl.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShrimpFlourControl
{
    public partial class frmAddOrder : Form
    {
        public Order order=new Order();
        public SFCServer SFC = new SFCServer();
        public frmAddOrder()
        {
            InitializeComponent();
        }
        public frmAddOrder(SFCServer SFC)
        {
            this.SFC = SFC;
            
            InitializeComponent();
            cbProductId.Items.AddRange(this.SFC.Products.Select(p => new ComboBoxItem(p.ProductId.ToString(), p.Name, p)).ToArray());

        }
        public class ComboBoxItem
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public object Obj { get; set; }
            public ComboBoxItem(string value, string text)
            {
                Value = value;
                Text = text;
            }
            public ComboBoxItem(string value, string text, object obj)
            {
                Value = value;
                Text = text;
                Obj = obj;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)cbProductId.SelectedItem;
            order.ProductId = int.Parse(item.Value);
            order.Product = (Products.Product)item.Obj;
            
            this.DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAddOrder_Load(object sender, EventArgs e)
        {

        }
    }
}
