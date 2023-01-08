using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace Principal
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }
//    }
//}
namespace Loja_Calcado
{
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class Form1 : Form
{
public Form1()
{
InitializeComponent();
}
private void mCliente_Click(object sender, RoutedEventArgs e)
{
clsCliente cliente = new clsCliente();
cliente.Owner = this;
cliente.Show();
}
private void mSair_Click(object sender, RoutedEventArgs e)
{
this.Close();
}
private void mProduto_Click(object sender, RoutedEventArgs e)
{
jProduto jproduto = new jProduto();
jproduto.Owner = this;
jproduto.Show();
}
private void mRealiazarVenda_Click(object sender, RoutedEventArgs e)
{
jRealizarVenda jrealizarVenda = new jRealizarVenda();
jrealizarVenda.Owner = this;
jrealizarVenda.Show();
}
private void mReajprecoProduto_Click(object sender, RoutedEventArgs e)
{
jReajustarPreco jreajustarPreco = new jReajustarPreco();
jreajustarPreco.Owner = this;
jreajustarPreco.Show();
}
private void mRelClientes_Click(object sender, RoutedEventArgs e)
{
jRelacaoClientes jRelClientes = new jRelacaoClientes();
jRelClientes.Owner = this;
jRelClientes.Show();
}
private void mCatalogoProduto_Click(object sender, RoutedEventArgs e)
{
jCatalogoProduto jcatalogo = new jCatalogoProduto();
jcatalogo.Owner = this;
jcatalogo.Show();
}
private void mRelVendas_Click(object sender, RoutedEventArgs e)
{
jRelVendas jRelvendas = new jRelVendas();
jRelvendas.Owner = this;
jRelvendas.Show();
}
}
}
