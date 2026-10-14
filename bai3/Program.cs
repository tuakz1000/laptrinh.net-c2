using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai3
{
    internal class Program
    {
        class TaiKhoanNganHang
        {
            public string SoTaiKhoan { get; set; }
            public string ChuTaiKhoan { get; set; }

            private double _soDu;

            public double SoDu
            {
                get { return _soDu; }
            }

            public TaiKhoanNganHang(string soTaiKhoan, string chuTaiKhoan, double soDu)
            {
                if (string.IsNullOrWhiteSpace(soTaiKhoan))
                    throw new ArgumentException("Số tài khoản không được rỗng.");

                if (string.IsNullOrWhiteSpace(chuTaiKhoan))
                    throw new ArgumentException("Chủ tài khoản không được rỗng.");

                if (soDu < 0)
                    throw new ArgumentException("Số dư không được âm.");

                SoTaiKhoan = soTaiKhoan;
                ChuTaiKhoan = chuTaiKhoan;
                _soDu = soDu;
            }

            public void NapTien(double soTien)
            {
                if (soTien <= 0)
                    throw new ArgumentException("Số tiền nạp phải lớn hơn 0.");

                _soDu += soTien;
            }

            public void RutTien(double soTien)
            {
                if (soTien <= 0)
                    throw new ArgumentException("Số tiền rút phải lớn hơn 0.");

                if (soTien > _soDu)
                    throw new InvalidOperationException("Không đủ số dư.");

                _soDu -= soTien;
            }

            public void ChuyenTien(TaiKhoanNganHang dich, double soTien)
            {
                if (dich == null)
                    throw new ArgumentException("Tài khoản nhận không hợp lệ.");

                if (dich == this)
                    throw new ArgumentException("Không thể chuyển tiền cho chính mình.");

                if (soTien <= 0)
                    throw new ArgumentException("Số tiền chuyển phải lớn hơn 0.");

                if (soTien > _soDu)
                    throw new InvalidOperationException("Không đủ số dư.");

                _soDu -= soTien;
                dich._soDu += soTien;
            }

            public void HienThi()
            {
                Console.WriteLine(
                    $"{SoTaiKhoan} - {ChuTaiKhoan} - Số dư: {SoDu:N0} VNĐ");
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                TaiKhoanNganHang a =
                    new TaiKhoanNganHang("001", "Nguyen Van A", 1000000);

                TaiKhoanNganHang b =
                    new TaiKhoanNganHang("002", "Nguyen Van B", 500000);

                a.NapTien(200000);
                a.RutTien(100000);
                a.ChuyenTien(b, 300000);

                a.HienThi();
                b.HienThi();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
