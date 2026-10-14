using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai2
{
    internal class Program
    {
        class SanPham
        {
            private double _donGia;
            private int _soLuong;

            public string MaSP { get; set; }

            public string TenSP { get; set; }

            public double DonGia
            {
                get { return _donGia; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Đơn giá không được âm.");
                    _donGia = value;
                }
            }

            public int SoLuong
            {
                get { return _soLuong; }
                set
                {
                    if (value < 0)
                        throw new ArgumentException("Số lượng không được âm.");
                    _soLuong = value;
                }
            }

            public SanPham(string maSP, string tenSP, double donGia, int soLuong)
            {
                if (string.IsNullOrWhiteSpace(maSP))
                    throw new ArgumentException("Mã sản phẩm không được rỗng.");

                if (string.IsNullOrWhiteSpace(tenSP))
                    throw new ArgumentException("Tên sản phẩm không được rỗng.");

                MaSP = maSP;
                TenSP = tenSP;
                DonGia = donGia;
                SoLuong = soLuong;
            }

            public double TinhThanhTien()
            {
                return DonGia * SoLuong;
            }

            public void HienThi()
            {
                Console.WriteLine(
                    $"{MaSP} - {TenSP} - Đơn giá: {DonGia:N0} - " +
                    $"Số lượng: {SoLuong} - Thành tiền: {TinhThanhTien():N0}");
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                SanPham sp = new SanPham("SP01", "Bàn phím", 250000, 3);
                sp.HienThi();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
