using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai5
{
    internal class Program
    {
        class HinhChuNhat
        {
            private double _chieuDai;
            private double _chieuRong;

            public double ChieuDai
            {
                get { return _chieuDai; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Chiều dài phải lớn hơn 0.");
                    _chieuDai = value;
                }
            }

            public double ChieuRong
            {
                get { return _chieuRong; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Chiều rộng phải lớn hơn 0.");
                    _chieuRong = value;
                }
            }

            public HinhChuNhat(double chieuDai, double chieuRong)
            {
                ChieuDai = chieuDai;
                ChieuRong = chieuRong;
            }

            public double TinhChuVi()
            {
                return (ChieuDai + ChieuRong) * 2;
            }

            public double TinhDienTich()
            {
                return ChieuDai * ChieuRong;
            }

            public void HienThi()
            {
                Console.WriteLine($"Chiều dài: {ChieuDai}");
                Console.WriteLine($"Chiều rộng: {ChieuRong}");
                Console.WriteLine($"Chu vi: {TinhChuVi():N2}");
                Console.WriteLine($"Diện tích: {TinhDienTich():N2}");
            }
        }
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                Console.Write("Nhập chiều dài: ");
                double dai = double.Parse(Console.ReadLine());

                Console.Write("Nhập chiều rộng: ");
                double rong = double.Parse(Console.ReadLine());

                HinhChuNhat hcn = new HinhChuNhat(dai, rong);
                hcn.HienThi();
            }
            catch (FormatException)
            {
                Console.WriteLine("Vui lòng nhập số hợp lệ.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
        }
    }
}
