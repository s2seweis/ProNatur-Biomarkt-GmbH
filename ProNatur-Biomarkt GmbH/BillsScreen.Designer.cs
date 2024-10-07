using System;

namespace ProNatur_Biomarkt_GmbH
{
    partial class InvoiceScreen
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form-Designer generierter Code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceScreen));
            this.comboBoxCustomers = new System.Windows.Forms.ComboBox();
            this.numericUpDownQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.dataGridViewInvoices = new System.Windows.Forms.DataGridView();
            this.btnEditInvoice = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.comboBoxProducts = new System.Windows.Forms.ComboBox();
            this.labelProducts = new System.Windows.Forms.Label();
            this.buttonHauptmenü = new System.Windows.Forms.Button();
            this.buttonClearFields = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCustomers
            // 
            this.comboBoxCustomers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.comboBoxCustomers.ForeColor = System.Drawing.Color.White;
            this.comboBoxCustomers.FormattingEnabled = true;
            this.comboBoxCustomers.Location = new System.Drawing.Point(40, 30);
            this.comboBoxCustomers.Name = "comboBoxCustomers";
            this.comboBoxCustomers.Size = new System.Drawing.Size(200, 24);
            this.comboBoxCustomers.TabIndex = 0;
            // 
            // numericUpDownQuantity
            // 
            this.numericUpDownQuantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.numericUpDownQuantity.ForeColor = System.Drawing.Color.White;
            this.numericUpDownQuantity.Location = new System.Drawing.Point(40, 98);
            this.numericUpDownQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownQuantity.Name = "numericUpDownQuantity";
            this.numericUpDownQuantity.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownQuantity.TabIndex = 1;
            this.numericUpDownQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCreateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnCreateInvoice.Location = new System.Drawing.Point(40, 160);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(134, 26);
            this.btnCreateInvoice.TabIndex = 2;
            this.btnCreateInvoice.Text = "Rechnung erstellen";
            this.btnCreateInvoice.UseVisualStyleBackColor = false;
            this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // dataGridViewInvoices
            // 
            this.dataGridViewInvoices.AllowUserToAddRows = false;
            this.dataGridViewInvoices.AllowUserToDeleteRows = false;
            this.dataGridViewInvoices.AllowUserToResizeColumns = false;
            this.dataGridViewInvoices.AllowUserToResizeRows = false;
            this.dataGridViewInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewInvoices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dataGridViewInvoices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInvoices.Location = new System.Drawing.Point(12, 199);
            this.dataGridViewInvoices.Name = "dataGridViewInvoices";
            this.dataGridViewInvoices.ReadOnly = true;
            this.dataGridViewInvoices.RowHeadersVisible = false;
            this.dataGridViewInvoices.RowHeadersWidth = 51;
            this.dataGridViewInvoices.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.dataGridViewInvoices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridViewInvoices.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.dataGridViewInvoices.RowTemplate.Height = 24;
            this.dataGridViewInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInvoices.Size = new System.Drawing.Size(773, 242);
            this.dataGridViewInvoices.TabIndex = 3;
            this.dataGridViewInvoices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewInvoices_DataBindingComplete);
            this.dataGridViewInvoices.SelectionChanged += new System.EventHandler(this.dataGridViewInvoices_SelectionChanged);
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnEditInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditInvoice.ForeColor = System.Drawing.Color.White;
            this.btnEditInvoice.Location = new System.Drawing.Point(202, 160);
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(146, 26);
            this.btnEditInvoice.TabIndex = 4;
            this.btnEditInvoice.Text = "Rechnung bearbeiten";
            this.btnEditInvoice.UseVisualStyleBackColor = false;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnDeleteInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteInvoice.ForeColor = System.Drawing.Color.White;
            this.btnDeleteInvoice.Location = new System.Drawing.Point(375, 160);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(130, 26);
            this.btnDeleteInvoice.TabIndex = 5;
            this.btnDeleteInvoice.Text = "Rechnung löschen";
            this.btnDeleteInvoice.UseVisualStyleBackColor = false;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.ForeColor = System.Drawing.Color.White;
            this.labelCustomer.Location = new System.Drawing.Point(40, 10);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(48, 16);
            this.labelCustomer.TabIndex = 6;
            this.labelCustomer.Text = "Kunde:";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.ForeColor = System.Drawing.Color.White;
            this.labelQuantity.Location = new System.Drawing.Point(42, 76);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(52, 16);
            this.labelQuantity.TabIndex = 7;
            this.labelQuantity.Text = "Menge:";
            // 
            // comboBoxProducts
            // 
            this.comboBoxProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.comboBoxProducts.ForeColor = System.Drawing.Color.White;
            this.comboBoxProducts.FormattingEnabled = true;
            this.comboBoxProducts.Location = new System.Drawing.Point(300, 30);
            this.comboBoxProducts.Name = "comboBoxProducts";
            this.comboBoxProducts.Size = new System.Drawing.Size(200, 24);
            this.comboBoxProducts.TabIndex = 8;
            // 
            // labelProducts
            // 
            this.labelProducts.AutoSize = true;
            this.labelProducts.ForeColor = System.Drawing.Color.White;
            this.labelProducts.Location = new System.Drawing.Point(300, 10);
            this.labelProducts.Name = "labelProducts";
            this.labelProducts.Size = new System.Drawing.Size(64, 16);
            this.labelProducts.TabIndex = 9;
            this.labelProducts.Text = "Produkte:";
            // 
            // buttonHauptmenü
            // 
            this.buttonHauptmenü.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonHauptmenü.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHauptmenü.ForeColor = System.Drawing.Color.White;
            this.buttonHauptmenü.Location = new System.Drawing.Point(697, 13);
            this.buttonHauptmenü.Name = "buttonHauptmenü";
            this.buttonHauptmenü.Size = new System.Drawing.Size(88, 33);
            this.buttonHauptmenü.TabIndex = 10;
            this.buttonHauptmenü.Text = "Hauptmenü";
            this.buttonHauptmenü.UseVisualStyleBackColor = false;
            this.buttonHauptmenü.Click += new System.EventHandler(this.buttonHauptmenü_Click);
            // 
            // buttonClearFields
            // 
            this.buttonClearFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.buttonClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClearFields.ForeColor = System.Drawing.Color.White;
            this.buttonClearFields.Location = new System.Drawing.Point(532, 160);
            this.buttonClearFields.Name = "buttonClearFields";
            this.buttonClearFields.Size = new System.Drawing.Size(130, 26);
            this.buttonClearFields.TabIndex = 11;
            this.buttonClearFields.Text = "Felder Leeren";
            this.buttonClearFields.UseVisualStyleBackColor = false;
            this.buttonClearFields.Click += new System.EventHandler(this.buttonClearFields_Click);
            // 
            // InvoiceScreen
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(797, 453);
            this.Controls.Add(this.buttonClearFields);
            this.Controls.Add(this.buttonHauptmenü);
            this.Controls.Add(this.labelProducts);
            this.Controls.Add(this.comboBoxProducts);
            this.Controls.Add(this.labelQuantity);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.btnDeleteInvoice);
            this.Controls.Add(this.btnEditInvoice);
            this.Controls.Add(this.dataGridViewInvoices);
            this.Controls.Add(this.btnCreateInvoice);
            this.Controls.Add(this.numericUpDownQuantity);
            this.Controls.Add(this.comboBoxCustomers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rechnung Verwaltung";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInvoices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCustomers;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantity;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.DataGridView dataGridViewInvoices;
        private System.Windows.Forms.Button btnEditInvoice;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.ComboBox comboBoxProducts; // ComboBox für Produkte
        private System.Windows.Forms.Label labelProducts;

        // Event-Handler für die Auswahländerung der Rechnungen
        private void dataGridViewInvoices_SelectionChanged(object sender, EventArgs e)
        {
            // Überprüfen, ob mindestens eine Zeile ausgewählt ist
            if (dataGridViewInvoices.SelectedRows.Count > 0)
            {
                // Ausgewählte Zeile abrufen
                var selectedRow = dataGridViewInvoices.SelectedRows[0];

                // Überprüfen, ob die Spalte "ProductColumn" existiert
                if (dataGridViewInvoices.Columns.Contains("ProductColumn"))
                {
                    // Produkt in der ComboBox anzeigen
                    comboBoxProducts.SelectedItem = selectedRow.Cells["ProductColumn"].Value; // Angenommene Spalte für das Produkt
                }

                // Überprüfen, ob die Spalte "QuantityColumn" existiert
                if (dataGridViewInvoices.Columns.Contains("QuantityColumn"))
                {
                    // Menge im NumericUpDown setzen
                    numericUpDownQuantity.Value = (decimal)selectedRow.Cells["QuantityColumn"].Value; // Angenommene Spalte für die Menge
                }
            }
        }

        private System.Windows.Forms.Button buttonHauptmenü;
        private System.Windows.Forms.Button buttonClearFields;
    }
}
