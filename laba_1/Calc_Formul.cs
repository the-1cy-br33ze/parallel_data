using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_1
{
    internal class Calc_Formul(): ICalculator
    {
        public double Calculate(Func<double, double> function, double Down_gran, double Up_gran, int all_de, int variant)
        {

            switch (variant){
                case 0: return SimpsonMethod(function, Down_gran, Up_gran, all_de); break;
                case 1: return MidpointRectangleMethod(function, Down_gran, Up_gran, all_de);break;
                case 2: return SimpsonMethod_Parallel(function, Down_gran, Up_gran, all_de); break;
                case 3: return MidpointRectangleMethod_Parallel(function, Down_gran, Up_gran, all_de); break;
                default: return 0;
            }
            
        }

        public double SimpsonMethod(Func<double, double> f, double a, double b, int n)
        {

            double h = (b - a) / n;
            double sum = f(a) + f(b);

            for (int i = 1; i < n; i += 2)
            {
                double x = a + i * h;
                sum += 4 * f(x);
            }

            for (int i = 2; i < n; i += 2)
            {
                double x = a + i * h;
                sum += 2 * f(x);
            }

            return sum * h / 3.0;
        }

        public double MidpointRectangleMethod(Func<double, double> f, double a, double b, int n)
        {

            double h = (b - a) / n;
            double sum = 0.0;

            for (int i = 0; i < n; i++)
            {
                double x_mid = a + (i + 0.5) * h;
                sum += f(x_mid);
            }

            return sum * h;
        }

        public double SimpsonMethod_Parallel(Func<double, double> f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double sum = f(a) + f(b);
            object LOCK = new object();

            Parallel.For(1, n, i =>
            {
                if (i % 2 == 1)
                {
                    double x = a + i * h;
                    double value = 4 * f(x);
                    lock (LOCK) // этот блок кода будет выполнятся только одним потоком одновременно
                    {
                        sum += value;
                    }
                }
            });

            Parallel.For(2, n, i =>
            {
                if (i % 2 == 0) 
                {
                    double x = a + i * h;
                    double value = 2 * f(x);
                    lock (LOCK)
                    {
                        sum += value;
                    }
                }
            });

            return sum * h / 3.0;
        }

        public double MidpointRectangleMethod_Parallel(Func<double, double> f, double a, double b, int n)
        {

            double h = (b - a) / n;
            double sum = 0.0;
            object LOCK = new object();

            Parallel.For(0, n, i =>
            {
                double x_mid = a + (i + 0.5) * h;
                double value = f(x_mid);

                lock (LOCK)
                {
                    sum += value;
                }
            });

            return sum * h;
        }
    }
}

