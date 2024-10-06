using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class InvoiceScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\SWE\Documents\Pro-Natur Biomarkt GmbH.mdf;Integrated Security=True;Connect Timeout=30");

        public InvoiceScreen()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts();
            LoadInvoices(); // Laden der Rechnungen
        }

        private void LoadCustomers()
        {
            databaseConnection.Open();
            string query = "SELECT * FROM Customers";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBoxCustomers.DataSource = dataTable;
            comboBoxCustomers.DisplayMember = "Name"; // Name des Kunden anzeigen
            comboBoxCustomers.ValueMember = "Id"; // ID des Kunden verwenden
            databaseConnection.Close();
        }

        private void LoadProducts()
        {
            databaseConnection.Open();
            string query = "SELECT * FROM Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBoxProducts.DataSource = dataTable;
            comboBoxProducts.DisplayMember = "Name"; // Produktname anzeigen
            comboBoxProducts.ValueMember = "Id"; // Produkt-ID verwenden
            databaseConnection.Close();
        }

        private void LoadInvoices()
        {
            databaseConnection.Open();
            string query = "SELECT b.Id, c.Name AS CustomerName, p.Name AS ProductName, b.Quantity, b.TotalPrice, b.Date FROM Bills b JOIN Customers c ON b.CustomerId = c.Id JOIN Products p ON b.ProductId = p.Id";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewInvoices.DataSource = dataTable;
            databaseConnection.Close();
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            if (comboBoxCustomers.SelectedValue == null || comboBoxProducts.SelectedValue == null || numericUpDownQuantity.Value <= 0)
            {
                MessageBox.Show("Bitte wählen Sie einen Kunden und ein Produkt aus und geben Sie die Menge an.");
                return;
            }

            int customerId = (int)comboBoxCustomers.SelectedValue;
            int productId = (int)comboBoxProducts.SelectedValue;
            int quantity = (int)numericUpDownQuantity.Value;

            // Total price calculation
            decimal productPrice = GetProductPrice(productId);
            decimal totalPrice = productPrice * quantity;

            // Update: Verwenden Sie SQL-Parameter für eine sichere Abfrage
            string query = "INSERT INTO Bills (CustomerId, ProductId, Quantity, TotalPrice, Date) VALUES (@CustomerId, @ProductId, @Quantity, @TotalPrice, GETDATE())";
            ExecuteQuery(query, customerId, productId, quantity, totalPrice);

            MessageBox.Show("Rechnung erfolgreich erstellt.");
            LoadInvoices(); // Aktualisieren Sie die Rechnungsübersicht
        }

        private decimal GetProductPrice(int productId)
        {
            decimal price = 0;
            databaseConnection.Open();
            string query = "SELECT Price FROM Products WHERE Id = @productId";
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.Parameters.AddWithValue("@productId", productId);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.Read())
            {
                // Preis als string lesen und in decimal umwandeln
                string priceString = reader["Price"].ToString();

                // Versuche, den Preis in decimal zu konvertieren
                if (decimal.TryParse(priceString, out price))
                {
                    // Erfolgreiche Konvertierung
                }
                else
                {
                    // Ungültiger Preiswert, handle den Fehler
                    MessageBox.Show($"Ungültiger Preis für Produkt ID {productId}: {priceString}");
                }
            }
            databaseConnection.Close();
            return price;
        }

        private void ExecuteQuery(string query, int customerId, int productId, int quantity, decimal totalPrice)
        {
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            // Parameter hinzufügen, um SQL-Injection zu vermeiden
            sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);
            sqlCommand.Parameters.AddWithValue("@ProductId", productId);
            sqlCommand.Parameters.AddWithValue("@Quantity", quantity);
            sqlCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Rechnung aus, um sie zu bearbeiten.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewInvoices.SelectedRows[0];
            int invoiceId = (int)selectedRow.Cells["Id"].Value;

            // Hier könnten Sie ein neues Formular öffnen, um die Rechnung zu bearbeiten
            // Für dieses Beispiel werde ich einfach die ID anzeigen
            MessageBox.Show($"Rechnung ID {invoiceId} bearbeiten (hier können Sie die Bearbeitungslogik hinzufügen).");
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dataGridViewInvoices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Bitte wählen Sie eine Rechnung aus, um sie zu löschen.");
                return;
            }

            DataGridViewRow selectedRow = dataGridViewInvoices.SelectedRows[0];
            int invoiceId = (int)selectedRow.Cells["Id"].Value;

            string query = "DELETE FROM Bills WHERE Id = @invoiceId";
            databaseConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(query, databaseConnection);
            sqlCommand.Parameters.AddWithValue("@invoiceId", invoiceId);
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();

            MessageBox.Show("Rechnung erfolgreich gelöscht.");
            LoadInvoices(); // Aktualisieren Sie die Rechnungsübersicht
        }
    }
}
