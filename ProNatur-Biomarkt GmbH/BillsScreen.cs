using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProNatur_Biomarkt_GmbH
{
    public partial class InvoiceScreen : Form
    {
        private SqlConnection databaseConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\SWE\Documents\Pro-Natur Biomarkt GmbH.mdf;Integrated Security=True;Connect Timeout=30");
        private int lastSelectedInvoiceKey;

        public InvoiceScreen()
        {
            InitializeComponent();
            LoadCustomers();
            LoadProducts(); // Alle Produkte laden
            dataGridViewInvoices.CellClick += dataGridViewInvoices_CellClick;
            dataGridViewInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Ganze Zeile auswählen
            ShowInvoices();
            ClearAllFields(); // Felder zu Beginn leeren
        }

        private void LoadCustomers()
        {
            string query = "SELECT Id, Name FROM Customers";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBoxCustomers.DataSource = dataTable;
            comboBoxCustomers.DisplayMember = "Name";
            comboBoxCustomers.ValueMember = "Id"; // Id als ValueMember setzen
        }

        private void LoadProducts()
        {
            string query = "SELECT Id, Name FROM Products";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            comboBoxProducts.DataSource = dataTable;
            comboBoxProducts.DisplayMember = "Name";
            comboBoxProducts.ValueMember = "Id";
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob eine Rechnung bereits ausgewählt ist
            if (lastSelectedInvoiceKey != 0)
            {
                MessageBox.Show("Es darf keine Rechnung erstellt werden, solange eine andere Rechnung geladen ist.");
                return;
            }

            if (comboBoxCustomers.SelectedItem == null || numericUpDownQuantity.Value <= 0 || comboBoxProducts.SelectedItem == null)
            {
                MessageBox.Show("Bitte fülle alle Felder aus.");
                return;
            }

            int customerId = (int)((DataRowView)comboBoxCustomers.SelectedItem)["Id"];
            int productId = (int)((DataRowView)comboBoxProducts.SelectedItem)["Id"];
            int quantity = (int)numericUpDownQuantity.Value;
            decimal totalPrice = CalculateTotalPrice(productId, quantity);

            // Stellen Sie sicher, dass alle erforderlichen Spalten angegeben sind
            string query = "INSERT INTO Bills (CustomerId, ProductId, Quantity, TotalPrice, Date) VALUES (@CustomerId, @ProductId, @Quantity, @TotalPrice, GETDATE())";

            using (SqlCommand sqlCommand = new SqlCommand(query, databaseConnection))
            {
                sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);
                sqlCommand.Parameters.AddWithValue("@ProductId", productId);
                sqlCommand.Parameters.AddWithValue("@Quantity", quantity);
                sqlCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);

                ExecuteQuery(sqlCommand);
            }

            MessageBox.Show("Rechnung erfolgreich erstellt."); // Erfolgsmeldung
            ClearAllFields();
            ShowInvoices();
        }

        private void btnEditInvoice_Click(object sender, EventArgs e)
        {
            if (lastSelectedInvoiceKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst eine Rechnung aus.");
                return;
            }

            if (comboBoxCustomers.SelectedItem == null || numericUpDownQuantity.Value <= 0 || comboBoxProducts.SelectedItem == null)
            {
                MessageBox.Show("Bitte fülle alle Felder aus.");
                return;
            }

            int customerId = (int)((DataRowView)comboBoxCustomers.SelectedItem)["Id"];
            int productId = (int)((DataRowView)comboBoxProducts.SelectedItem)["Id"];
            int quantity = (int)numericUpDownQuantity.Value;
            decimal totalPrice = CalculateTotalPrice(productId, quantity);

            string query = "UPDATE Bills SET CustomerId = @CustomerId, ProductId = @ProductId, Quantity = @Quantity, TotalPrice = @TotalPrice WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(query, databaseConnection))
            {
                sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);
                sqlCommand.Parameters.AddWithValue("@ProductId", productId);
                sqlCommand.Parameters.AddWithValue("@Quantity", quantity);
                sqlCommand.Parameters.AddWithValue("@TotalPrice", totalPrice);
                sqlCommand.Parameters.AddWithValue("@Id", lastSelectedInvoiceKey);

                ExecuteQuery(sqlCommand);
            }

            MessageBox.Show("Rechnung erfolgreich bearbeitet."); // Erfolgsmeldung
            ShowInvoices();
        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (lastSelectedInvoiceKey == 0)
            {
                MessageBox.Show("Bitte wähle zuerst eine Rechnung aus.");
                return;
            }

            string query = "DELETE FROM Bills WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(query, databaseConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", lastSelectedInvoiceKey);
                ExecuteQuery(sqlCommand);
            }

            MessageBox.Show("Rechnung erfolgreich gelöscht."); // Erfolgsmeldung
            ClearAllFields();
            ShowInvoices();
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        private void dataGridViewInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewInvoices.Rows[e.RowIndex];

                comboBoxCustomers.SelectedValue = row.Cells["CustomerId"].Value;
                numericUpDownQuantity.Value = Convert.ToInt32(row.Cells["Quantity"].Value);
                lastSelectedInvoiceKey = Convert.ToInt32(row.Cells["Id"].Value);

                LoadProductsForInvoice();
            }
        }

        private void DataGridViewInvoices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridViewInvoices.Columns)
            {
                column.HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold);
            }
        }

        private void ExecuteQuery(SqlCommand sqlCommand)
        {
            databaseConnection.Open();
            sqlCommand.Connection = databaseConnection;
            sqlCommand.ExecuteNonQuery();
            databaseConnection.Close();
        }

        private void ShowInvoices()
        {
            databaseConnection.Open();
            string query = @"
                SELECT B.Id, B.CustomerId, C.Name AS CustomerName, B.ProductId, P.Name AS ProductName, B.Quantity, B.TotalPrice, B.Date
                FROM Bills B
                JOIN Customers C ON B.CustomerId = C.Id
                JOIN Products P ON B.ProductId = P.Id";

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, databaseConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);

            dataGridViewInvoices.DataSource = dataSet.Tables[0];

            if (dataGridViewInvoices.Columns.Count > 0)
            {
                dataGridViewInvoices.Columns["Id"].Visible = false;
                dataGridViewInvoices.Columns["CustomerId"].Visible = false;
                dataGridViewInvoices.Columns["ProductId"].Visible = false;
            }

            databaseConnection.Close();
        }

        private void LoadProductsForInvoice()
        {
            if (lastSelectedInvoiceKey == 0)
            {
                comboBoxProducts.SelectedIndex = -1; // Kein Produkt ausgewählt
                return;
            }

            string query = "SELECT ProductId FROM Bills WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(query, databaseConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", lastSelectedInvoiceKey);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    int productId = Convert.ToInt32(dataTable.Rows[0]["ProductId"]);

                    // Alle Produkte laden, damit wir das richtige auswählen können
                    LoadProducts();

                    // Das Produkt, das zur Rechnung gehört, auswählen
                    comboBoxProducts.SelectedValue = productId;
                }
            }
        }

        private decimal CalculateTotalPrice(int productId, int quantity)
        {
            decimal price = 0;
            databaseConnection.Open();

            string query = "SELECT Price FROM Products WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(query, databaseConnection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", productId);

                object result = sqlCommand.ExecuteScalar();
                if (result != null)
                {
                    price = Convert.ToDecimal(result);
                }
            }

            databaseConnection.Close();
            return price * quantity;
        }

        private void ClearAllFields()
        {
            comboBoxCustomers.SelectedIndex = -1;
            numericUpDownQuantity.Value = 1;
            lastSelectedInvoiceKey = 0;
            comboBoxProducts.SelectedIndex = -1; // Nur die Auswahl zurücksetzen
        }

        private void buttonHauptmenü_Click(object sender, EventArgs e)
        {
            MainMenuScreen mainMenuScreen = new MainMenuScreen();
            mainMenuScreen.Show();

            this.Hide();
        }

        private void buttonClearFields_Click(object sender, EventArgs e)
        {

            // Setze alle Felder zurück
            comboBoxCustomers.SelectedIndex = -1; // Auswahl für Kunden zurücksetzen
            comboBoxProducts.SelectedIndex = -1; // Auswahl für Produkte zurücksetzen
            numericUpDownQuantity.Value = 1; // Menge auf 1 zurücksetzen
            lastSelectedInvoiceKey = 0; // Letzte ausgewählte Rechnung zurücksetzen

            // Optional: Weitere Felder zurücksetzen, wenn vorhanden
            // textBoxOtherField.Text = string.Empty; // Beispiel für ein weiteres Textfeld

            // Zeige die Rechnungen erneut an, um die Auswahl zurückzusetzen
            ShowInvoices();

        }
    }
}
