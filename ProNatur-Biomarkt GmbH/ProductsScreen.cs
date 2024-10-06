using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class ProductsScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\SWE\Documents\Pro-Natur Biomarkt GmbH.mdf;Integrated Security=True;Connect Timeout=30");

        public ProductsScreen()
        {
            InitializeComponent();

            ShowProducts();

        }

        private void ShowProducts()
        {
            // Start

            // Öffne die Verbindung
            databaseConnection.Open();

            // Query zum Abrufen der Produktdaten
            string query = "SELECT * FROM Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            // Binde die Daten an das DataGridView
            productsDGV.DataSource = dataSet.Tables[0];

            productsDGV.Columns[0].Visible = false;

            // Schließe die Datenbankverbindung
            databaseConnection.Close();
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            string productName = textBoxProductName.Text;
            // Speichere den Produktnamen in der Datenbank



            ShowProducts();

        }

        private void btnProduceEdit_Click(object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            ShowProducts();
        }
    }
}

// Go to ProductScreen.Designer.cs
// 1. RowHeadersVisible from True => False;
// 2. AutoSizeColumsMode from None => Fill;
// 3. AllowUserToAddRows from True => False;
// 4. RowTemplate => DefaultCellStyle => Backcolor => 