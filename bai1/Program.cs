using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai1
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
                        throw new ArgumentOutOfRangeException("DiemTB");
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
            public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB)
            {
                MaSV = maSV;
                HoTen = hoTen;
                NgaySinh = ngaySinh;
                DiemTB = diemTB;
            }
            public void HienThi()
            {
                Console.WriteLine("{0} - {1} - {2:dd/MM/yyyy} - {3:N2}",
                MaSV, HoTen, NgaySinh, DiemTB);
            }
            public int TinhTuoi()
            {
                int tuoi = DateTime.Today.Year - NgaySinh.Year;
                if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--;
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
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            SinhVien sv_ = new SinhVien("SV001", "Nguyen Van A", new DateTime(2000, 1, 1), 8.5);
            sv_.HienThi();
            Console.WriteLine("------------------tao list sinhvien------------------");
            List<SinhVien> ds = new List<SinhVien>();
            ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2));
            ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));
            foreach (SinhVien sv in ds) sv.HienThi();
            Console.Write("Mã cần tìm: ");
            string ma = Console.ReadLine();
            SinhVien ketQua = ds.Find(x => x.MaSV.Equals(ma,StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(ketQua == null ? "Không tìm thấy" : ketQua.HoTen);
        }
    }
}
