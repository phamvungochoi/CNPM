using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class HoaDonDAL
    {
        private readonly QLBHEntities1 dbContext;
        public HoaDonDAL()
        {
            dbContext = new QLBHEntities1();
        }
        public List<HoaDon> LayDanhSach()
        {
            return dbContext.HoaDons.ToList();
        }
        public bool XoaHD(string hoadonXoa)
        {
            try
            {
                var item = dbContext.HoaDons.SingleOrDefault(n => n.MaHD == hoadonXoa);
                dbContext.HoaDons.Remove(item);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
