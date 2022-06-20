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
            this.ShipsBotlace = new System.Windows.Forms.Button();
            this.PlaceShipRangomHuman = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.CreateShipNonRandom = new System.Windows.Forms.Button();
            this.mainWindowClass1 = new SeeWar.MainWindowClass();
            this.VertHor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // ShipsBotlace
            // 
            this.ShipsBotlace.Location = new System.Drawing.Point(590, 403);
            this.ShipsBotlace.Name = "ShipsBotlace";
            this.ShipsBotlace.Size = new System.Drawing.Size(200, 72);
            this.ShipsBotlace.TabIndex = 1;
            this.ShipsBotlace.Text = "Заспавнить корабли бота";
            this.ShipsBotlace.UseVisualStyleBackColor = true;
            this.ShipsBotlace.Click += new System.EventHandler(this.ShipsBotlace_Click);
            // 
            // PlaceShipRangomHuman
            // 
            this.PlaceShipRangomHuman.Location = new System.Drawing.Point(384, 403);
            this.PlaceShipRangomHuman.Name = "PlaceShipRangomHuman";
            this.PlaceShipRangomHuman.Size = new System.Drawing.Size(200, 72);
            this.PlaceShipRangomHuman.TabIndex = 2;
            this.PlaceShipRangomHuman.Text = "Расставить свои корабли в случайном порядке";
            this.PlaceShipRangomHuman.UseVisualStyleBackColor = true;
            this.PlaceShipRangomHuman.Click += new System.EventHandler(this.PlaceShipRangomHuman_Click);
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(590, 498);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(200, 72);
            this.StartGame.TabIndex = 3;
            this.StartGame.Text = "Начать игру";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // CreateShipNonRandom
            // 
            this.CreateShipNonRandom.Location = new System.Drawing.Point(384, 498);
            this.CreateShipNonRandom.Name = "CreateShipNonRandom";
            this.CreateShipNonRandom.Size = new System.Drawing.Size(200, 72);
            this.CreateShipNonRandom.TabIndex = 4;
            this.CreateShipNonRandom.Text = "Расставить корабли самому";
            this.CreateShipNonRandom.UseVisualStyleBackColor = true;
            this.CreateShipNonRandom.Click += new System.EventHandler(this.CreateShipNonRandom_Click);
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
            // VertHor
            // 
            this.VertHor.AutoSize = true;
            this.VertHor.Location = new System.Drawing.Point(476, 610);
            this.VertHor.Name = "VertHor";
            this.VertHor.Size = new System.Drawing.Size(80, 17);
            this.VertHor.TabIndex = 5;
            this.VertHor.Text = "checkBox1";
            this.VertHor.UseVisualStyleBackColor = true;
            this.VertHor.CheckedChanged += new System.EventHandler(this.VertHor_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 827);
            this.Controls.Add(this.VertHor);
            this.Controls.Add(this.CreateShipNonRandom);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.PlaceShipRangomHuman);
            this.Controls.Add(this.ShipsBotlace);
            this.Controls.Add(this.mainWindowClass1);
            this.MinimumSize = new System.Drawing.Size(850, 850);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SeeWar.MainWindowClass mainWindowClass1;
        private System.Windows.Forms.Button ShipsBotlace;
        private System.Windows.Forms.Button PlaceShipRangomHuman;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button CreateShipNonRandom;
        private System.Windows.Forms.CheckBox VertHor;
    }
}

