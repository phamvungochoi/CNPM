using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KhoDAL
    {
        private readonly QLBHEntities1 dbContext;
        public KhoDAL()
        {
            dbContext = new QLBHEntities1();
        }
        public List<HangHoa> LayDanhSach()
        {
            return dbContext.HangHoas.ToList();
        }
        public bool ThemHH (HangHoa hanghoaMoi)
        {

            try
            {
                dbContext.HangHoas.Add(hanghoaMoi);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaHH(HangHoa hanghoaSua)
        {
            try
            {
                var item = dbContext.HangHoas.Single(n => n.MaHang == hanghoaSua.MaHang);
                item.TenHang = hanghoaSua.TenHang;
                item.MaDVT = hanghoaSua.MaDVT;
                item.SoLuong = hanghoaSua.SoLuong;
                item.GiaBan = hanghoaSua.GiaBan;
                item.NgayNhap = hanghoaSua.NgayNhap;
                item.TinhTrang = hanghoaSua.TinhTrang;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaHH(string hanghoaXoa)
        {
            try
            {
                var item = dbContext.HangHoas.SingleOrDefault(n => n.MaHang == hanghoaXoa);
                dbContext.HangHoas.Remove(item);
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
