namespace LabThree
{
    struct Vector
    {
        public double x;
        public double y;
        public double z;
        public Vector(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }

        static public Vector operator +(Vector a, Vector b)
        {
            Vector c;
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            c.z = a.z + b.z;
            return c;
        }
        static public double operator *(Vector a, Vector b) => a.x * b.x + a.y * b.y + a.z * b.z;
        static public Vector operator *(double a, Vector b)
        {
            Vector c;
            c.x = a * b.x;
            c.y = a * b.y;
            c.z = a * b.z;
            return c;
        }

        public double Length() => Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z);

        static public bool operator >(Vector a, Vector b) => a.Length() > b.Length();
        static public bool operator <(Vector a, Vector b) => a.Length() < b.Length();

        static public bool operator >=(Vector a, Vector b) => a.Length() >= b.Length();
        static public bool operator <=(Vector a, Vector b) => a.Length() <= b.Length();
    }


    class Car : IEquatable<Car>
    {
        public string Name { get; set; }
        public string Engine { get; set; }
        public double MaxSpeed { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        static public bool operator ==(Car car1, Car car2)
        {
            return car1.Equals(car2);
        }

        static public bool operator !=(Car car1, Car car2)
        {
            return !(car1.Equals(car2));
        }

        public bool Equals(Car other)
        {
            if (this.Name == other.Name &&
                this.Engine == other.Name && this.MaxSpeed == MaxSpeed)
                return true;
            else return false;
        }
    }
    class CarsCatalog
    {
        public List<Car> cars = new List<Car>();

        public string this[int index]
        {
            get
            {
                return $"|{cars[index].Name}| - |{cars[index].Engine}|";
            }
        }
    }

    class Currency
    {
        public double Value { get; set; }

        public Currency(double value)
        {
            Value = value;
        }
    }

    class CurrencyUSD : Currency
    {
        public CurrencyUSD(double value) : base(value) { }

        public static implicit operator CurrencyEUR(CurrencyUSD usd)
        {
            return new CurrencyEUR(usd.Value * 0.93);
        }

        public static implicit operator CurrencyRUB(CurrencyUSD usd)
        {
            return new CurrencyRUB(usd.Value * 94.7);
        }
    }

    class CurrencyEUR : Currency
    {
        public CurrencyEUR(double value) : base(value) { }

        public static implicit operator CurrencyUSD(CurrencyEUR eur)
        {
            return new CurrencyUSD(eur.Value * 1.07);
        }

        public static implicit operator CurrencyRUB(CurrencyEUR eur)
        {
            return new CurrencyRUB(eur.Value * 101.56);
        }
    }

    class CurrencyRUB : Currency
    {
        public CurrencyRUB(double value) : base(value) { }

        public static implicit operator CurrencyUSD(CurrencyRUB rub)
        {
            return new CurrencyUSD(rub.Value * 0.011);
        }

        public static implicit operator CurrencyEUR(CurrencyRUB rub)
        {
            return new CurrencyEUR(rub.Value * 0.01);
        }
    }

    class Program
    {
        static void Main()
        {
            //task1
            Vector vec1 = new Vector(1, 2, 3);
            Vector vec2 = new Vector(2, 3, 4);
            Vector vec3 = new Vector();
            Vector vec4 = new Vector();
            vec3 = vec1 + vec2;
            vec4 = 2.0 * vec1;
            Console.WriteLine($"sum = {vec3.x}, {vec3.y}, {vec3.z}, scalar mult = {vec2 * vec1}, mult = {vec4.x}, {vec4.y}, {vec4.z}");
            Console.WriteLine($"vec2>vec1? -{vec2 > vec1}");
            //task2
            CarsCatalog catalog = new CarsCatalog();
            catalog.cars.Add(new Car { Name = "BMW", Engine = "V8", MaxSpeed = 250 });
            catalog.cars.Add(new Car { Name = "Mercedes", Engine = "V8", MaxSpeed = 240 });

            Console.WriteLine(catalog[0]);
            Console.WriteLine(catalog[1]);

            //task3
            CurrencyUSD am1 = new CurrencyUSD(10);
            CurrencyEUR usd1 = am1;
            Console.WriteLine($"from usd to eur {usd1.Value}");
            CurrencyRUB rub1 = am1;
            Console.WriteLine($"from usd to rub {rub1.Value}");
            CurrencyRUB am2 = new CurrencyRUB(10);
            CurrencyEUR eur2 = am2;
            Console.WriteLine($"from rub to eur {eur2.Value}");
            CurrencyUSD usd2 = am2;
            Console.WriteLine($"from rub to usd {usd2.Value}");

        }
    }
}