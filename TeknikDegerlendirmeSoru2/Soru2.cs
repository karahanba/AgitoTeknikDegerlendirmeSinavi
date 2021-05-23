//2. Belli bir formata göre hazırlanmış aşağıdaki stringden standard outputta aşağıdaki çıktıyı üreten bir
//kod yazılmasını bekliyoruz.
//Varsayımlar ve kurallar:
//•Verilen stringte her harf 2 defa kullanılır ve aynı 2 harf arasında kalan harfler child harflerdir.
//•Verilen stringin daima düzgün formatta verildiğini kabul ediyoruz. String formatını kontrol edilmesine
//gerek yok.
//•Program istenilen dilde yazılabilir (java, C#, plsql, js vb.).
//•Standart outputta ağaç yapısını gösterecek şekilde bir çıktı bekliyoruz.
//•Verilen string sonsuz derinlikte bir ağaç olabilir.
//Örnek 1:
//Input:
//abccbdeeda
//Output:
//a
//- b
//--c
//- d
//--e
//Örnek 2:
//Input:
//abccddbeea
//Output:
//a
//- b
//--c
//--d
//- e

using System;
using System.Collections.Generic;
using System.Linq;

namespace TeknikDegerlendirmeSoru2
{
    class Soru2
    {
        public static List<string> GenerateOutput(string s)
        {
            //string'deki harflerden char dizisi oluşturduk.
            char[] chs = s.ToCharArray();

            List<char> initialList = chs.ToList();
            
            //farklı karakterleri içeren ayrı bir karakter dizisi daha oluşturduk,daha sonra oluşturulacak stringlist içerisinde ağaç yapısını oluşturabilmek için bunu kullanacağız.
            char[] distinctchs=s.Distinct().ToArray();

            List<string> stringlist = new List<string>();

            //bu döngü ile indexlere string değerleri ekliyoruz, ağaç yapısı için gereken indis değerler yeniden tanımlanacak.   
            foreach (var item in distinctchs)
            {
                stringlist.Add(item.ToString());
            }
            
            //initialList adında char listesi oluşturdum yukarıda.burada kullanıcam
            foreach (var item in distinctchs)// example : a, b, c, d, e
            {
                //döngü içerisinde ilk kez karşılaşılan harfler bu listeye eklenecek, daha sonra buraya eklenmiş olan bir harf ile karşılaşılırsa stringin başına "-" eklenecek.
                List<string> controlList = new List<string>();

                // her char için kendisi ile aynı chara ulaşana dek işlem yapacak
                for (int myindex = initialList.IndexOf(item)+1; myindex < initialList.LastIndexOf(item); myindex++)
                {
                    if (controlList.Contains(initialList[myindex].ToString()))
                    {
                        //string başına "-" ekle
                        var match = stringlist.FirstOrDefault(stringtocheck => stringtocheck.Contains(initialList[myindex]));
                        stringlist[stringlist.IndexOf(match)] = stringlist[stringlist.IndexOf(match)].Insert(0, "-");

                    }
                    else
                    {
                        //ilk kez karşılaşılan harfi controlList'e ekle
                        controlList.Add(initialList[myindex].ToString());

                    }
                }
            }

            // oluşturulan listeyi konsol ekranına yazdırmak üzere Main() metoda gönderdik.
            return stringlist;
        }

        static void Main()
        {
            string input1 = "abccbdeeda";
            string input2 = "abccddbeea";
            Console.WriteLine("Type 1 for: abccbdeeda or 2 for: abccddbeea");

            string input = (Console.ReadLine() == 1.ToString()) ? input1 : input2;

            foreach (var item in GenerateOutput(input))
            {
                Console.WriteLine(item);
            }
        }
    }
}
