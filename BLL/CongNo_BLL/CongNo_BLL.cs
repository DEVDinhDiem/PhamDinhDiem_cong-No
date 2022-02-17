using DAO.CongNo_DAO;
using DTO.CongNo_DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CongNo_BLL
{
   public class CongNoBLL
    {

        CongNo_DAO dal = new CongNo_DAO();

        public List<CongNo_DTO> ReadCustomer()
        {
            List<CongNo_DTO> lstCus = dal.ReadCustomer();
            return lstCus;
        }
        public void NewCustomer(CongNo_DTO cus)
        {
            dal.NewCustomer(cus);
        }
        public void DeleteCustomer(CongNo_DTO cus)
        {
            dal.DeleteCustomer(cus);
        }
        public void EditCustomer(CongNo_DTO cus)
        {
            dal.EditCustomer(cus);
        }
    }
}
