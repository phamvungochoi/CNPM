using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
        public class KhoBUS
        {
            private readonly KhoDAL kContext;

            public KhoBUS()
            {
                kContext = new KhoDAL();
            }

            public List<KhoDTO> LayDanhSach()
            {
                return kContext.LayDanhSach()
                    .Select(n => new KhoDTO()
                    {
                        MaHang = n.MaHang,
                        TenHang = n.TenHang,
                        MaDVT =n.MaDVT,
                        SoLuong = n.SoLuong,
                        GiaBan = n.GiaBan,
                        MaNCC = n.MaNCC,
                        NgayNhap = n.NgayNhap,
                        TinhTrang = n.TinhTrang,
                    }).ToList();
            }
            public bool ThemHH(HangHoa hanghoaMoi)
            {
                return kContext.ThemHH(hanghoaMoi);
            }
            public bool SuaHH(HangHoa hanghoaSua)
            {
                return kContext.SuaHH(hanghoaSua);
            }
            public bool XoaHH(string hanghoaXoa)
            {
                return kContext.XoaHH(hanghoaXoa);
            }
        }
}
