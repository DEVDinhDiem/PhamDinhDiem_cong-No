using BLL.CongNo_BLL;
using DTO.CongNo_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoHinh3Lop_Library
{
    public partial class Form1 : Form
    {
        CongNoBLL cusBAL = new CongNoBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbName.Text == "")
            {
                txtthongbao.Text = "Mã Khách Hàng, Tên Khách Hàng Không Dược Để Trống";

                //MessageBox.Show("Vui Lòng Không Để Trống MaKH,TENKH", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CongNo_DTO cus = new CongNo_DTO();
                cus.id = int.Parse(tbId.Text);
                cus.name = tbName.Text;
                cus.phone = tbphone.Text;
                cus.tienno = tbTienno.Text;
                cusBAL.NewCustomer(cus);
                dgvCustomer.Rows.Add(cus.id, cus.name, cus.phone, cus.tienno);
                txtthongbao.Text = "Thêm Thành Công*";
                tbId.Text = ""; tbName.Text = ""; tbphone.Text = ""; tbTienno.Text = "";
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbName.Text == "")
            {
                txtthongbao.Text = "Vui Lòng Chọn Sinh Viên Để Xoá";              
            }
            else
            {
                CongNo_DTO cus = new CongNo_DTO();
                cus.id = int.Parse(tbId.Text);
                cus.name = tbName.Text;
                cus.phone = tbphone.Text;
                cus.tienno = tbTienno.Text;
                cusBAL.DeleteCustomer(cus);
                int idx = dgvCustomer.CurrentCell.RowIndex;
                dgvCustomer.Rows.RemoveAt(idx);
                txtthongbao.Text = "Xoá Thành Công*";
                tbId.Text = ""; tbName.Text = ""; tbphone.Text = ""; tbTienno.Text = "";
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (tbId.Text == "" || tbName.Text == "")
            {
                txtthongbao.Text = "Không Có Gì Để Sửa";
            }
            else
            {
                CongNo_DTO cus = new CongNo_DTO();
                cus.id = int.Parse(tbId.Text);
                cus.name = tbName.Text;
                cus.phone = tbphone.Text;
                cus.tienno = tbTienno.Text;
                cusBAL.EditCustomer(cus);

                DataGridViewRow row = dgvCustomer.CurrentRow;

                row.Cells[0].Value = cus.id;
                row.Cells[1].Value = cus.name;
                row.Cells[2].Value = cus.phone;
                row.Cells[3].Value = cus.tienno;
                txtthongbao.Text = "Sửa Thành Công*";
                tbId.Text = ""; tbName.Text = ""; tbphone.Text = ""; tbTienno.Text = "";
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có muốn Thoát", "Thoát Chương Trình", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            switch (result)
            {
                case DialogResult.No:
                    //
                    break;
                case DialogResult.Yes:
                    this.Close();
                    break;
                default:
                    break;
            }
        }
        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int idx = e.RowIndex;
            tbId.Text = dgvCustomer.Rows[idx].Cells[0].Value.ToString();
            tbName.Text = dgvCustomer.Rows[idx].Cells[1].Value.ToString();
            tbphone.Text = dgvCustomer.Rows[idx].Cells[2].Value.ToString();
            tbTienno.Text = dgvCustomer.Rows[idx].Cells[3].Value.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<CongNo_DTO> lstCus = cusBAL.ReadCustomer();

            foreach (CongNo_DTO cus in lstCus)
            {

                dgvCustomer.Rows.Add(cus.id, cus.name, cus.phone, cus.tienno);
            }
        }
    }
}
