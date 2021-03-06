using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLyLuong
{
    public partial class BaoMatPhanQuyen : Form
    {
        private SqlConnection conn;
        private SqlCommand commnd, comndUpdateQT, comndUpdatePQ, cmdLuuQT, commndDelPQ;
        private SqlDataAdapter da;
        private DataSet ds = new DataSet();

        public BaoMatPhanQuyen()
        {
            InitializeComponent();
        }
        // Hiện Thị Dữ Liệu Trong DataGrid!
        private void HienThiDuLieuPhanQuyen()
        {
            try
            {

                conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                conn.Open();
                commnd = new SqlCommand("select * from bQuanTri inner join bPhanQuyen on bQuanTri.MaPQ=bPhanQuyen.MaPQ", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "PhanQuyen");
                dgvPhanQuyen.DataSource = ds.Tables["PhanQuyen"].DefaultView;
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
        }
        public Boolean CheckDataPhanQuyen()
        {
            if (txttentruynhapQT.Text == "")
            {
                MessageBox.Show("Tên Truy Nhập Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttentruynhapQT.Focus();
                return false;
            }
            if (txtMatKhauQT.Text == "")
            {
                MessageBox.Show("Mật Khẩu Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhauQT.Focus();
                return false;
            }
            if (tXacNhanQT.Text == "")
            {
                MessageBox.Show(" Xác Nhận Mật Khẩu Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tXacNhanQT.Focus();
                return false;
            }
            if (txtMaQT.Text == "")
            {
                MessageBox.Show("Mã Quản Trị Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaQT.Focus();
                return false;
            }
            if (txtMaPQ.Text == "")
            {
                MessageBox.Show("Mã Phân Quyền Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaPQ.Focus();
                return false;
            }
            if (txtHoTenQT.Text == "")
            {
                MessageBox.Show(" Họ Tên Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTenQT.Focus();
                return false;
            }
            if (txtTenPhanQuyen.Text == "")
            {
                MessageBox.Show(" Tên phân quyền Ko Ðuợc Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenPhanQuyen.Focus();
                return false;
            }
            if (cbPB.Text == "")
            {
                MessageBox.Show(" Phòng Ban Ko Ðược Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbPB.Focus();
                return false;
            }
            if (txtDiaChiQT.Text == "")
            {
                MessageBox.Show(" Ðịa chỉ Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiaChiQT.Focus();
                return false;
            }
            if (txtDienThoaiQT.Text == "")
            {
                MessageBox.Show(" Ðiện thoại Không Ðược Ðể Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDienThoaiQT.Focus();
                return false;
            }
            if (txtEmailQT.Text == "")
            {
                MessageBox.Show(" Email Quản trị Không Được Để Trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmailQT.Focus();
                return false;
            }

            return true;
        }
        public void taomoi()
        {
            txttentruynhapQT.Text = "";
            txtMatKhauQT.Text = "";
            tXacNhanQT.Text = "";
            txtHoTenQT.Text = "";
            cbPB.Text = "";
            txtMaPQ.Text = "";
            txtTenPhanQuyen.Text = "";
            txtMaQT.Text = "";
            txtDiaChiQT.Text = "";
            txtEmailQT.Text = "";
            txtDienThoaiQT.Text = "";
            ckbAdmin.Checked = false;
            ckbQuanLyNV.Checked = false;
            ckbThanhToan.Checked = false;
            ckbTinhTienLuong.Checked = false;        
        }

        private void btnThemQ_Click(object sender, EventArgs e)
        {
            taomoi();
        }

        private void btnXemQ_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow != null)
            {

                txtMaQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[0].Value.ToString();
                txtMaPQ.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[1].Value.ToString();
                txttentruynhapQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[2].Value.ToString();
                txtMatKhauQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[3].Value.ToString();
                tXacNhanQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[3].Value.ToString();
                txtHoTenQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[4].Value.ToString();
                cbPB.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[5].Value.ToString();
                txtDiaChiQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[6].Value.ToString();
                txtDienThoaiQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[7].Value.ToString();
                txtEmailQT.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[8].Value.ToString();
                txtMaPQ.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[9].Value.ToString();
                txtTenPhanQuyen.Text = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[10].Value.ToString();
                //----------------------
                string biQLNV = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[11].Value.ToString();

                if (biQLNV == "True")
                {

                    ckbQuanLyNV.Checked = true;
                }
                else
                {
                    ckbQuanLyNV.Checked = false;
                }

                //-------------------------------
                string biTinhLuong = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[12].Value.ToString();
                if (biTinhLuong == "True")
                {

                    ckbTinhTienLuong.Checked = true;
                }
                else
                {
                    ckbTinhTienLuong.Checked = false;
                }

                //-------------------------------
                string biThanhToan = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[13].Value.ToString();
                if (biThanhToan == "True")
                {

                    ckbThanhToan.Checked = true;
                }
                else
                {
                    ckbThanhToan.Checked = false;
                }
                //-----------------------------
                string biAdmin = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[14].Value.ToString();
                if (biAdmin == "True")
                {

                    ckbAdmin.Checked = true;
                }
                else
                {
                    ckbAdmin.Checked = false;                    
                }
            } 
        }

        private void BaoMatPhanQuyen_Load(object sender, EventArgs e)
        {
            HienThiDuLieuPhanQuyen();
        }

        private void btnLuuQ_Click(object sender, EventArgs e)
        {
            if (CheckDataPhanQuyen() == true)
            {
                string PQMaQT = txtMaQT.Text;
                string PQHoTen = txtHoTenQT.Text;
                string PQTenTruyCap = txttentruynhapQT.Text;
                string PQMatKhau = txtMatKhauQT.Text;
                string PQXacNhan = tXacNhanQT.Text;
                string PQPhongBan = cbPB.Text;
                string PQTenPhanQuyen = txtTenPhanQuyen.Text;
                string PQMaPQ = txtMaPQ.Text;
                string PQDiaChi = txtDiaChiQT.Text;
                int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
                string PQEmail = txtEmailQT.Text;
                //----------------------
                int PQQLNV;
                int PQTinhTienLuong;
                int PQThanhToan;                
                int PQAdmin;
                if (ckbQuanLyNV.Checked == true)
                {

                    PQQLNV = 1;
                }
                else
                {
                    PQQLNV = 0;
                }
                //------------------
                if (ckbTinhTienLuong.Checked == true)
                {

                    PQTinhTienLuong = 1;
                }
                else
                {
                    PQTinhTienLuong = 0;
                }
                //-------------------------
                if (ckbThanhToan.Checked == true)
                {

                    PQThanhToan = 1;
                }
                else
                {
                    PQThanhToan = 0;
                }
                //--------------------
                if (ckbAdmin.Checked == true)
                {

                    PQAdmin = 1;
                }
                else
                {
                    PQAdmin = 0;
                }
                try
                {
                    conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                    conn.Open();
                    string sqlcomnd = "Insert into bPhanQuyen values('" + PQMaPQ + "','" + PQTenPhanQuyen + "'," + PQQLNV + "," + PQTinhTienLuong + "," + PQThanhToan + "," + PQAdmin + ")";
                    commnd = new SqlCommand(sqlcomnd, conn);
                    commnd.ExecuteNonQuery();                   
                    conn.Close();
                }
                catch
                {

                }

                //-----------------------luu cai bang Quan tri sau--------
                try
                {
                    conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                    conn.Open();
                    string sqlcmdLuuQT = "Insert into bQuanTri values('" + PQMaQT + "','" + PQMaPQ + "','" + PQTenTruyCap + "','" + PQMatKhau + "','" + PQHoTen + "','" + PQPhongBan + "','" + PQDiaChi + "','" + PQSDT + "','" + PQEmail + "')";
                    cmdLuuQT = new SqlCommand(sqlcmdLuuQT, conn);
                    cmdLuuQT.ExecuteNonQuery();                 
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);
                }
                MessageBox.Show("Ðã Thêm 1 Bản Ghi Vào CSDL", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                HienThiDuLieuPhanQuyen();
            }
        }

        private void btnSuaQ_Click(object sender, EventArgs e)
        {
            if (CheckDataPhanQuyen() == true)
            {
                string PQMaQT = txtMaQT.Text;
                string PQHoTen = txtHoTenQT.Text;
                string PQTenTruyCap = txttentruynhapQT.Text;
                string PQMatKhau = txtMatKhauQT.Text;
                string PQXacNhan = tXacNhanQT.Text;
                string PQPhongBan = cbPB.Text;
                string PQTenPhanQuyen = txtTenPhanQuyen.Text;
                string PQMaPQ = txtMaPQ.Text;
                string PQDiaChi = txtDiaChiQT.Text;
                int PQSDT = Convert.ToInt32(txtDienThoaiQT.Text);
                string PQEmail = txtEmailQT.Text;
                int PQQLNV;
                if (ckbQuanLyNV.Checked == true)
                {
                    PQQLNV = 1;
                }
                else
                {
                    PQQLNV = 0;
                }

                int PQTinhTienLuong;
                if (ckbTinhTienLuong.Checked == true)
                {
                    PQTinhTienLuong = 1;
                }
                else
                {
                    PQTinhTienLuong = 0;
                }
                int PQThanhToan;
                if (ckbThanhToan.Checked == true)
                {
                    PQThanhToan = 1;
                }
                else
                {
                    PQThanhToan = 0;
                }
                int PQAdmin;
                if (ckbAdmin.Checked == true)
                {
                    PQAdmin = 1;
                }
                else
                {
                    PQAdmin = 0;
                }


                //Luu Lại Dữ Liệu Đã Cập Nhật
                try
                {
                    conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                    conn.Open();

                    string sqlcomndUpdateQT = "Update bQuanTri Set TenTK='" + PQTenTruyCap + "',Pass='" + PQMatKhau + "',HoTen='" + PQHoTen + "',PhongBan='" + PQPhongBan + "',DiaChi='" + PQDiaChi + "',SoDienThoai='" + PQSDT + "',Email='" + PQEmail + "' where MaQT='" + PQMaQT + "'";
                    comndUpdateQT = new SqlCommand(sqlcomndUpdateQT, conn);

                    comndUpdateQT.ExecuteNonQuery();
                    MessageBox.Show("Ðã sua  ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);
                }

                try
                {
                    conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                    conn.Open();

                    string sqlcomndUpdatePQ = "Update bPhanQuyen Set TenPQ='" + PQTenPhanQuyen + "',QLNV='" + PQQLNV + "',TinhLuong='" + PQTinhTienLuong + "',ThanhToan='" + PQThanhToan + "',PhanQuyen='" + PQAdmin + "' where MaPQ='" + PQMaPQ + "'";

                    comndUpdatePQ = new SqlCommand(sqlcomndUpdatePQ, conn);
                    comndUpdatePQ.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                    MessageBox.Show(excep.StackTrace);

                }
                HienThiDuLieuPhanQuyen();
            }
        }

        private void btnXoaQ_Click(object sender, EventArgs e)
        {
            if (dgvPhanQuyen.CurrentRow != null)
            {
                if(MessageBox.Show("Bạn đã chắc sẽ xóa bản ghi này chứ!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)==DialogResult.Yes)
                {
                string MaQT = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[0].Value.ToString();
                string MaPQ = dgvPhanQuyen.Rows[dgvPhanQuyen.CurrentRow.Index].Cells[2].Value.ToString();

                conn = new SqlConnection("Server=TIEN-A62E5B5725;Initial Catalog=QuanLyTienLuong;Integrated Security=True");
                conn.Open();
                commnd = new SqlCommand("Delete bQuanTri where MaQT='" + MaQT + "'", conn);
                commndDelPQ = new SqlCommand("Delete bQuanTri where MaPQ='" + MaPQ + "'", conn);
                commnd.ExecuteNonQuery();
                commndDelPQ.ExecuteNonQuery();
                conn.Close();
                HienThiDuLieuPhanQuyen();
                }                
            }
        }

        private void ckbQuanLyNV_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbQuanLyNV.Checked == true)
            {
                ckbThanhToan.Checked = false;
                ckbTinhTienLuong.Checked = false;
                ckbAdmin.Checked = false;
            }
        }

        private void ckbTinhTienLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTinhTienLuong.Checked == true)
            {
                ckbQuanLyNV.Checked = false;
                ckbThanhToan.Checked = false;
                ckbAdmin.Checked = false;
            }
        }

        private void ckbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAdmin.Checked == true)
            {
                ckbQuanLyNV.Checked = false;
                ckbTinhTienLuong.Checked = false;
                ckbThanhToan.Checked = false;
            }
        }
        private void ckbThanhToan_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbThanhToan.Checked == true)
            {
                ckbQuanLyNV.Checked = false;
                ckbTinhTienLuong.Checked = false;
                ckbAdmin.Checked = false;
            }
        }



    }
}