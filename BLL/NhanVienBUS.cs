using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
namespace BLL
{
    public class NhanVienBUS
    {
        private readonly NhanVienDAL nvContext;

        public NhanVienBUS()
        {
            nvContext = new NhanVienDAL();
        }

        public List<NhanVienDTO> LayDanhSach()
        {
            return nvContext.LayDanhSach()
                .Select(n => new NhanVienDTO()
                {
                    MaNV = n.MaNV,
                    HoTen = n.HoTen,
                    NgaySinh = n.NgaySinh,
                    GioiTinh = n.GioiTinh ? "Nữ" : "Nam",
                    CMND = n.CMND,
                    DiaChi = n.DiaChi,
                    QueQuan = n.QueQuan,
                    SDT =n.SDT,
                }).ToList();
        }
        public bool ThemNV(NhanVien nhanvienMoi)
        {
            return nvContext.ThemNV(nhanvienMoi);
        }
        public bool SuaNV(NhanVien nhanvienSua)
        {
            return nvContext.SuaNV(nhanvienSua);
        }
        public bool XoaNV(string nhanvienXoa)
        {
            return nvContext.XoaNV(nhanvienXoa);
        }
    }
}

