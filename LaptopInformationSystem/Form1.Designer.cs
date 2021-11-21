namespace LaptopInformationSystem
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
            this.grpLaptopInformationSystem = new System.Windows.Forms.GroupBox();
            this.btnAddDevices = new System.Windows.Forms.Button();
            this.grpLaptopInformationSystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLaptopInformationSystem
            // 
            this.grpLaptopInformationSystem.Controls.Add(this.btnAddDevices);
            this.grpLaptopInformationSystem.Location = new System.Drawing.Point(2, 0);
            this.grpLaptopInformationSystem.Name = "grpLaptopInformationSystem";
            this.grpLaptopInformationSystem.Size = new System.Drawing.Size(1042, 559);
            this.grpLaptopInformationSystem.TabIndex = 0;
            this.grpLaptopInformationSystem.TabStop = false;
            this.grpLaptopInformationSystem.Text = "Laptop information system";
            this.grpLaptopInformationSystem.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAddDevices
            // 
            this.btnAddDevices.Location = new System.Drawing.Point(10, 40);
            this.btnAddDevices.Name = "btnAddDevices";
            this.btnAddDevices.Size = new System.Drawing.Size(894, 73);
            this.btnAddDevices.TabIndex = 0;
            this.btnAddDevices.Text = "Add Devices";
            this.btnAddDevices.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 559);
            this.Controls.Add(this.grpLaptopInformationSystem);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpLaptopInformationSystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLaptopInformationSystem;
        private System.Windows.Forms.Button btnAddDevices;
    }
}

