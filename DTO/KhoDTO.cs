using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhoDTO
    {
        public string MaHang {get; set;}
        public string TenHang { get; set; }
        public string MaDVT { get; set; }
        public int SoLuong { get; set; }
        public double GiaBan { get; set; }
        public string MaNCC { get; set; }
        public DateTime NgayNhap { get; set; }
        public string TinhTrang { get; set; }

    }
}