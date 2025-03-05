using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tra_Sua.Model
{
    class HoaDon
    {
        private string maHoaDon;
        private string maKhachHang;
        private string tenKhachHang;
        private int banSo;
        private DateTime ngayLapHoaDon;
        private float tongTien;

        public HoaDon()
        {
        }

        public HoaDon(string maHoaDon, string maKhachHang, string tenKhachHang, int banSo, DateTime ngayLapHoaDon, float tongTien)
        {
            this.maHoaDon = maHoaDon;
            this.maKhachHang = maKhachHang;
            this.tenKhachHang = tenKhachHang;
            this.banSo = banSo;
            this.ngayLapHoaDon = ngayLapHoaDon;
            this.tongTien = tongTien;
        }

        public string MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public int BanSo { get => banSo; set => banSo = value; }
        public DateTime NgayLapHoaDon { get => ngayLapHoaDon; set => ngayLapHoaDon = value; }
        public float TongTien { get => tongTien; set => tongTien = value; }
    }
}
