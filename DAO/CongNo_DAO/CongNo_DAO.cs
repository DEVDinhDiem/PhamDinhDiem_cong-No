using DTO.CongNo_DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.CongNo_DAO
{
    public class CongNo_DAO : DBConnection
    {
        public List<CongNo_DTO> ReadCustomer()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select*from congno", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            List<CongNo_DTO> lstCus = new List<CongNo_DTO>();
            while (reader.Read())
            {
                CongNo_DTO cus = new CongNo_DTO();
                cus.id = int.Parse(reader["makhachhang"].ToString());
                cus.name = reader["tenkhachhang"].ToString();
                cus.phone = reader["sodienthoai"].ToString();
                cus.tienno = reader["sotienno"].ToString();
                lstCus.Add(cus);
            }
            conn.Close();
            return lstCus;
        }
        public void DeleteCustomer(CongNo_DTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from congno where makhachhang=@makhachhang", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.id));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void NewCustomer(CongNo_DTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into congno values(@makhachhang,@tenkhachhang,@sodienthoai,@sotienno)", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.id));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.phone));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cus.tienno));
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void EditCustomer(CongNo_DTO cus)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("update congno set tenkhachhang=@tenkhachhang where makhachhang=@makhachhang", conn);
            cmd.Parameters.Add(new SqlParameter("@makhachhang", cus.id));
            cmd.Parameters.Add(new SqlParameter("@tenkhachhang", cus.name));
            cmd.Parameters.Add(new SqlParameter("@sodienthoai", cus.phone));
            cmd.Parameters.Add(new SqlParameter("@sotienno", cus.tienno));
            cmd.ExecuteNonQuery();
            conn.Close();



        }

    }
}
