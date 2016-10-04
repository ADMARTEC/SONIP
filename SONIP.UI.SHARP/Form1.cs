using Microsoft.Practices.Unity;
using SONIP.Dominio.Contracts.Services;
using SONIP.Startup;
using System;
using System.Windows.Forms;

namespace SONIP.UI.SHARP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var container = new UnityContainer();
            DependencyResolver.Resolver(container);

            var service = container.Resolve<IUserService>();

            try
            {
                service.AlterarInfo(textBox1.Text, textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
