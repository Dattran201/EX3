using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EX3.Models
{
    public class HocVien
    {
        [Required(ErrorMessage = "Mã học viên là bắt buộc.")]
        public string MaHocVien { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc.")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc.")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Học phí là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Học phí phải là số dương.")]
        public decimal HocPhi { get; set; }

        public string HinhAnh { get; set; }
        public string GhiChu { get; set; }
    }
}

    public class HitCounter
{
    public int Count { get; set; }
}
