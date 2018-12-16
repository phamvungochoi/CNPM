using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NhanVienDAL
    {
        private readonly QLBHEntities dbContext;
        public NhanVienDAL()
        {
            dbContext = new QLBHEntities();
        }
        public List<NhanVien> LayDanhSach()
        {
            return dbContext.NhanViens.ToList();
        }
        public bool ThemNV(NhanVien nhanvienMoi)
        {

            try
            {
                dbContext.NhanViens.Add(nhanvienMoi);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SuaNV(NhanVien nhanvienSua)
        {
            try
            {
                var item = dbContext.NhanViens.Single(n => n.MaNV == nhanvienSua.MaNV);
                item.HoTen = nhanvienSua.HoTen;
                item.NgaySinh = nhanvienSua.NgaySinh;
                item.GioiTinh = nhanvienSua.GioiTinh;
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool XoaNV(string nhanvienXoa)
        {
            try
            {
                var item = dbContext.NhanViens.SingleOrDefault(n => n.MaNV == nhanvienXoa);
                dbContext.NhanViens.Remove(item);
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
