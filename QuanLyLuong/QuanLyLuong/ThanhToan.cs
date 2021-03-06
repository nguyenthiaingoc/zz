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
    public partial class ThanhToan : Form
    {
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private string MaNV;

        public ThanhToan()
        {
            InitializeComponent();
        }

        private void HienThiDataGrid()
        {
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd =new SqlCommand("Select a.MaNhanVien,HoDem,Ten,PhongBan,ChucVu,SoTienLuong,ThanhToan from bLuong a left join bThongTinNhanVien b on a.MaNhanVien=b.MaNhanVien",conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Luong");
                dtGrid_TTL.DataSource = ds.Tables["Luong"].DefaultView;
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            HienThiDataGrid();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TKMaNV = txtTimMa.Text;
            string TKTenNV = txtTimTen.Text;
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("Select a.MaNhanVien,HoDem,Ten,PhongBan,ChucVu,SoTienLuong,ThanhToan from bLuong a left join bThongTinNhanVien b on a.MaNhanVien=b.MaNhanVien where b.MaNhanVien ='" + TKMaNV + "' or b.Ten like'" + TKTenNV + "'", conn);
                da = new SqlDataAdapter(commnd);
                DataSet ds = new DataSet();
                da.Fill(ds, "TimLuong");
                dtGrid_TTL.DataSource = ds.Tables["TimLuong"].DefaultView;
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int ThanhToan ;
            if (chbThanhToan.Checked == true)
            {
                ThanhToan = 1;
            }
            else
            {
                ThanhToan = 0;
            }
            try
            {
                conn = new SqlConnection("Server =(local);Initial Catalog=QuanLyTienLuong;User Id=sa;pwd=");
                conn.Open();
                SqlCommand commnd;
                commnd = new SqlCommand("Update bLuong set ThanhToan="+ThanhToan+"where MaNhanVien='"+MaNV+"'",conn);
                commnd.ExecuteNonQuery();                
                conn.Close();

            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
                MessageBox.Show(excep.StackTrace);
            }
            HienThiDataGrid();
            MessageBox.Show("Đã Cập Nhật Cơ Sở Dữ Liệu Thành Công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (dtGrid_TTL.CurrentRow != null)
            {
                string check = dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[6].Value.ToString();
                chbThanhToan.Checked = Convert.ToBoolean(check);
                MaNV = dtGrid_TTL.Rows[dtGrid_TTL.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }

    }
}