namespace Presentation
{
    partial class NietAangemeldForm
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
            this.wagensopvoorraadLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // wagensopvoorraadLabel
            // 
            this.wagensopvoorraadLabel.AutoSize = true;
            this.wagensopvoorraadLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wagensopvoorraadLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(249)))));
            this.wagensopvoorraadLabel.Location = new System.Drawing.Point(39, 189);
            this.wagensopvoorraadLabel.Name = "wagensopvoorraadLabel";
            this.wagensopvoorraadLabel.Size = new System.Drawing.Size(652, 84);
            this.wagensopvoorraadLabel.TabIndex = 3;
            this.wagensopvoorraadLabel.Text = "Je bent niet aangemeld gelieve\r\nje aan te melden via de \'instellingen\'\r\n";
            this.wagensopvoorraadLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NietAangemeldForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.wagensopvoorraadLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NietAangemeldForm";
            this.Text = "NietAangemeldForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label wagensopvoorraadLabel;
    }
}