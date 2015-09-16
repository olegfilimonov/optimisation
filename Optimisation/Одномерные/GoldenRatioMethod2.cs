﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    //Метод золотого сечения 2 - МЗС2
    class GoldenRatioMethod2 : OneDimentionalOptimisationMethod
    {
        public double A
        {
            get { return a; }
        }

        public double B
        {
            get { return b; }
        }

        private readonly double goldenRight = (-1 + Math.Sqrt(5)) / 2;

        protected override void execute()
        {
            //Начальный этап
            var length = Math.Abs(b - a);
            var x1 = a + goldenRight * length;
            var k = 0;
            double x2;

            //Основной этап
            do
            {
                x2 = a + b - x1;

                if ((f(x2) < f(x1)) && (x2 < x1))
                {
                    b = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 < x1))
                {
                    a = x2;
                }
                else if ((f(x2) < f(x1)) && (x2 >= x1))
                {
                     a = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 >= x1))
                {
                    b = x2;
                }
                k++;
                length = Math.Abs(b - a);
                Console.WriteLine(methodName + ": Итерация № " + k + " \tТИЛ: [" + a + ";" + b + "]");
            } while (length > eps && k < maxIterations);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }

        public GoldenRatioMethod2(function f, double eps = 1e-6, int maxIterations=50, bool useStandartInterval = false)
            : base(f,null, eps, "МЗС2", useStandartInterval,maxIterations)
        { }
    }
}

