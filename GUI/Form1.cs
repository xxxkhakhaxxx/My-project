using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Thư viện thêm vào
using System.IO.Ports;


namespace Motor_Control_GUI
{
    public partial class Form1 : Form
    {
        // ------------------- Cac bien ban dau ------------------------ //
     

        // ------------------------- Form ------------------------------ //
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)                         // Chạy hàm này khi khởi động App
        {
            cbb_window.SelectedIndex = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)         // Chạy hàm này khi tat App
        {
            if(Serial_Port.IsOpen)                                              // Neu dang mo Serial Port thi dong no lai
            {
                send_information(Serial_Port, "A", "1", "000");                 // Stop moi thu dang chay
                Serial_Port.Close();
            }
        }

       

        #region Các đối tượng trong Home
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ //
        private void cbb_window_SelectedIndexChanged(object sender, EventArgs e)    // Thay đổi cửa sổ ứng với từng chế độ Home, Manual, Auto
        {            
            if (cbb_window.SelectedIndex == 0)                         // Chế độ hiển thị Home
            {
                label1.Visible = true;
                cbb_port.Visible = true;
                btn_connect.Visible = true;
                btn_disconnect.Visible = true;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                toggleButton1.Visible = false;
                tb_m1.Visible = false;
                tb_m2.Visible = false;
                btn_down1.Visible = false;
                btn_down2.Visible = false;
                btn_up1.Visible = false;
                btn_up2.Visible = false;

                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                //label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                tb_n1.Visible = false;
                tb_l1.Visible = false;
                tb_h1.Visible = false;
                tb_k1.Visible = false;
                btn_home.Visible = false;
                btn_start.Visible = false;
                btn_stop.Visible = false;
            }
            else if (cbb_window.SelectedIndex == 1)                    // Chế độ hiển thị Manual
            {
                label1.Visible = false;
                cbb_port.Visible = false;
                btn_connect.Visible = false;
                btn_disconnect.Visible = false;

                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                toggleButton1.Visible = true;
                tb_m1.Visible = true;
                tb_m2.Visible = true;
                btn_down1.Visible = true;
                btn_down2.Visible = true;
                btn_up1.Visible = true;
                btn_up2.Visible = true;
                tb_m1.Text = "0";       // Reset giá trị của textbox m1 về 0
                tb_m2.Text = "0";       // Reset giá trị của textbox m2 về 0
                toggleButton1.Checked = false;

                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                //label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                tb_n1.Visible = false;
                tb_l1.Visible = false;
                tb_h1.Visible = false;
                tb_k1.Visible = false;
                btn_home.Visible = false;
                btn_start.Visible = false;
                btn_stop.Visible = false;
            }
            else                                                    // Chế độ hiển thị Auto
            {
                label1.Visible = false;
                cbb_port.Visible = false;
                btn_connect.Visible = false;
                btn_disconnect.Visible = false;

                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                toggleButton1.Visible = false;
                tb_m1.Visible = false;
                tb_m2.Visible = false;
                btn_down1.Visible = false;
                btn_down2.Visible = false;
                btn_up1.Visible = false;
                btn_up2.Visible = false;

                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                //label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                tb_n1.Visible = true;
                tb_l1.Visible = true;
                tb_h1.Visible = true;
                tb_k1.Visible = true;
                btn_home.Visible = false;       // Tạm thời không dùng nút Home
                btn_start.Visible = true;
                btn_stop.Visible = true;
                tb_n1.Text = "1";             // Reset giá trị của textbox n1 về 1
                tb_k1.Text = "0";             // Reset giá trị của textbox t1 về 0
                tb_h1.Text = "0";             // Reset giá trị của textbox h1 về 0
                tb_l1.Text = "0";             // Reset giá trị của textbox l1 về 0
            }
            if ((Serial_Port.IsOpen) && (cbb_window.SelectedIndex == 2))
                send_information(Serial_Port, "A", "3", "000");
            else if (Serial_Port.IsOpen)
                send_information(Serial_Port, "A", "1", "000");
        }
        private void cbb_window_Click(object sender, EventArgs e)
        {
            if (!Serial_Port.IsOpen)
                MessageBox.Show("Please choose connect port", "Notification");
        }

        private void cbb_port_Click(object sender, EventArgs e)                     // Chọn Port
        {
            cbb_port.Text = null;                                   // Xóa bảng hiển thị trước khi bắt đầu quét
            cbb_port.DataSource = SerialPort.GetPortNames();        // Lấy tên các cổng Port đang mở
        }

        private void btn_connect_Click(object sender, EventArgs e)                  // Nhấn nút kết nối
        {
            if(cbb_port.SelectedItem == null)
                MessageBox.Show("Please choose connect port", "Notification");
            else
            {
                if (!Serial_Port.IsOpen)                                 // Neu chua mo serial port
                {
                    Serial_Port.PortName = cbb_port.Text;               // Xac dinh ten cong serial theo cong port da chon o combobox_port
                    Serial_Port.Open();                                 // Mo cong serial port
                    MessageBox.Show("Connected!", "Notification");      // Thong bao xac nhan ket noi
                    send_information(Serial_Port, "A", "1", "000");         // Stop moi thu dang chay
                }
            }     
        }

        private void btn_disconnect_Click(object sender, EventArgs e)               // Nhấn nút ngắt kết nối
        {
            if (Serial_Port.IsOpen)
            {
                send_information(Serial_Port, "A", "1", "000");         // Stop moi thu dang chay
                Serial_Port.Close();                                    // Dong cong Serial Port
                MessageBox.Show("Disconnected!", "Notification");       // Thong bao dong cong ket noi
            }
                
        }
        #endregion

        #region Các đối tượng trong Manual
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ //
        private void toggleButton1_CheckedChanged(object sender, EventArgs e)     // Nút relay      : M0-000/001
        {
            if (toggleButton1.Checked)                                      // Nếu True - tức màu xanh lá (ON)
                send_information(Serial_Port, "M", "0", "001");               // Nội dung: Manual - relay - ON
            else                                                            // Nếu False - tức màu đỏ (OFF)
                send_information(Serial_Port, "M", "0", "000");               // Nội dung: Manual - relay - OFF
        }  
        
        private void btn_down1_Click(object sender, EventArgs e)                  // Nút "-" motor 1: M1-xxx
        {

            send_information(Serial_Port, "M", "1", check_tb_value(tb_m1));            // Nội dung: Manual - motor 1 - xuống 1 khoảng
        }               

        private void btn_down2_Click(object sender, EventArgs e)                  // Nút "-" motor 2: M3-xxx
        {
            send_information(Serial_Port, "M", "3", check_tb_value(tb_m2));            // Nội dung: Manual - motor 2 - xuống 1 khoảng
        }               

        private void btn_up1_Click(object sender, EventArgs e)                    // Nút "+" motor 1: M2-xxx
        {
            send_information(Serial_Port, "M", "2", check_tb_value(tb_m1));            // Nội dung: Manual - motor 1 - lên 1 khoảng
        }                 

        private void btn_up2_Click(object sender, EventArgs e)                    // Nút "+" motor 2: M4-xxx
        {
            send_information(Serial_Port, "M", "4", check_tb_value(tb_m2));            // Nội dung: Manual - motor 2 - lên 1 khoảng
        }

        private void tb_m1_KeyPress(object sender, KeyPressEventArgs e)           // Kiểm tra kí hiệu gõ vào textbox m1
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }

        private void tb_m2_KeyPress(object sender, KeyPressEventArgs e)           // Kiểm tra kí hiệu gõ vào textbox m2
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }
        #endregion

        #region Các đối tượng trong Auto 
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++ //
        private void btn_home_Click(object sender, EventArgs e)                   // Nut home: A0000
        {
            send_information(Serial_Port, "A", "0", "000");
        }                

        private void btn_start_Click(object sender, EventArgs e)                  // Nut start: A2xxx:xxx:xxx:xxx
        {
            if((tb_h1.Text=="0")||(tb_k1.Text == "0")||(tb_l1.Text=="0")||(tb_n1.Text=="0"))
                MessageBox.Show("Cannot let value = 0!", "Notification");
            else
            {
                string data_message = String.Concat(check_tb_value(tb_n1), ":", check_tb_value(tb_k1), ":", check_tb_value(tb_h1), ":", check_tb_value(tb_l1));
                send_information(Serial_Port, "A", "2", data_message);
            }
            
        }               

        private void btn_stop_Click(object sender, EventArgs e)                   // Nut stop: A1000
        {
            send_information(Serial_Port, "A", "1", "000");
        }

        private void tb_n1_KeyPress(object sender, KeyPressEventArgs e)    // Kiểm tra kí hiệu gõ vào textbox n1
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }

        private void tb_t1_KeyPress(object sender, KeyPressEventArgs e)    // Kiểm tra kí hiệu gõ vào textbox t1
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }

        private void tb_h1_KeyPress(object sender, KeyPressEventArgs e)    // Kiểm tra kí hiệu gõ vào textbox h1
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }

        private void tb_l1_KeyPress(object sender, KeyPressEventArgs e)    // Kiểm tra kí hiệu gõ vào textbox l1
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))    // Kiểm tra liệu kí tự nút nhấn là số hay chức năng
                e.Handled = true;                                          // Đúng thì mới nhận kí tự
        }

        #endregion

        // ++++++++++++++ Ham giao tiep khi nhan cac nut ++++++++++++++++++++++++++++++++++++++++++++++ //
        static void send_information(SerialPort port, string ID_Window, string ID_Object, string Value)
        {
            string transfer_message = String.Concat(ID_Window,ID_Object,Value,"\n");
            port.Write(transfer_message);
            //MessageBox.Show(transfer_message, "Your message");
        }

        static string check_tb_value(System.Windows.Forms.TextBox a)     // Kiểm tra và trả về giá trị trong textbox luôn 3 kí tự
        {
            string temp_value;
            if (a.TextLength == 0)
                temp_value = "000";
            else if (a.TextLength == 1)
                temp_value = String.Concat("00", a.Text);
            else if (a.TextLength == 2)
                temp_value = String.Concat("0", a.Text);
            else
                temp_value = a.Text;
            return temp_value;
        }


    }
}
