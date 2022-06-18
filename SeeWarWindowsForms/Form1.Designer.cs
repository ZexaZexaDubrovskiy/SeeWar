namespace SeeWarWindowsForms
{
    partial class Form1
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
            this.mainWindowClass1 = new SeeWar.MainWindowClass();
            this.ShipsBotlace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainWindowClass1
            // 
            this.mainWindowClass1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainWindowClass1.Location = new System.Drawing.Point(0, 0);
            this.mainWindowClass1.Name = "mainWindowClass1";
            this.mainWindowClass1.Size = new System.Drawing.Size(827, 827);
            this.mainWindowClass1.TabIndex = 0;
            this.mainWindowClass1.Text = "mainWindowClass1";
            this.mainWindowClass1.Click += new System.EventHandler(this.mainWindowClass1_Click);
            // 
            // ShipsBotlace
            // 
            this.ShipsBotlace.Location = new System.Drawing.Point(13, 430);
            this.ShipsBotlace.Name = "ShipsBotlace";
            this.ShipsBotlace.Size = new System.Drawing.Size(200, 72);
            this.ShipsBotlace.TabIndex = 1;
            this.ShipsBotlace.Text = "Заспавнить корабли бота";
            this.ShipsBotlace.UseVisualStyleBackColor = true;
            this.ShipsBotlace.Click += new System.EventHandler(this.ShipsBotlace_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 827);
            this.Controls.Add(this.ShipsBotlace);
            this.Controls.Add(this.mainWindowClass1);
            this.MinimumSize = new System.Drawing.Size(850, 850);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private SeeWar.MainWindowClass mainWindowClass1;
        private System.Windows.Forms.Button ShipsBotlace;
    }
}

