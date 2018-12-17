using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DTO;
namespace BLL
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL hdContext;

        public HoaDonBUS()
        {
            hdContext = new HoaDonDAL();
        }

        public List<HoaDonDTO> LayDanhSach()
        {
            return hdContext.LayDanhSach()
                .Select(n => new HoaDonDTO()
                {
                    MaNV = n.MaNV,
                    MaHD = n.MaHD,
                    ThoiGian = n.ThoiGian,
                    TrangThai = n.TrangThai ? "Chưa In" : "In",
                    ThanhTien =n.ThanhTien,
                    MaTV = n.MaTV,
                    GhiChu = n.GhiChu,
                }).ToList();
        }
        public bool XoaHD(string hoadonXoa)
        {
            return hdContext.XoaHD(hoadonXoa);
        }
    }
}
