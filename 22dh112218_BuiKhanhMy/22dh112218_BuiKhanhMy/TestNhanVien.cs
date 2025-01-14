using _22dh112218_BuiKhanhMy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace NhanVienTests
{
    [TestClass]
    public class NhanVienTests
    {
        [TestMethod]
        public void TinhLuong_ShouldCalculateCorrectly()
        {
            // Arrange: Thiết lập đối tượng NhanVien
            var nhanVien = new NhanVien
            {
                MaNV = "NV001",
                HoTen = "Nguyen Van A",
                NgayThamGia = new DateTime(2020, 1, 1),
                HocVi = "ĐH",
                ChucVu = "NV"
            };

            // Act: Gọi phương thức tính lương
            var luong = nhanVien.TinhLuong();

            // Assert: Kiểm tra kết quả
            double expectedLuong = 2000000 * (5 + 1 + 0.2); // He so DH, NV, tham nien 2 nam
            Assert.AreEqual(expectedLuong, luong, 0.01); // Kiểm tra chênh lệch nhỏ (0.01)
        }

        [TestMethod]
        public void TinhTongThuNhap_ShouldCalculateCorrectly()
        {
            // Arrange: Thiết lập đối tượng NhanVien
            var nhanVien = new NhanVien
            {
                MaNV = "NV001",
                HoTen = "Nguyen Van A",
                NgayThamGia = new DateTime(2020, 1, 1),
                HocVi = "ĐH",
                ChucVu = "NV",
                TienLeTet = 1000000,
                TienPhat = 500000
            };

            // Act: Gọi phương thức tính tổng thu nhập
            var tongThuNhap = nhanVien.TinhTongThuNhap();

            // Assert: Kiểm tra kết quả
            double expectedTongThuNhap = nhanVien.TinhLuong() + 1000000 - nhanVien.TinhBHYT() - nhanVien.TinhBHXH() - nhanVien.TinhBHTN() - nhanVien.TinhThueTNCN() - 500000;
            Assert.AreEqual(expectedTongThuNhap, tongThuNhap, 0.01);
        }
    }
}
