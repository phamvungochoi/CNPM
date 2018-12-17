using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class KhachHangDAL
    {
        private readonly QLBHEntities1 dbContext;
        public KhachHangDAL()
        {
            dbContext = new QLBHEntities1();
        }
        public List<KhachHang> LayDanhSach()
        {
            return dbContext.KhachHangs.ToList();
        }
        public bool ThemKH(KhachHang khachhangMoi)
        {

            try
            {
                dbContext.KhachHangs.Add(khachhangMoi);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaKH(KhachHang khachhangSua)
        {
            try
            {
                var item = dbContext.KhachHangs.Single(n => n.MaTV == khachhangSua.MaTV);
                item.HoTen = khachhangSua.HoTen;
                item.DiaChi = khachhangSua.DiaChi;
                item.GioiTinh = khachhangSua.GioiTinh;
                item.Email = khachhangSua.Email;
                item.DienThoai = khachhangSua.DienThoai;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaKH(string khachhangXoa)
        {
            try
            {
                var item = dbContext.KhachHangs.SingleOrDefault(n => n.MaTV == khachhangXoa);
                dbContext.KhachHangs.Remove(item);
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
