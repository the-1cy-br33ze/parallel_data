using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_1
{
    internal interface ICalculator
    {
        double Calculate(Func<double, double> function, double lowerLimit, double upperLimit, int partitions, int methodType);
        double SimpsonMethod(Func<double, double> f, double a, double b, int n);
        double MidpointRectangleMethod(Func<double, double> f, double a, double b, int n);
        double SimpsonMethod_Parallel(Func<double, double> f, double a, double b, int n);
        double MidpointRectangleMethod_Parallel(Func<double, double> f, double a, double b, int n);
    }
}
