using System;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp20
{

    class MyClass
    {
        public MyClass(string str)
        {
            this.str = str;
        }

        public string? str { get; set; }

        public string? Space()
        {
            string result = string.Join("_", str.ToCharArray());//bu metodla tek-tek gelen her simvoldan sonraya "_" simvolunu elave edir

            return result;
        }

        public string? Reverse()
        {
            char[] charArray = str.ToCharArray();//char massivine ayiririq

            Array.Reverse(charArray); //ve sonra onlari tersine ceviririk

            string result = new string(charArray); //burda ise bir basa char massivini string tipine menimsedirik

            return result;
        }

    }

    class Run
    {
        public void runFunc(Func<string> funcDell,string str)
        {
            foreach (Func<string> item in funcDell.GetInvocationList())
            {
                str = item.Invoke();
                Console.WriteLine(str);
            }
        }
    }


    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter string");

            var str = Console.ReadLine();

            MyClass cls = new MyClass(str);

            Func<string> funcDell = new Func<string>(cls.Space); // params sadece sizin ora vereceyiniz parametrlerdi burda funcDell-e functionlari verirsiniz
            funcDell += cls.Reverse;

            Run run = new Run();
            run.runFunc(funcDell, str); //cagiranda Space() ve Reverse() functionlari ise dusmelidir

        }
    }
}
