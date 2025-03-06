using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tra_Sua.Model
{
    class KhachHang
    {
        private string maKhachHang;
        private string tenKhachHang;
        private int sDT;
        private string email;
        private int soLanMua;
        private string loaiKhachHang;

        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        public string TenKhachHang { get => tenKhachHang; set => tenKhachHang = value; }
        public int SDT { get => sDT; set => sDT = value; }
        public string Email { get => email; set => email = value; }
        public int SoLanMua { get => soLanMua; set => soLanMua = value; }
        public string LoaiKhachHang { get => loaiKhachHang; set => loaiKhachHang = value; }

        public KhachHang()
        {
        }

        public KhachHang(string maKhachHang, string tenKhachHang, int sDT, string email, int soLanMua, string loaiKhachHang)
        {
           this.MaKhachHang = maKhachHang;
           this.TenKhachHang = tenKhachHang;
           this.SDT = sDT;
           this.Email = email;
           this.SoLanMua = soLanMua;
           this.LoaiKhachHang = loaiKhachHang;
        }
    }
}
