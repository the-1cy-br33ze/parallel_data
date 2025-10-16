using laba_1;
namespace Laba1_Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Rectangle_XX()
        {
            //Подготовка
            double a = 0, b = 1;
            int n = 1000;
            Func<double, double> Function = x => x * x;
            double expected = 0.333333;

            //Выполнение 
            Calc_Formul _calculator = new Calc_Formul();
            double actual = _calculator.Calculate(Function, a, b, n, 2);

            //Сравнение
            Assert.AreEqual(expected, actual, 0.00001);
        }

        [TestMethod]
        public void Rectangle_Variant_Switch()
        {

            //Подготовка
            double a = 0, b = 1;
            int n = 10;
            Func<double, double> Function = x => x * x;

            //Выполнение 
            Calc_Formul _calculator = new Calc_Formul();


            Assert.ThrowsException<ArgumentException>(() => _calculator.Calculate(Function, a, b, n, 5));

        }

        [TestMethod]
        public void Rectangle_NMinus()
        {

            //Подготовка
            double a = 0, b = 1;
            int n = -1000;
            Func<double, double> Function = x => x * x;

            //Выполнение 
            Calc_Formul _calculator = new Calc_Formul();
            Assert.ThrowsException<ArgumentException>(() => _calculator.Calculate(Function, a, b, n, 0));

        }

        [TestMethod]
        public void Rectangle_False_Max_Min()
        {

            //Подготовка
            double a = 10, b = 5;
            int n = 1000;
            Func<double, double> Function = x => x * x;

            //Выполнение 
            Calc_Formul _calculator = new Calc_Formul();


            Assert.ThrowsException<ArgumentException>(() => _calculator.Calculate(Function, a, b, n, 1));

        }

        [TestMethod] 
        public void TestParallelMethodLock()
        {
            //Подготовка
            double a = 100, b = 5000;
            int n = 1000000;
            Func<double, double> Function = x => x * x;

            //Выполнение 
            Calc_Formul _calculator = new Calc_Formul();
            double actual = _calculator.Calculate(Function, a, b, n, 2);
            double expected = _calculator.Calculate(Function, a, b, n, 0);

            //Сравнение
            Assert.AreEqual(expected, actual, 0.1);

        }




    }
}
