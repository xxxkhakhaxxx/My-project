
namespace Motor_Control_GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbb_window = new System.Windows.Forms.ComboBox();
            this.cbb_port = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.btn_disconnect = new System.Windows.Forms.Button();
            this.Serial_Port = new System.IO.Ports.SerialPort(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_m1 = new System.Windows.Forms.TextBox();
            this.tb_m2 = new System.Windows.Forms.TextBox();
            this.btn_up2 = new System.Windows.Forms.Button();
            this.btn_down1 = new System.Windows.Forms.Button();
            this.btn_down2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_n1 = new System.Windows.Forms.TextBox();
            this.tb_l1 = new System.Windows.Forms.TextBox();
            this.tb_h1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.toggleButton1 = new CustomToolbox.CustomToolbox.ToggleButton();
            this.btn_home = new System.Windows.Forms.Button();
            this.btn_up1 = new System.Windows.Forms.Button();
            this.tb_k1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbb_window
            // 
            this.cbb_window.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_window.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_window.FormattingEnabled = true;
            this.cbb_window.Items.AddRange(new object[] {
            "                     HOME",
            "                   MANUAL",
            "                     AUTO"});
            this.cbb_window.Location = new System.Drawing.Point(26, 14);
            this.cbb_window.Name = "cbb_window";
            this.cbb_window.Size = new System.Drawing.Size(328, 35);
            this.cbb_window.TabIndex = 0;
            this.cbb_window.SelectedIndexChanged += new System.EventHandler(this.cbb_window_SelectedIndexChanged);
            this.cbb_window.Click += new System.EventHandler(this.cbb_window_Click);
            // 
            // cbb_port
            // 
            this.cbb_port.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_port.FormattingEnabled = true;
            this.cbb_port.Location = new System.Drawing.Point(191, 160);
            this.cbb_port.Name = "cbb_port";
            this.cbb_port.Size = new System.Drawing.Size(163, 35);
            this.cbb_port.TabIndex = 1;
            this.cbb_port.Click += new System.EventHandler(this.cbb_port_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM Port";
            // 
            // btn_connect
            // 
            this.btn_connect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(255)))), ((int)(((byte)(80)))));
            this.btn_connect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_connect.Location = new System.Drawing.Point(26, 217);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(162, 42);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "Connect";
            this.btn_connect.UseVisualStyleBackColor = false;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // btn_disconnect
            // 
            this.btn_disconnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_disconnect.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_disconnect.Location = new System.Drawing.Point(191, 217);
            this.btn_disconnect.Name = "btn_disconnect";
            this.btn_disconnect.Size = new System.Drawing.Size(163, 42);
            this.btn_disconnect.TabIndex = 4;
            this.btn_disconnect.Text = "Disconnect";
            this.btn_disconnect.UseVisualStyleBackColor = false;
            this.btn_disconnect.Click += new System.EventHandler(this.btn_disconnect_Click);
            // 
            // Serial_Port
            // 
            this.Serial_Port.BaudRate = 115200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Relay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Motor X (mm)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Motor Y (μm)";
            // 
            // tb_m1
            // 
            this.tb_m1.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_m1.Location = new System.Drawing.Point(171, 146);
            this.tb_m1.MaxLength = 3;
            this.tb_m1.Name = "tb_m1";
            this.tb_m1.Size = new System.Drawing.Size(80, 39);
            this.tb_m1.TabIndex = 8;
            this.tb_m1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_m1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_m1_KeyPress);
            // 
            // tb_m2
            // 
            this.tb_m2.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_m2.Location = new System.Drawing.Point(171, 219);
            this.tb_m2.MaxLength = 3;
            this.tb_m2.Name = "tb_m2";
            this.tb_m2.Size = new System.Drawing.Size(80, 39);
            this.tb_m2.TabIndex = 9;
            this.tb_m2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_m2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_m2_KeyPress);
            // 
            // btn_up2
            // 
            this.btn_up2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_up2.Location = new System.Drawing.Point(306, 219);
            this.btn_up2.Name = "btn_up2";
            this.btn_up2.Size = new System.Drawing.Size(41, 39);
            this.btn_up2.TabIndex = 11;
            this.btn_up2.Text = "+";
            this.btn_up2.UseVisualStyleBackColor = true;
            this.btn_up2.Click += new System.EventHandler(this.btn_up2_Click);
            // 
            // btn_down1
            // 
            this.btn_down1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_down1.Location = new System.Drawing.Point(259, 146);
            this.btn_down1.Name = "btn_down1";
            this.btn_down1.Size = new System.Drawing.Size(41, 39);
            this.btn_down1.TabIndex = 12;
            this.btn_down1.Text = "–";
            this.btn_down1.UseVisualStyleBackColor = true;
            this.btn_down1.Click += new System.EventHandler(this.btn_down1_Click);
            // 
            // btn_down2
            // 
            this.btn_down2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_down2.Location = new System.Drawing.Point(259, 219);
            this.btn_down2.Name = "btn_down2";
            this.btn_down2.Size = new System.Drawing.Size(41, 39);
            this.btn_down2.TabIndex = 13;
            this.btn_down2.Text = "–";
            this.btn_down2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_down2.UseVisualStyleBackColor = true;
            this.btn_down2.Click += new System.EventHandler(this.btn_down2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(204, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 27);
            this.label5.TabIndex = 16;
            this.label5.Text = "H";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(51, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 27);
            this.label7.TabIndex = 14;
            this.label7.Text = "N";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(205, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 27);
            this.label8.TabIndex = 17;
            this.label8.Text = "L";
            // 
            // tb_n1
            // 
            this.tb_n1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_n1.Location = new System.Drawing.Point(79, 79);
            this.tb_n1.MaxLength = 3;
            this.tb_n1.Name = "tb_n1";
            this.tb_n1.Size = new System.Drawing.Size(72, 35);
            this.tb_n1.TabIndex = 18;
            this.tb_n1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_n1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_n1_KeyPress);
            // 
            // tb_l1
            // 
            this.tb_l1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_l1.Location = new System.Drawing.Point(232, 79);
            this.tb_l1.MaxLength = 3;
            this.tb_l1.Name = "tb_l1";
            this.tb_l1.Size = new System.Drawing.Size(72, 35);
            this.tb_l1.TabIndex = 21;
            this.tb_l1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_l1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_l1_KeyPress);
            // 
            // tb_h1
            // 
            this.tb_h1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_h1.Location = new System.Drawing.Point(232, 130);
            this.tb_h1.MaxLength = 3;
            this.tb_h1.Name = "tb_h1";
            this.tb_h1.Size = new System.Drawing.Size(72, 35);
            this.tb_h1.TabIndex = 20;
            this.tb_h1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_h1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_h1_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(302, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 27);
            this.label10.TabIndex = 23;
            this.label10.Text = "μm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(302, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 27);
            this.label11.TabIndex = 24;
            this.label11.Text = "mm";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(255)))));
            this.btn_start.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.Location = new System.Drawing.Point(43, 192);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(122, 42);
            this.btn_start.TabIndex = 26;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btn_stop.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_stop.Location = new System.Drawing.Point(212, 192);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(122, 42);
            this.btn_stop.TabIndex = 27;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = false;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // toggleButton1
            // 
            this.toggleButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.toggleButton1.Location = new System.Drawing.Point(135, 74);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(52, 25);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackColor = System.Drawing.Color.Red;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackColor = System.Drawing.Color.Lime;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(212, 40);
            this.toggleButton1.TabIndex = 28;
            this.toggleButton1.UseVisualStyleBackColor = true;
            this.toggleButton1.CheckedChanged += new System.EventHandler(this.toggleButton1_CheckedChanged);
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(255)))), ((int)(((byte)(80)))));
            this.btn_home.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_home.Location = new System.Drawing.Point(128, 162);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(122, 42);
            this.btn_home.TabIndex = 25;
            this.btn_home.Text = "Home";
            this.btn_home.UseVisualStyleBackColor = false;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_up1
            // 
            this.btn_up1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_up1.Location = new System.Drawing.Point(306, 146);
            this.btn_up1.Name = "btn_up1";
            this.btn_up1.Size = new System.Drawing.Size(41, 39);
            this.btn_up1.TabIndex = 10;
            this.btn_up1.Text = "+";
            this.btn_up1.UseVisualStyleBackColor = true;
            this.btn_up1.Click += new System.EventHandler(this.btn_up1_Click);
            // 
            // tb_k1
            // 
            this.tb_k1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_k1.Location = new System.Drawing.Point(79, 130);
            this.tb_k1.MaxLength = 3;
            this.tb_k1.Name = "tb_k1";
            this.tb_k1.Size = new System.Drawing.Size(72, 35);
            this.tb_k1.TabIndex = 30;
            this.tb_k1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(51, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 27);
            this.label6.TabIndex = 29;
            this.label6.Text = "K";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(381, 272);
            this.Controls.Add(this.tb_k1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.btn_home);
            this.Controls.Add(this.tb_l1);
            this.Controls.Add(this.tb_h1);
            this.Controls.Add(this.tb_n1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btn_down2);
            this.Controls.Add(this.btn_down1);
            this.Controls.Add(this.btn_up2);
            this.Controls.Add(this.btn_up1);
            this.Controls.Add(this.tb_m2);
            this.Controls.Add(this.tb_m1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_disconnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbb_port);
            this.Controls.Add(this.cbb_window);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toggleButton1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2-AXIS MOTOR CONTROL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbb_window;
        private System.Windows.Forms.ComboBox cbb_port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnect;
        private System.IO.Ports.SerialPort Serial_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_m1;
        private System.Windows.Forms.TextBox tb_m2;
        private System.Windows.Forms.Button btn_up2;
        private System.Windows.Forms.Button btn_down1;
        private System.Windows.Forms.Button btn_down2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_n1;
        private System.Windows.Forms.TextBox tb_l1;
        private System.Windows.Forms.TextBox tb_h1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private CustomToolbox.CustomToolbox.ToggleButton toggleButton1;
        private System.Windows.Forms.Button btn_home;
        private System.Windows.Forms.Button btn_up1;
        private System.Windows.Forms.TextBox tb_k1;
        private System.Windows.Forms.Label label6;
    }
}

