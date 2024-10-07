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
        private int lastSelectedProductKey;

        public ProductsScreen()
        {
            InitializeComponent();

            // Abonniere das DataBindingComplete-Ereignis
            productsDGV.DataBindingComplete += ProductsDGV_DataBindingComplete;

            ShowProducts();

        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            // null => for no value
            if(textBoxProductName.Text == "" 
                || textBoxProductBrand.Text == "" 
                || comboBoxProductCategory.Text == ""
                || textBoxProductPrice.Text == "")
            {
                MessageBox.Show("Bitte fülle alle Felder aus.");
                return;
            }

            // Speichere den Produktnamen in der Datenbank
            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategory = comboBoxProductCategory.Text;
            string productPrice = textBoxProductPrice.Text;

            // 9.99 = float
            // "9.99" = string

            // The string.Format method in C# is used to create a formatted string by replacing placeholders:
            // (like {0}, {1}, etc.) with the values provided as arguments.
            string query = string.Format("insert into Products values('{0}','{1}','{2}','{3}')", productName, productBrand, productCategory, productPrice);
            ExecuteQuery(query);
            
            ClearAllFields();
            ShowProducts();

        }

        private void btnProduceEdit_Click(object sender, EventArgs e)
        {
            if (lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                return;
            }

            string productName = textBoxProductName.Text;
            string productBrand = textBoxProductBrand.Text;
            string productCategory = comboBoxProductCategory.Text;
            string productPrice = textBoxProductPrice.Text;

            string query = string.Format("update Products set Name = '{0}', Brand = '{1}', Category = '{2}', Price = '{3}' where Id ={4}",
                productName,
                productBrand,
                productCategory,
                productPrice,
                lastSelectedProductKey
                );

            ExecuteQuery(query);

            ShowProducts();
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            if(lastSelectedProductKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst ein Produkt aus.");
                    return;
            }

            string query = string.Format("delete from Products where Id={0};", lastSelectedProductKey);
            ExecuteQuery(query);

            ClearAllFields();
            ShowProducts();
        }

        private void productsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxProductName.Text = productsDGV.SelectedRows[0].Cells[1].Value.ToString();
            textBoxProductBrand.Text = productsDGV.SelectedRows[0].Cells[2].Value.ToString();
            comboBoxProductCategory.Text = productsDGV.SelectedRows[0].Cells[3].Value.ToString();
            textBoxProductPrice.Text = productsDGV.SelectedRows[0].Cells[4].Value.ToString();

            // In ein int zu casten bedeutet, einen Datentyp explizit in einen ganzzahligen(integer) Typ umzuwandeln.
            // Ein Cast ist eine Anweisung, die den Compiler oder die Laufzeitumgebung dazu zwingt,
            // einen Wert eines Typs in einen anderen Typ umzuwandeln, in diesem Fall in einen int(Integer).

            lastSelectedProductKey = (int)productsDGV.SelectedRows[0].Cells[0].Value;

            //Console.WriteLine(lastSelectedProductKey);
            // Um den Log zu sehen Breakpoint setzen

        }
        // Description of the method:
        // When the user clicks on a cell in the productsDGV,
        // the values from the selected row are extracted from specific columns
        // and displayed in the respective text boxes
        // (textBoxProductName, textBoxProductBrand, textBoxProductPrice) and combo box (comboBoxProductCategory).
        // This allows the user to see the details of the selected product in editable fields.

        private void ProductsDGV_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ändere die Schriftart für die Kopfzeilen aller Spalten
            foreach (DataGridViewColumn column in productsDGV.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold); // Passe die Schriftart und Größe nach Bedarf an
            }
        }

        // ####################################################### Refactored Methods

        private void ExecuteQuery(string query)
        {
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
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

            // Binde die Daten an das DataGridView
            productsDGV.DataSource = dataSet.Tables[0];

            // Schließe die Datenbankverbindung
            databaseConnection.Close();
        }

        private void ClearAllFields()
        {
            textBoxProductName.Text = "";
            textBoxProductBrand.Text = "";
            textBoxProductPrice.Text = "";
            comboBoxProductCategory.Text = "";
            comboBoxProductCategory.SelectedItem = null;
        }

        private void buttonHauptmenü_Click(object sender, EventArgs e)
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.Show();

            this.Hide();
        }

        // #######################################################

    }
}

// Go to ProductScreen.Designer.cs
// 1. RowHeadersVisible from True => False;
// 2. AutoSizeColumsMode from None => Fill;
// 3. AllowUserToAddRows from True => False;
// 4. RowTemplate => DefaultCellStyle => Backcolor 
// 5. Eigenschaften => ReadOnly => False to True

// Anpassen von Datenbank Tabellen im Nachhinein
// Ansicht => Server Explorer => Rechts Klick auf die Tabelle => Tabellendefinition öffenen => Änderung vornehmen => Aktualisieren

// DRY Principle = Dont Repeat Yourself, write methods for call the code instead of duplicate the code 

// CRUD Operations = Create, Read, Update, Delete