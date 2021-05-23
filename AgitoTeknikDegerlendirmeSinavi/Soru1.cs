//1. 9 büyüklüğündeki bir listeyi 1 den 9 a kadar tekrar etmeyecek şekilde random olarak dolduran ve
//kaç kere random kodunun çağrıldığını output a yazan kodu yazınız. Bu sorunun cevabında
//beklenen; random fonksiyonun minimum seviyede çağırılmasıdır. Random fonksiyonun çağırım
//adedine göre puanlama yapılacaktır.
//Varsayımlar ve kurallar:
//•İndise eklenen bir rakam tekrar edemez.
//•Eklenecek rakam hardcode olarak eklenemez.
//Örnek 1:
//5,2,3,8,1,4,6,9,7 Random fonksiyonu 24 kere çalışmıştır.
//Örnek 2:
//4,1,3,2,7,9,5,6,8 Random fonksiyonu 86 kere çalışmıştır.

using System;
using System.Collections.Generic;

namespace TeknikDegerlendirmeSoru1
{
    public class Soru1
    {
        public static int CreateList(int n)
        {
            int randomNumber;
            int randomCount=0;
            Random rnd = new Random();
            List<int> numberlist = new List<int>();

            while (numberlist.Count<9)
            {
                randomNumber = rnd.Next(1, 10);
                randomCount++;
                Console.WriteLine("randomCount=" + randomCount);
                if (!numberlist.Contains(randomNumber))
                {
                    numberlist.Add(randomNumber);
                    Console.WriteLine("random number"+randomNumber+"added to number list");
                }
                else
                {
                    Console.WriteLine("bu sayı zaten var,"+randomNumber);
                }
                
            }

            foreach (var item in numberlist)
            {
                Console.WriteLine(item);
            }

            return randomCount;
        }

        static void Main()
        {
            int listLength = 8;
            Console.WriteLine("Random fonksiyonu " + CreateList(listLength) + " kere çalıştırılmıştır");



        }
    }
}