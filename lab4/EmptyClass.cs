//https://www.codeproject.com/Articles/42839/Sorting-Lists-using-IComparable-and-IComparer-Inte
using System;
using System.Collections.Generic;
namespace exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("Mini", 2014, 123);
            Car car2 = new Car("Mercedes", 2021, 123);
            Car[] cars1 = new Car[] { car1, car2 };
            Array.Sort(cars1, new CarComparer(CarCompareType.MaxSpeed));
            CarsCatalog carsCat = new CarsCatalog(cars1);
            foreach (var elem in carsCat)
            {
                Console.WriteLine(elem.ToString());
            }
            Console.WriteLine();
            foreach (var elem in carsCat.Reverse())
            {
                Console.WriteLine(elem.ToString());
            }

            foreach (var elem in carsCat.SubsetYearofProduction(2015))
            {
                Console.WriteLine(elem.ToString());
            }

            foreach (var elem in carsCat.SubsetMaxSpeed(2015))
            {
                Console.WriteLine(elem.ToString());
            }
        }
    }
    public class Car
    {
        public string Name { get; set; }
        public int ProductionYear { get; set; }
        public int MaxSpeed { get; set; }
        public Car(string name, int productionYear, int maxSpeed)
        {
            Name = name;
            ProductionYear = productionYear;
            MaxSpeed = maxSpeed;
        }
        public override string ToString()
        {
            return this.Name;
        }
    }

    public enum CarCompareType
    {
        Name,
        ProductionYear,
        MaxSpeed
    }
    public class CarComparer : IComparer<Car>
    {
        private CarCompareType _compareType;

        public CarComparer(CarCompareType compareType) => _compareType = compareType;
        public int Compare(Car? x, Car? y)
        {
            int status = 2;
            switch (_compareType)
            {
                case CarCompareType.Name:
                    {
                        status = x.Name.CompareTo(y.Name);
                        return status;
                        break;
                    }
                case CarCompareType.ProductionYear:
                    {
                        status = (x.ProductionYear > y.ProductionYear) ? -1 : ((x.ProductionYear == y.ProductionYear) ? 0 : 1);
                        return status;
                        break;
                    }
                case CarCompareType.MaxSpeed:
                    {
                        status = (x.MaxSpeed > y.MaxSpeed) ? -1 : ((x.MaxSpeed == y.MaxSpeed) ? 0 : 1);
                        return status;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("unexpected compare type");
                    }
            }
        }
    }

    public class CarsCatalog
    {
        public int length;
        public Car[] cars;
        //Инициализируем массив cars, чтобы с ним можно было бы работать

        public CarsCatalog(params Car[] cars)
        {
            //Получение значения размера массива, приравниваем элементы к массиву класса 
            length = cars.Length;
            this.cars = new Car[length];
            for (int i = 0; i < length; i++)
            {
                this.cars[i] = cars[i];
            }

        }
        public IEnumerator<Car> GetEnumerator()
        {
            for (int i = 0; i < length; i++)
            {
                yield return cars[i];
            }
        }

        public IEnumerable<Car> Reverse()
        {
            for (int i = length - 1; i >= 0; i--)
            {
                yield return cars[i];
            }
        }

        public IEnumerable<Car> SubsetYearofProduction(int year)
        {
            for (int i = 0; i < length; i++)
            {
                if (cars[i].ProductionYear > year)
                {
                    yield return cars[i];
                }
                
            }
        }

        public IEnumerable<Car> SubsetMaxSpeed(int speed)
        {
            for (int i = 0; i < length; i++)
            {
                if (cars[i].ProductionYear > speed)
                {
                    yield return cars[i];
                }

            }
        }
    }
}

