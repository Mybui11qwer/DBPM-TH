using System;
using System.Collections.Generic;

namespace _22dh112218_BuiKhanhMy
{
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgayThamGia { get; set; }
        public string HocVi { get; set; }
        public string ChucVu { get; set; }
        public double LuongCBThang { get; set; } = 2000000; // LCB theo quy định
        public double TienLeTet { get; set; }
        public double TienPhat { get; set; }
        public List<NguoiThan> DanhSachNguoiThan { get; set; } = new List<NguoiThan>();

        private static readonly Dictionary<string, double> HeSoHocVi = new Dictionary<string, double>
        {
            {"PTTH", 2}, {"TC", 3}, {"CĐ", 4}, {"ĐH", 5},
            {"TH.S", 6}, {"TS", 7}
        };


        private static readonly Dictionary<string, double> HeSoChucVu = new Dictionary<string, double>
        {
            {"GĐ", 5}, {"PGD", 4}, {"TP", 3}, {"PP", 2.5},
            {"TT", 2}, {"TP", 1.5}, {"NV", 1}
        };

        public double TinhHeSoThamNien()
        {
            var soNam = (DateTime.Now - NgayThamGia).Days / 365;
            return Math.Min(soNam * 0.1, 1);
        }

        public double TinhLuong()
        {
            var heSoHocVi = HeSoHocVi.ContainsKey(HocVi) ? HeSoHocVi[HocVi] : 1;
            var heSoChucVu = HeSoChucVu.ContainsKey(ChucVu) ? HeSoChucVu[ChucVu] : 1;
            var heSoThamNien = TinhHeSoThamNien();
            return LuongCBThang * (heSoHocVi + heSoChucVu + heSoThamNien);
        }

        public double TinhBHYT() => TinhLuong() * 0.015; // Giả sử 1.5% BHYT
        public double TinhBHXH() => TinhLuong() * 0.08;  // Giả sử 8% BHXH
        public double TinhBHTN() => TinhLuong() * 0.01;  // Giả sử 1% BHTN
        public double TinhThueTNCN() => TinhLuong() > 11000000 ? (TinhLuong() - 11000000) * 0.1 : 0; // Giả sử mức thu nhập cá nhân chịu thuế

        public double TinhTongThuNhap()
        {
            var luong = TinhLuong();
            return luong + TienLeTet - TinhBHYT() - TinhBHXH() - TinhBHTN() - TinhThueTNCN() - TienPhat;
        }
    }
}
