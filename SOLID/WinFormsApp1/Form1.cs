using SingleResponsibility;

namespace WinFormsApp1
{

    /*
     * SRP der ki Her sınıfın (nesnenin) uygulamanızda sadece ve sadece bir sorumluluğu olmalı.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string name = textBoxProductName.Text;
            decimal price = decimal.Parse(textBoxPrice.Text);

            ProductService productService = new ProductService();
            productService.CreateProduct(name, price);
        }      

        private void buttonColorChanger_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog.Color;
            }
        }
    }
}
