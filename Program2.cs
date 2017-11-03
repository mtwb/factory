using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public abstract class Sala
    {
        public static explicit operator Sala(int v)
        {
            Console.WriteLine("Sala: " + v);
            return null;
        }
    }

    public abstract class Miejsce
    {
        public static explicit operator Miejsce(int v)
        {
            Console.WriteLine("Miejsce: " + v);
            return null;
        }
    }

    public abstract class Cena
    {
        public static explicit operator Cena(int v)
        {
            Console.WriteLine("Cena: " + v+"zł");
            return null;
        }
    }


    public abstract class FabrykaAbstrakcyjna
    {
        public abstract Sala WybierzSale();
        public abstract Miejsce WybierzMiejsce();
        public abstract Cena ObliczCene();
    }

    public class MultikinoElblag : FabrykaAbstrakcyjna
    {
        public override Sala WybierzSale()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return (Sala)(randomNumber);
        }

        public override Miejsce WybierzMiejsce()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return (Miejsce)(randomNumber);
        }

        public override Cena ObliczCene()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 30);
            return (Cena)(randomNumber);
        }

    }

    public class MultikinoTczew : FabrykaAbstrakcyjna
    {
        public override Sala WybierzSale()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return (Sala)(randomNumber);
        }

        public override Miejsce WybierzMiejsce()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            return (Miejsce)(randomNumber);
        }

        public override Cena ObliczCene()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 30);
            return (Cena)(randomNumber);
        }
    }

    public class Klient
    {
        private Sala sala;
        private Miejsce miejsce;
        private Cena cena;

        public Klient(FabrykaAbstrakcyjna fabrykaAbstrakcyjna)
        {
            sala = fabrykaAbstrakcyjna.WybierzSale();
            miejsce = fabrykaAbstrakcyjna.WybierzMiejsce();
            cena = fabrykaAbstrakcyjna.ObliczCene();
        }
    }

    class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Film Batman");
            FabrykaAbstrakcyjna fabryka = new MultikinoElblag();
            Klient Kowalski = new Klient(fabryka);
            Console.ReadKey();
        }
    }
}
