namespace Final_Project_DSA;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        checkBox2 = new System.Windows.Forms.CheckBox();
        panel1 = new System.Windows.Forms.Panel();
        SuspendLayout();
        // 
        // checkBox2
        // 
        checkBox2.Location = new System.Drawing.Point(15267, 7560);
        checkBox2.Margin = new System.Windows.Forms.Padding(56, 41, 56, 41);
        checkBox2.Name = "checkBox2";
        checkBox2.Size = new System.Drawing.Size(2837, 549);
        checkBox2.TabIndex = 2;
        checkBox2.Text = "Bubble Sort";
        checkBox2.UseVisualStyleBackColor = true;
        // 
        // panel1
        // 
        panel1.BackColor = System.Drawing.Color.Plum;
        panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        panel1.Location = new System.Drawing.Point(0, 0);
        panel1.Margin = new System.Windows.Forms.Padding(19, 15, 19, 15);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(18104, 8109);
        panel1.TabIndex = 3;
        // 
        // Form1
        // 
        AccessibleName = "Data Structure and Algorithms ";
        AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        AutoScroll = true;
        AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
        BackColor = System.Drawing.Color.RosyBrown;
        ClientSize = new System.Drawing.Size(1406, 953);
        Controls.Add(panel1);
        Controls.Add(checkBox2);
        Font = new System.Drawing.Font("JetBrains Mono SemiBold", 11.999998F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        Margin = new System.Windows.Forms.Padding(4);
        Text = "Data Structure and Algorithms";
        TransparencyKey = System.Drawing.Color.White;
        Load += Form1_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.CheckBox checkBox2;

    #endregion
}