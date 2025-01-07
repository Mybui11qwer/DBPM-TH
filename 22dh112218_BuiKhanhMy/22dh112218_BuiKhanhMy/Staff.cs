using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22dh112218_BuiKhanhMy
{
    public class Staff
    {
        private int MsNV;
        private string TenNV;
        private DateTime NgaySinh;
        private int SoGioLam;
        private double LuongCB; //Lương cơ bản cho 1 ngày làm
        private double LuongThuong;
        private string BangCap;
        private string SoNgayNghi;

        public Staff() { }
        public Staff(int msNV, string tenNV, DateTime ngaysinh, int soGioLam, string bangcap)
        {
            this.MsNV = msNV;
            this.TenNV = tenNV;
            this.SoGioLam = soGioLam;
            this.NgaySinh = ngaysinh;
            this.BangCap = bangcap;
        }

        public double TinhNgayCong()
        {
            //Mỗi ngày làm 8 tiếng.
            return SoGioLam / 8;
        }
        public double TinhLuong()
        {
            return TinhNgayCong() * LuongCB + LuongThuong;
        }
    }
}
