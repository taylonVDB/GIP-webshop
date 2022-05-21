namespace Presentation
{
    partial class ProductOverzicht
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductOverzicht));
            this.label1 = new System.Windows.Forms.Label();
            this.categorieComboBox = new System.Windows.Forms.ComboBox();
            this.productenListbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.infoBestelButton = new System.Windows.Forms.Button();
            this.aantalBesteldeProductenLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fotoPicturebox = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Kies categorie: ";
            // 
            // categorieComboBox
            // 
            this.categorieComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.categorieComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categorieComboBox.ForeColor = System.Drawing.Color.White;
            this.categorieComboBox.FormattingEnabled = true;
            this.categorieComboBox.Location = new System.Drawing.Point(193, 15);
            this.categorieComboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.categorieComboBox.Name = "categorieComboBox";
            this.categorieComboBox.Size = new System.Drawing.Size(448, 24);
            this.categorieComboBox.TabIndex = 1;
            this.categorieComboBox.SelectedIndexChanged += new System.EventHandler(this.categorieComboBox_SelectedIndexChanged);
            // 
            // productenListbox
            // 
            this.productenListbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.productenListbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.productenListbox.ForeColor = System.Drawing.Color.White;
            this.productenListbox.FormattingEnabled = true;
            this.productenListbox.ItemHeight = 16;
            this.productenListbox.Location = new System.Drawing.Point(193, 71);
            this.productenListbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.productenListbox.Name = "productenListbox";
            this.productenListbox.Size = new System.Drawing.Size(449, 128);
            this.productenListbox.TabIndex = 2;
            this.productenListbox.SelectedIndexChanged += new System.EventHandler(this.productenListbox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Overzicht producten: ";
            // 
            // infoBestelButton
            // 
            this.infoBestelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.infoBestelButton.FlatAppearance.BorderSize = 0;
            this.infoBestelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoBestelButton.ForeColor = System.Drawing.Color.White;
            this.infoBestelButton.Location = new System.Drawing.Point(675, 15);
            this.infoBestelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoBestelButton.Name = "infoBestelButton";
            this.infoBestelButton.Size = new System.Drawing.Size(288, 57);
            this.infoBestelButton.TabIndex = 4;
            this.infoBestelButton.Text = "Toon info / bestel deze wagen";
            this.infoBestelButton.UseVisualStyleBackColor = false;
            this.infoBestelButton.Click += new System.EventHandler(this.infoBestelButton_Click);
            // 
            // aantalBesteldeProductenLabel
            // 
            this.aantalBesteldeProductenLabel.AutoSize = true;
            this.aantalBesteldeProductenLabel.ForeColor = System.Drawing.Color.White;
            this.aantalBesteldeProductenLabel.Location = new System.Drawing.Point(925, 278);
            this.aantalBesteldeProductenLabel.Name = "aantalBesteldeProductenLabel";
            this.aantalBesteldeProductenLabel.Size = new System.Drawing.Size(16, 17);
            this.aantalBesteldeProductenLabel.TabIndex = 5;
            this.aantalBesteldeProductenLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(692, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Aantal producten in winkelkar: ";
            // 
            // fotoPicturebox
            // 
            this.fotoPicturebox.BackColor = System.Drawing.Color.Transparent;
            this.fotoPicturebox.Location = new System.Drawing.Point(193, 206);
            this.fotoPicturebox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fotoPicturebox.Name = "fotoPicturebox";
            this.fotoPicturebox.Size = new System.Drawing.Size(449, 246);
            this.fotoPicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fotoPicturebox.TabIndex = 8;
            this.fotoPicturebox.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(577, 425);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(400, 160);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 17;
            this.pictureBox6.TabStop = false;
            // 
            // ProductOverzicht
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(977, 587);
            this.Controls.Add(this.fotoPicturebox);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.aantalBesteldeProductenLabel);
            this.Controls.Add(this.infoBestelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.productenListbox);
            this.Controls.Add(this.categorieComboBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProductOverzicht";
            this.Text = "Overzicht producnten per categorie.";
            ((System.ComponentModel.ISupportInitialize)(this.fotoPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categorieComboBox;
        private System.Windows.Forms.ListBox productenListbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button infoBestelButton;
        private System.Windows.Forms.Label aantalBesteldeProductenLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox fotoPicturebox;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}

