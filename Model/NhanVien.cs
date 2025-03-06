using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tra_Sua.Model
{
    class NhanVien
    {
        private string maNV;
        private string hoTen;
        private string chucVu;
        private float luong; 

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public float Luong { get => luong; set => luong = value; }

        public NhanVien()
        {
        }

        public NhanVien(string maNV, string hoTen, string chucVu, float luong)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.chucVu = chucVu;
            this.luong = luong;
        }
    }
}
