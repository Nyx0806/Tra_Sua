using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tra_Sua.Model
{
    public class SanPham
    {
        private string maSanPham;
        private string tenSanPham;
        private float gia;
        private int soLuong =1 ;
        private string loai;
        private float thanhTien => gia * soLuong;

        public SanPham()
        {
        }

        public SanPham(string maSanPham, string tenSanPham, float gia, int soLuong, string loai)
        {
            this.maSanPham = maSanPham;
            this.tenSanPham = tenSanPham;
            this.gia = gia;
            this.soLuong = soLuong;
            this.loai = loai;
        }

        public string MaSanPham { get => maSanPham; set => maSanPham = value; }
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public float Gia { get => gia; set => gia = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public float ThanhTien => thanhTien;
        public string Loai { get => loai; set => loai = value; }
    }
}
