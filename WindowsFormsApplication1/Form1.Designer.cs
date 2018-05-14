namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lLangHand = new System.Windows.Forms.Label();
            this.bChangeLangHand = new System.Windows.Forms.Button();
            this.lbAllLangHand = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bSetHook = new System.Windows.Forms.Button();
            this.bUnHook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Now Lang Hand: ";
            // 
            // lLangHand
            // 
            this.lLangHand.AutoSize = true;
            this.lLangHand.Location = new System.Drawing.Point(126, 20);
            this.lLangHand.Name = "lLangHand";
            this.lLangHand.Size = new System.Drawing.Size(37, 13);
            this.lLangHand.TabIndex = 1;
            this.lLangHand.Text = "00000";
            // 
            // bChangeLangHand
            // 
            this.bChangeLangHand.Location = new System.Drawing.Point(236, 12);
            this.bChangeLangHand.Name = "bChangeLangHand";
            this.bChangeLangHand.Size = new System.Drawing.Size(91, 28);
            this.bChangeLangHand.TabIndex = 2;
            this.bChangeLangHand.Text = "Change";
            this.bChangeLangHand.UseVisualStyleBackColor = true;
            this.bChangeLangHand.Click += new System.EventHandler(this.changeLangHand_Click);
            // 
            // lbAllLangHand
            // 
            this.lbAllLangHand.FormattingEnabled = true;
            this.lbAllLangHand.Location = new System.Drawing.Point(408, 20);
            this.lbAllLangHand.Name = "lbAllLangHand";
            this.lbAllLangHand.Size = new System.Drawing.Size(120, 264);
            this.lbAllLangHand.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 262);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 226);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // bSetHook
            // 
            this.bSetHook.Location = new System.Drawing.Point(236, 46);
            this.bSetHook.Name = "bSetHook";
            this.bSetHook.Size = new System.Drawing.Size(91, 41);
            this.bSetHook.TabIndex = 6;
            this.bSetHook.Text = "SetHook";
            this.bSetHook.UseVisualStyleBackColor = true;
            this.bSetHook.Click += new System.EventHandler(this.bSetHook_Click);
            // 
            // bUnHook
            // 
            this.bUnHook.Location = new System.Drawing.Point(236, 93);
            this.bUnHook.Name = "bUnHook";
            this.bUnHook.Size = new System.Drawing.Size(91, 41);
            this.bUnHook.TabIndex = 7;
            this.bUnHook.Text = "UnHook";
            this.bUnHook.UseVisualStyleBackColor = true;
            this.bUnHook.Click += new System.EventHandler(this.bUnHook_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 294);
            this.Controls.Add(this.bUnHook);
            this.Controls.Add(this.bSetHook);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbAllLangHand);
            this.Controls.Add(this.bChangeLangHand);
            this.Controls.Add(this.lLangHand);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lLangHand;
        private System.Windows.Forms.Button bChangeLangHand;
        private System.Windows.Forms.ListBox lbAllLangHand;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSetHook;
        private System.Windows.Forms.Button bUnHook;
    }
}

