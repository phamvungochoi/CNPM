using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccessLayer;

namespace BLL
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL khContext;

        public KhachHangBUS()
        {
            khContext = new KhachHangDAL();
        }

        public List<KhachHangDTO> LayDanhSach()
        {
            return khContext.LayDanhSach()
                .Select(n => new KhachHangDTO()
                {
                    MaTV = n.MaTV,
                    HoTen = n.HoTen,
                    GioiTinh = n.GioiTinh ? "Nữ" : "Nam",
                    DiaChi = n.DiaChi,
                    Email =n.Email,
                    DienThoai = n.DienThoai,
                }).ToList();
        }
        public bool ThemKH(KhachHang khachhangMoi)
        {
            return khContext.ThemKH(khachhangMoi);
        }
        public bool SuaKH(KhachHang khachhangSua)
        {
            return khContext.SuaKH(khachhangSua);
        }
        public bool XoaKH(string khachhangXoa)
        {
            return khContext.XoaKH(khachhangXoa);
        }
    }
}
