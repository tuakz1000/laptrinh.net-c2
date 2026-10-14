using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai4
{
    internal class Program
    {
        class NhanVien
        {
            public string MaNV { get; set; }
            public string HoTen { get; set; }

            private double _luongCoBan;
            private double _heSo;
            private double _phuCap;

            public double LuongCoBan
            {
                get { return _luongCoBan; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Lương cơ bản không được âm.");
                    _luongCoBan = value;
                }
            }

            public double HeSo
            {
                get { return _heSo; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Hệ số không được âm.");
                    _heSo = value;
                }
            }

            public double PhuCap
            {
                get { return _phuCap; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Phụ cấp không được âm.");
                    _phuCap = value;
                }
            }

            public NhanVien(string maNV, string hoTen,
                            double luongCoBan, double heSo, double phuCap)
            {
                if (string.IsNullOrWhiteSpace(maNV))
                    throw new ArgumentException("Mã nhân viên không được rỗng.");

                if (string.IsNullOrWhiteSpace(hoTen))
                    throw new ArgumentException("Họ tên không được rỗng.");

                MaNV = maNV;
                HoTen = hoTen;
                LuongCoBan = luongCoBan;
                HeSo = heSo;
                PhuCap = phuCap;
            }

            public double TinhLuong()
            {
                return LuongCoBan * HeSo + PhuCap;
            }

            public void InBangLuong()
            {
                Console.WriteLine(
                    $"{MaNV,-10}{HoTen,-25}{LuongCoBan,15:N0}" +
                    $"{HeSo,10:N2}{PhuCap,15:N0}{TinhLuong(),18:N0}");
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            NhanVien[] ds =
        {
            new NhanVien("NV01", "Nguyen Van A", 5000000, 2.0, 500000),
            new NhanVien("NV02", "Tran Thi B", 6000000, 1.5, 300000),
            new NhanVien("NV03", "Le Van C", 4500000, 1.8, 200000)
        };

            Console.WriteLine(
                $"{"Mã NV",-10}{"Họ tên",-25}{"Lương CB",15}" +
                $"{"Hệ số",10}{"Phụ cấp",15}{"Thực lĩnh",18}");

            foreach (NhanVien nv in ds)
            {
                nv.InBangLuong();
            }
        }
    }
}
