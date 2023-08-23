
namespace Neptuno2023.Windows
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CategoriasButton = new System.Windows.Forms.Button();
            this.VentasButton = new System.Windows.Forms.Button();
            this.ProductosButton = new System.Windows.Forms.Button();
            this.ProveedoresButton = new System.Windows.Forms.Button();
            this.ClientesButton = new System.Windows.Forms.Button();
            this.CiudadesButton = new System.Windows.Forms.Button();
            this.PaisesButton = new System.Windows.Forms.Button();
            this.CerrarButton = new System.Windows.Forms.Button();
            this.Compras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(44, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Neptuno SRL";
            // 
            // CategoriasButton
            // 
            this.CategoriasButton.Image = global::Neptuno2023.Windows.Properties.Resources.categorize_50px;
            this.CategoriasButton.Location = new System.Drawing.Point(56, 267);
            this.CategoriasButton.Name = "CategoriasButton";
            this.CategoriasButton.Size = new System.Drawing.Size(147, 76);
            this.CategoriasButton.TabIndex = 2;
            this.CategoriasButton.Text = "Categorías";
            this.CategoriasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CategoriasButton.UseVisualStyleBackColor = true;
            this.CategoriasButton.Click += new System.EventHandler(this.CategoriasButton_Click);
            // 
            // VentasButton
            // 
            this.VentasButton.Image = global::Neptuno2023.Windows.Properties.Resources.cash_register_50px;
            this.VentasButton.Location = new System.Drawing.Point(56, 383);
            this.VentasButton.Name = "VentasButton";
            this.VentasButton.Size = new System.Drawing.Size(147, 76);
            this.VentasButton.TabIndex = 2;
            this.VentasButton.Text = "Ventas";
            this.VentasButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VentasButton.UseVisualStyleBackColor = true;
            this.VentasButton.Click += new System.EventHandler(this.VentasButton_Click);
            // 
            // ProductosButton
            // 
            this.ProductosButton.Image = global::Neptuno2023.Windows.Properties.Resources.used_product_50px;
            this.ProductosButton.Location = new System.Drawing.Point(421, 267);
            this.ProductosButton.Name = "ProductosButton";
            this.ProductosButton.Size = new System.Drawing.Size(147, 76);
            this.ProductosButton.TabIndex = 2;
            this.ProductosButton.Text = "Productos";
            this.ProductosButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProductosButton.UseVisualStyleBackColor = true;
            this.ProductosButton.Click += new System.EventHandler(this.ProductosButton_Click);
            // 
            // ProveedoresButton
            // 
            this.ProveedoresButton.Image = global::Neptuno2023.Windows.Properties.Resources.customer_50px;
            this.ProveedoresButton.Location = new System.Drawing.Point(238, 267);
            this.ProveedoresButton.Name = "ProveedoresButton";
            this.ProveedoresButton.Size = new System.Drawing.Size(147, 76);
            this.ProveedoresButton.TabIndex = 2;
            this.ProveedoresButton.Text = "Proveedores";
            this.ProveedoresButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProveedoresButton.UseVisualStyleBackColor = true;
            this.ProveedoresButton.Click += new System.EventHandler(this.ProveedoresButton_Click);
            // 
            // ClientesButton
            // 
            this.ClientesButton.Image = global::Neptuno2023.Windows.Properties.Resources.client_management_50px;
            this.ClientesButton.Location = new System.Drawing.Point(421, 150);
            this.ClientesButton.Name = "ClientesButton";
            this.ClientesButton.Size = new System.Drawing.Size(147, 76);
            this.ClientesButton.TabIndex = 2;
            this.ClientesButton.Text = "Clientes";
            this.ClientesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClientesButton.UseVisualStyleBackColor = true;
            this.ClientesButton.Click += new System.EventHandler(this.ClientesButton_Click);
            // 
            // CiudadesButton
            // 
            this.CiudadesButton.Image = global::Neptuno2023.Windows.Properties.Resources.city_50px;
            this.CiudadesButton.Location = new System.Drawing.Point(238, 150);
            this.CiudadesButton.Name = "CiudadesButton";
            this.CiudadesButton.Size = new System.Drawing.Size(147, 76);
            this.CiudadesButton.TabIndex = 2;
            this.CiudadesButton.Text = "Ciudades";
            this.CiudadesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CiudadesButton.UseVisualStyleBackColor = true;
            this.CiudadesButton.Click += new System.EventHandler(this.CiudadesButton_Click);
            // 
            // PaisesButton
            // 
            this.PaisesButton.Image = global::Neptuno2023.Windows.Properties.Resources.america_50px;
            this.PaisesButton.Location = new System.Drawing.Point(56, 150);
            this.PaisesButton.Name = "PaisesButton";
            this.PaisesButton.Size = new System.Drawing.Size(147, 76);
            this.PaisesButton.TabIndex = 2;
            this.PaisesButton.Text = "Países";
            this.PaisesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PaisesButton.UseVisualStyleBackColor = true;
            this.PaisesButton.Click += new System.EventHandler(this.PaisesButton_Click);
            // 
            // CerrarButton
            // 
            this.CerrarButton.Image = global::Neptuno2023.Windows.Properties.Resources.shutdown_48px;
            this.CerrarButton.Location = new System.Drawing.Point(1066, 528);
            this.CerrarButton.Name = "CerrarButton";
            this.CerrarButton.Size = new System.Drawing.Size(75, 59);
            this.CerrarButton.TabIndex = 1;
            this.CerrarButton.UseVisualStyleBackColor = true;
            this.CerrarButton.Click += new System.EventHandler(this.CerrarButton_Click);
            // 
            // Compras
            // 
            this.Compras.Image = global::Neptuno2023.Windows.Properties.Resources.cash_register_50px;
            this.Compras.Location = new System.Drawing.Point(238, 383);
            this.Compras.Name = "Compras";
            this.Compras.Size = new System.Drawing.Size(147, 76);
            this.Compras.TabIndex = 2;
            this.Compras.Text = "Compras";
            this.Compras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Compras.UseVisualStyleBackColor = true;
            this.Compras.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 619);
            this.Controls.Add(this.CategoriasButton);
            this.Controls.Add(this.Compras);
            this.Controls.Add(this.VentasButton);
            this.Controls.Add(this.ProductosButton);
            this.Controls.Add(this.ProveedoresButton);
            this.Controls.Add(this.ClientesButton);
            this.Controls.Add(this.CiudadesButton);
            this.Controls.Add(this.PaisesButton);
            this.Controls.Add(this.CerrarButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CerrarButton;
        private System.Windows.Forms.Button PaisesButton;
        private System.Windows.Forms.Button CiudadesButton;
        private System.Windows.Forms.Button CategoriasButton;
        private System.Windows.Forms.Button ClientesButton;
        private System.Windows.Forms.Button ProveedoresButton;
        private System.Windows.Forms.Button ProductosButton;
        private System.Windows.Forms.Button VentasButton;
        private System.Windows.Forms.Button Compras;
    }
}

