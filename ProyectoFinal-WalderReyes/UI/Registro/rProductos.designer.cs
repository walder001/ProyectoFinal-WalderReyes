namespace Parcial1_WalderReyes.UI.Registro
{
    partial class rProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rProductos));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ExisencianumericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.CostonumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.ProductoIdnumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Guardar = new System.Windows.Forms.Button();
            this.Buscar = new System.Windows.Forms.Button();
            this.InventariotextBox4 = new System.Windows.Forms.TextBox();
            this.DescripciontextBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Nuevo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.PreciosdataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.TipotextBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.PrecionumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.remover = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExisencianumericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostonumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoIdnumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreciosdataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(443, 589);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // ExisencianumericUpDown3
            // 
            this.ExisencianumericUpDown3.Location = new System.Drawing.Point(95, 211);
            this.ExisencianumericUpDown3.Name = "ExisencianumericUpDown3";
            this.ExisencianumericUpDown3.Size = new System.Drawing.Size(191, 20);
            this.ExisencianumericUpDown3.TabIndex = 48;
            this.ExisencianumericUpDown3.ValueChanged += new System.EventHandler(this.ExisencianumericUpDown3_ValueChanged_1);
            // 
            // CostonumericUpDown2
            // 
            this.CostonumericUpDown2.DecimalPlaces = 2;
            this.CostonumericUpDown2.Increment = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            this.CostonumericUpDown2.Location = new System.Drawing.Point(95, 159);
            this.CostonumericUpDown2.Name = "CostonumericUpDown2";
            this.CostonumericUpDown2.Size = new System.Drawing.Size(191, 20);
            this.CostonumericUpDown2.TabIndex = 47;
            this.CostonumericUpDown2.ValueChanged += new System.EventHandler(this.CostonumericUpDown2_ValueChanged_1);
            // 
            // ProductoIdnumericUpDown1
            // 
            this.ProductoIdnumericUpDown1.Location = new System.Drawing.Point(95, 68);
            this.ProductoIdnumericUpDown1.Name = "ProductoIdnumericUpDown1";
            this.ProductoIdnumericUpDown1.Size = new System.Drawing.Size(94, 20);
            this.ProductoIdnumericUpDown1.TabIndex = 46;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Eliminar.BackColor = System.Drawing.Color.Red;
            this.Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("Eliminar.Image")));
            this.Eliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Eliminar.Location = new System.Drawing.Point(306, 536);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(112, 41);
            this.Eliminar.TabIndex = 45;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = false;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click_1);
            // 
            // Guardar
            // 
            this.Guardar.BackColor = System.Drawing.Color.Red;
            this.Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Guardar.Image = ((System.Drawing.Image)(resources.GetObject("Guardar.Image")));
            this.Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Guardar.Location = new System.Drawing.Point(163, 536);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(123, 41);
            this.Guardar.TabIndex = 44;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = false;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click_1);
            // 
            // Buscar
            // 
            this.Buscar.BackColor = System.Drawing.Color.Red;
            this.Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Buscar.ForeColor = System.Drawing.Color.Black;
            this.Buscar.Location = new System.Drawing.Point(211, 61);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 30);
            this.Buscar.TabIndex = 43;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = false;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click_1);
            // 
            // InventariotextBox4
            // 
            this.InventariotextBox4.Location = new System.Drawing.Point(95, 257);
            this.InventariotextBox4.Name = "InventariotextBox4";
            this.InventariotextBox4.ReadOnly = true;
            this.InventariotextBox4.Size = new System.Drawing.Size(191, 20);
            this.InventariotextBox4.TabIndex = 42;
            this.InventariotextBox4.TextChanged += new System.EventHandler(this.InventariotextBox4_TextChanged);
            // 
            // DescripciontextBox1
            // 
            this.DescripciontextBox1.Location = new System.Drawing.Point(95, 115);
            this.DescripciontextBox1.Name = "DescripciontextBox1";
            this.DescripciontextBox1.Size = new System.Drawing.Size(191, 20);
            this.DescripciontextBox1.TabIndex = 41;
            this.DescripciontextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DescripciontextBox1_KeyPress_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Inventario";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Existencia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Costo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 36;
            this.label2.Text = "ProductoId";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Registro Productos";
            // 
            // Nuevo
            // 
            this.Nuevo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Nuevo.BackColor = System.Drawing.Color.Red;
            this.Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("Nuevo.Image")));
            this.Nuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nuevo.Location = new System.Drawing.Point(33, 536);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(113, 41);
            this.Nuevo.TabIndex = 49;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = false;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Ubicacion";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(97, 300);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 51;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 20);
            this.button1.TabIndex = 52;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // PreciosdataGridView1
            // 
            this.PreciosdataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PreciosdataGridView1.Location = new System.Drawing.Point(22, 413);
            this.PreciosdataGridView1.Name = "PreciosdataGridView1";
            this.PreciosdataGridView1.Size = new System.Drawing.Size(404, 104);
            this.PreciosdataGridView1.TabIndex = 53;
            this.PreciosdataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 344);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 54;
            this.label8.Text = "Precio";
            // 
            // TipotextBox1
            // 
            this.TipotextBox1.Location = new System.Drawing.Point(264, 341);
            this.TipotextBox1.Name = "TipotextBox1";
            this.TipotextBox1.Size = new System.Drawing.Size(100, 20);
            this.TipotextBox1.TabIndex = 56;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 347);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 57;
            this.label9.Text = "Tipo";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(382, 342);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 58;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 59;
            // 
            // PrecionumericUpDown2
            // 
            this.PrecionumericUpDown2.Location = new System.Drawing.Point(95, 342);
            this.PrecionumericUpDown2.Name = "PrecionumericUpDown2";
            this.PrecionumericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.PrecionumericUpDown2.TabIndex = 60;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(8, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 61;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // remover
            // 
            this.remover.Location = new System.Drawing.Point(22, 384);
            this.remover.Name = "remover";
            this.remover.Size = new System.Drawing.Size(75, 23);
            this.remover.TabIndex = 62;
            this.remover.Text = "Remover";
            this.remover.UseVisualStyleBackColor = true;
            this.remover.Click += new System.EventHandler(this.Remover_Click);
            // 
            // rProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 589);
            this.Controls.Add(this.remover);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.PrecionumericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TipotextBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PreciosdataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Nuevo);
            this.Controls.Add(this.ExisencianumericUpDown3);
            this.Controls.Add(this.CostonumericUpDown2);
            this.Controls.Add(this.ProductoIdnumericUpDown1);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.InventariotextBox4);
            this.Controls.Add(this.DescripciontextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "rProductos";
            this.Text = "rProductos";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExisencianumericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CostonumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductoIdnumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PreciosdataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrecionumericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.NumericUpDown ExisencianumericUpDown3;
        private System.Windows.Forms.NumericUpDown CostonumericUpDown2;
        private System.Windows.Forms.NumericUpDown ProductoIdnumericUpDown1;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.TextBox InventariotextBox4;
        private System.Windows.Forms.TextBox DescripciontextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView PreciosdataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TipotextBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown PrecionumericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button remover;
        private System.Windows.Forms.Button button3;
    }
}