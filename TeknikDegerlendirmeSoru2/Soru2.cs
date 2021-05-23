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
        public static string GenerateOutput(string s)
        {
            string deneme="boş";
            //deneme = s;

            //string'den character dizisi oluşturduk.
            char[] chs = s.ToCharArray();

            List<char> initialList = chs.ToList();
            //Console.WriteLine(chs);

            //farklı karakterleri içeren ayrı bir karakter dizisi daha oluşturduk,daha sonra oluşturulacak stringlist içerisinde ağaç yapısını oluşturabilmek için bunu kullanacağız.
            char[] distinctchs=s.Distinct().ToArray();

            List<string> stringlist = new List<string>();

            //indexlere string değerler eklendi, daha sonra gereken indis değeri yeniden tanımlanacak.   
            foreach (var item in distinctchs)
            {
                stringlist.Add(item.ToString());
            }
            //string modified = original.Insert(0, "-");
            ///stringlist[2] = stringlist[2].Insert(0, "-");// example for string update for specific index

            //Kontrol için
            //foreach (var item in stringlist)
            //{
            //    Console.WriteLine(item);
            //}

            ///////BURAYA KADAR OK //////
            ///
            string firstindexvalue;
            string secondindexvalue;

            //güzel ama işlem hatalı, sonucu optimize etmeye çalışalım
            //for (int firstindex = 0; firstindex < chs.Length; firstindex++)
            //{
            //    firstindexvalue = chs[firstindex].ToString();
            //    for (int secondindex = firstindex; secondindex < chs.Length; secondindex++)
            //    {
            //        secondindexvalue = chs[secondindex].ToString();
            //        if(chs[secondindex] != chs[firstindex])//while (chs[secondindex] != chs[firstindex])
            //        {
            //            var match = stringlist.FirstOrDefault(stringtocheck => stringtocheck.Contains(secondindexvalue));


            //            stringlist[stringlist.IndexOf(match)] = stringlist[stringlist.IndexOf(match)].Insert(0, "-");
            //            //stringlist[stringlist.IndexOf(secondindexvalue)] = stringlist[stringlist.IndexOf(secondindexvalue)].Insert(0, "-");


            //        }
            //    }

            //    //Console.WriteLine(stringlist[i]);


            //}

            

            //üstteki for döngüsünün değiştirilmiş versiyonu yapılacak...
            //initialList adında char listesi oluşturdum yukarıda.burada kullanıcam
            foreach (var item in distinctchs)// example : a, b, c, d, e
            {
                //döngü içerisinde ilk kez karşılaşılan harfler buraya yazılacak, daha sonra buraya yazılmış olan bir harf ile karşılaşılırsa stringin başına "-" eklenecek. ayrıca listeyi seferinde sıfırlamak gerekebilir ona bakacağım!!düzeltme!!Foreach içindeyken sıfırlamak gerekmeyebilir...
                List<string> controlList = new List<string>();

                // her char için kendisi ile aynı chara ulaşana dek işlem yapacak
                for (int myindex = initialList.IndexOf(item)+1; myindex < initialList.LastIndexOf(item); myindex++)
                {
                    if (controlList.Contains(initialList[myindex].ToString()))//item !=initialList[myindex])
                    {
                        //string başına "-" ekle

                        var match = stringlist.FirstOrDefault(stringtocheck => stringtocheck.Contains(initialList[myindex]));
                        stringlist[stringlist.IndexOf(match)] = stringlist[stringlist.IndexOf(match)].Insert(0, "-");
                        //stringlist[stringlist.IndexOf(initialList[myindex].ToString())]=stringlist[stringlist.IndexOf(initialList[myindex].ToString())].Insert(0, "-");

                        //            var match = stringlist.FirstOrDefault(stringtocheck => stringtocheck.Contains(secondindexvalue));
                        //            stringlist[stringlist.IndexOf(match)] = stringlist[stringlist.IndexOf(match)].Insert(0, "-");

                    }
                    else
                    {
                        //controlList'e harfi ekle ekle
                        controlList.Add(initialList[myindex].ToString());

                    }
                }
            }

            //Kontrol için
            foreach (var item in stringlist)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("//////////seperator//////////");
            for (int i = 0; i < chs.Length; i++)
            {
                for (int j = 0; j < chs.Length; j++)
                {
                    if (i!=j && chs[i]==chs[j])
                    {
                        Console.WriteLine("Harf=" + chs[i] + ", Indexler " + i + " ve " + j);
                    }
                }
            }

            



            //for (int i = 0; i < distinctchs.Length; i++)
            //{
            //    string original = distinctchs[i].ToString();
            //    Console.WriteLine("Original" + original);
            //}

            //foreach (var item in chs)
            //{

            //    Console.WriteLine(item);
            //}
            //Console.WriteLine("///seperator///");
            //foreach (var item in distinctchs)
            //{

            //    Console.WriteLine(item);
            //}


            //string original="";
            //string modified = original.Insert(0, "-");



            return deneme;
        }

        static void Main()
        {
            string input1 = "abccbdeeda";
            string input2 = "abccddbeea";
            Console.WriteLine("Type 1 for: abccbdeeda or 2 for: abccddbeea");
            //if(Console.ReadLine()==1.ToString()?)

            string input = (Console.ReadLine() == 1.ToString()) ? input1 : input2;
            Console.WriteLine(GenerateOutput(input));
        }
    }
}
