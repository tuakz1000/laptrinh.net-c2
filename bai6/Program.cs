using System;
using System.Collections.Generic;
using System.Linq;

namespace bai6
{
    internal class Program
    {
        public class SinhVien
        {
            private string _hoTen;
            private double _diemTB;

            public string MaSV { get; set; }

            public string HoTen
            {
                get { return _hoTen; }
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("Họ tên không được rỗng.");

                    _hoTen = value.Trim();
                }
            }

            public DateTime NgaySinh { get; set; }

            public double DiemTB
            {
                get { return _diemTB; }
                set
                {
                    if (value < 0 || value > 10)
                        throw new ArgumentOutOfRangeException(
                            nameof(DiemTB), "Điểm phải từ 0 đến 10.");

                    _diemTB = value;
                }
            }

            public SinhVien()
            {
                MaSV = "Chưa có";
                HoTen = "Chưa có";
                NgaySinh = DateTime.Today;
                DiemTB = 0;
            }

            public SinhVien(string maSV, string hoTen,
                            DateTime ngaySinh, double diemTB)
            {
                if (string.IsNullOrWhiteSpace(maSV))
                    throw new ArgumentException(
                        "Mã sinh viên không được rỗng.");

                MaSV = maSV.Trim();
                HoTen = hoTen;
                NgaySinh = ngaySinh;
                DiemTB = diemTB;
            }

            public void HienThi()
            {
                Console.WriteLine(
                    "{0,-12}{1,-25}{2,-15:dd/MM/yyyy}{3,8:N2}",
                    MaSV, HoTen, NgaySinh, DiemTB);
            }

            public int TinhTuoi()
            {
                int tuoi = DateTime.Today.Year - NgaySinh.Year;

                if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi))
                    tuoi--;

                return tuoi;
            }

            public string XepLoai()
            {
                if (DiemTB >= 9) return "Xuất sắc";
                if (DiemTB >= 8) return "Giỏi";
                if (DiemTB >= 6.5) return "Khá";
                if (DiemTB >= 5) return "Trung bình";
                return "Yếu";
            }
        }

        static List<SinhVien> ds = new List<SinhVien>();

        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int chon = -1;

            do
            {
                Console.WriteLine("\n===== QUẢN LÝ SINH VIÊN =====");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Sửa sinh viên");
                Console.WriteLine("3. Xóa sinh viên");
                Console.WriteLine("4. Tìm kiếm sinh viên");
                Console.WriteLine("5. Sắp xếp theo điểm giảm dần");
                Console.WriteLine("6. Thống kê");
                Console.WriteLine("7. Hiển thị danh sách");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                if (!int.TryParse(Console.ReadLine(), out chon))
                {
                    Console.WriteLine("Vui lòng nhập số hợp lệ.");
                    chon = -1;
                    continue;
                }

                try
                {
                    switch (chon)
                    {
                        case 1:
                            Them();
                            break;
                        case 2:
                            Sua();
                            break;
                        case 3:
                            Xoa();
                            break;
                        case 4:
                            TimKiem();
                            break;
                        case 5:
                            SapXep();
                            break;
                        case 6:
                            ThongKe();
                            break;
                        case 7:
                            HienThiDanhSach();
                            break;
                        case 0:
                            Console.WriteLine("Đã thoát chương trình.");
                            break;
                        default:
                            Console.WriteLine("Chức năng không hợp lệ.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Lỗi dữ liệu: " + ex.Message);
                }
            }
            while (chon != 0);
        }

        static void Them()
        {
            Console.Write("Mã sinh viên: ");
            string ma = Console.ReadLine() ?? "";
            ma = ma.Trim();

            if (string.IsNullOrWhiteSpace(ma))
            {
                Console.WriteLine("Mã sinh viên không được rỗng.");
                return;
            }

            if (ds.Any(sv => sv.MaSV.Equals(
                ma, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Mã sinh viên đã tồn tại.");
                return;
            }

            Console.Write("Họ tên: ");
            string ten = Console.ReadLine() ?? "";

            Console.Write("Ngày sinh (dd/MM/yyyy): ");

            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime ngaySinh))
            {
                Console.WriteLine("Ngày sinh không hợp lệ.");
                return;
            }

            if (ngaySinh.Date > DateTime.Today)
            {
                Console.WriteLine("Ngày sinh không được ở tương lai.");
                return;
            }

            Console.Write("Điểm trung bình: ");

            if (!double.TryParse(Console.ReadLine(), out double diem))
            {
                Console.WriteLine("Điểm không hợp lệ.");
                return;
            }

            ds.Add(new SinhVien(ma, ten, ngaySinh, diem));
            Console.WriteLine("Thêm sinh viên thành công.");
        }

        static void Sua()
        {
            Console.Write("Nhập mã sinh viên cần sửa: ");
            string ma = (Console.ReadLine() ?? "").Trim();

            SinhVien sv = ds.FirstOrDefault(s =>
                s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            Console.Write("Họ tên mới: ");
            string ten = Console.ReadLine() ?? "";

            Console.Write("Ngày sinh mới (dd/MM/yyyy): ");

            if (!DateTime.TryParseExact(
                Console.ReadLine(),
                "dd/MM/yyyy",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out DateTime ngaySinh) || ngaySinh.Date > DateTime.Today)
            {
                Console.WriteLine("Ngày sinh không hợp lệ.");
                return;
            }

            Console.Write("Điểm trung bình mới: ");

            if (!double.TryParse(Console.ReadLine(), out double diem))
            {
                Console.WriteLine("Điểm không hợp lệ.");
                return;
            }

            // Tạo đối tượng tạm để kiểm tra dữ liệu trước khi sửa.
            SinhVien tam = new SinhVien(sv.MaSV, ten, ngaySinh, diem);

            sv.HoTen = tam.HoTen;
            sv.NgaySinh = tam.NgaySinh;
            sv.DiemTB = tam.DiemTB;

            Console.WriteLine("Cập nhật thành công.");
        }

        static void Xoa()
        {
            Console.Write("Nhập mã sinh viên cần xóa: ");
            string ma = (Console.ReadLine() ?? "").Trim();

            SinhVien sv = ds.FirstOrDefault(s =>
                s.MaSV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            ds.Remove(sv);
            Console.WriteLine("Xóa thành công.");
        }

        static void TimKiem()
        {
            Console.Write("Nhập mã hoặc họ tên cần tìm: ");
            string tuKhoa = (Console.ReadLine() ?? "").Trim();

            var ketQua = ds.Where(s =>
                s.MaSV.IndexOf(
                    tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.HoTen.IndexOf(
                    tuKhoa, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sinh viên.");
                return;
            }

            InDanhSach(ketQua);
        }

        static void SapXep()
        {
            ds = ds.OrderByDescending(s => s.DiemTB).ToList();

            Console.WriteLine("Đã sắp xếp theo điểm giảm dần.");
            HienThiDanhSach();
        }

        static void ThongKe()
        {
            Console.WriteLine("Tổng số sinh viên: " + ds.Count);

            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách chưa có sinh viên.");
                return;
            }

            Console.WriteLine(
                "Điểm trung bình chung: " +
                ds.Average(s => s.DiemTB).ToString("N2"));

            Console.WriteLine("Số sinh viên theo xếp loại:");

            var thongKe = ds.GroupBy(s => s.XepLoai());

            foreach (var nhom in thongKe)
            {
                Console.WriteLine(
                    "{0}: {1} sinh viên", nhom.Key, nhom.Count());
            }
        }

        static void HienThiDanhSach()
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách chưa có sinh viên.");
                return;
            }

            InDanhSach(ds);
        }

        static void InDanhSach(IEnumerable<SinhVien> danhSach)
        {
            Console.WriteLine(
                "\n{0,-12}{1,-25}{2,-15}{3,8}",
                "Mã SV", "Họ tên", "Ngày sinh", "Điểm TB");

            foreach (SinhVien sv in danhSach)
            {
                sv.HienThi();
            }
        }
    }
}
