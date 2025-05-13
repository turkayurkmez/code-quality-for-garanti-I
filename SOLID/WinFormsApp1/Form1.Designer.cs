namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonColorChanger = new Button();
            textBoxProductName = new TextBox();
            textBoxPrice = new TextBox();
            buttonCreate = new Button();
            SuspendLayout();
            // 
            // buttonColorChanger
            // 
            buttonColorChanger.Location = new Point(288, 316);
            buttonColorChanger.Name = "buttonColorChanger";
            buttonColorChanger.Size = new Size(129, 23);
            buttonColorChanger.TabIndex = 0;
            buttonColorChanger.Text = "Change Backcolor";
            buttonColorChanger.UseVisualStyleBackColor = true;
            buttonColorChanger.Click += buttonColorChanger_Click;
            // 
            // textBoxProductName
            // 
            textBoxProductName.Location = new Point(149, 103);
            textBoxProductName.Name = "textBoxProductName";
            textBoxProductName.Size = new Size(100, 23);
            textBoxProductName.TabIndex = 1;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(149, 132);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(100, 23);
            textBoxPrice.TabIndex = 2;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(207, 166);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(75, 23);
            buttonCreate.TabIndex = 3;
            buttonCreate.Text = "Create";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 351);
            Controls.Add(buttonCreate);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxProductName);
            Controls.Add(buttonColorChanger);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonColorChanger;
        private TextBox textBoxProductName;
        private TextBox textBoxPrice;
        private Button buttonCreate;
    }
}
