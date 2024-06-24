namespace oplab4_Mykytiuk_Anatolii
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
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            label1 = new Label();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(623, 337);
            button1.Name = "button1";
            button1.Size = new Size(147, 32);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(167, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(285, 30);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(167, 71);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(285, 30);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(167, 118);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(285, 30);
            textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 25);
            label1.Name = "label1";
            label1.Size = new Size(48, 23);
            label1.TabIndex = 4;
            label1.Text = "mark";
            label1.Click += label1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(167, 170);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(285, 30);
            textBox4.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(167, 219);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(285, 30);
            textBox5.TabIndex = 6;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(167, 267);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(285, 30);
            textBox6.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 71);
            label2.Name = "label2";
            label2.Size = new Size(94, 23);
            label2.TabIndex = 8;
            label2.Text = "production";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 118);
            label3.Name = "label3";
            label3.Size = new Size(125, 23);
            label3.TabIndex = 9;
            label3.Text = "expiration date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(58, 170);
            label4.Name = "label4";
            label4.Size = new Size(71, 23);
            label4.TabIndex = 10;
            label4.Text = "nicotine";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 219);
            label5.Name = "label5";
            label5.Size = new Size(53, 23);
            label5.TabIndex = 11;
            label5.Text = "name";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(71, 267);
            label6.Name = "label6";
            label6.Size = new Size(47, 23);
            label6.TabIndex = 12;
            label6.Text = "price";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label label1;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox6;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
