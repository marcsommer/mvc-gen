using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace ProductTest.Mapping
{
    [TableName(Name = "NguoiDung")]
    public class NguoiDung
    {
        [Identity]
        [PrimaryKey(1)]
        public int MaNguoiDung { get; set; }

        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCMND { get; set; }

        [Nullable]
        public int? NhomNguoiDung { get; set; }

        [Nullable]
        public string TrangThai { get; set; }
    }
}