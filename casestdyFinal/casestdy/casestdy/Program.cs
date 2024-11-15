using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace casestdy
{
    internal class Program
    {
 
        static void Main(string[] args)
        {
            List<int> no = new List<int>() { 1001, 1002 , 1003};
            List<string> name = new List<string>() { "Batuhan" , "Dumlu" , "Semıstan"};
            List<string> surname = new List<string>() { "Sahin", "Sahin" , "Vurdugil" };
            List<int> age = new List<int>() { 26 , 66 , 17};
            List<double> avg = new List<double>() { 97, 47 , 7};

            menu(no, name, surname, age, avg);

            Directory.CreateDirectory(@"C:\Users\batub\Desktop\öğrenciler");
            Console.WriteLine("dosya oluşturuldu");
            for (int i = 0; i < no.Count; i++) 
            {
                string uzantı = Path.Combine(@"C:\Users\batub\Desktop\öğrenciler", name[i]);
                File.WriteAllText(uzantı, $"{no[i]}-{name[i]}-{surname[i]}-{age[i]}-{avg[i]}");

            }
            Directory.CreateDirectory(@"C:\Users\batub\Desktop\başarısızöğrenciler");
            Console.WriteLine("dosya oluşturuldu");
            for (int i = 0; i < no.Count; i++)
            {
                if (avg[i] < 50)
                {
                    string uzantı = Path.Combine(@"C:\Users\batub\Desktop\başarısızöğrenciler", name[i]);
                    File.WriteAllText(uzantı, $"{no[i]}-{name[i]}-{surname[i]}-{age[i]}-{avg[i]}");
                }
            }
        }
        static void girdi(List<int> no,List<string> name,List<string> surname,List<int> age,List<double> avg)
        {
        here:
            Console.WriteLine("4 haneli öğrenci no girin");
            here1:
            try
            {
                
                int numara = int.Parse(Console.ReadLine());
                if (numara.ToString().Length != 4)
                {
                    Console.WriteLine("girdiğiniz numara 4 haneli değil");
                    goto here;
                }
                else if (no.Contains(numara))
                {
                    Console.WriteLine("Girdiğiniz numara zaten bulunmakta! Farklı bir numara giriniz");
                    goto here;
                }
                no.Add(numara);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Geçerli bir girdi giriniz");
                goto here1;
            }
            
            
                Console.WriteLine("isim giriniz");
                name.Add(Console.ReadLine());
                Console.WriteLine("Soyadı giriniz");
                surname.Add(Console.ReadLine());
            here2:
            try
            {
                Console.WriteLine("Yaş giriniz");
                age.Add(int.Parse(Console.ReadLine()));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Geçerli bir girdi giriniz");
                goto here2;
            }
            here3:
                try
            {
                Console.WriteLine("Ortalama giriniz");
                avg.Add(double.Parse(Console.ReadLine()));
            }
            catch (Exception ex) 
            {               
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Geçerli bir girdi giriniz");
                //listele(no, name, surname, age, avg);
                goto here3;
            }
        }

        static void menu(List<int> no,List<string> name,List<string> surname,List<int> age,List<double> avg)
        {
            bool cikis = true;
            do
            {
                Console.WriteLine("\n-----------------------\n");
                Console.WriteLine("1-Öğrenci listele\n2-Yeni öğrenci ekle\n3-Öğrenci sil\n4-Soyadına göre öğrenci ara\n5-Çıkış yap");
                Console.WriteLine("\n-----------------------\n");
                string islem = Console.ReadLine();
            
            
                switch (islem)
                {
                    case "1":
                        listele(no, name, surname, age, avg);
                        break;
                    case "2":
                        girdi(no, name, surname, age, avg);
                        break;
                    case "3":
                        sil(no, name, surname, age, avg);
                        break;
                    case "4":
                        soyadbul(no, name, surname, age, avg);
                        break;
                    case "5":
                        cikis = false;
                        break;
                    default:
                        Console.WriteLine("Geçerli bir numara tuşlayınız!");
                        break;


                }
            } while (cikis);
        }

        static void listele(List<int> no,List<string> name,List<string> surname,List<int> age, List<double> avg )
        {
            for (int i = 0; i < avg.Count; i++)
            {
                Console.WriteLine($"{no[i]}-{name[i]}-{surname[i]}-{age[i]}-{avg[i]}");
            }
        }

        static void sil(List<int> no, List<string> name, List<string> surname, List<int> age, List<double> avg)
        {
            here:
            try
            {


                Console.WriteLine("Silmek istediğiniz öğrenci no sunu giriniz: ");
                int silinecekno = int.Parse(Console.ReadLine());
                int index = no.IndexOf(silinecekno);
                no.RemoveAt(index);
                name.RemoveAt(index);
                surname.RemoveAt(index);
                age.RemoveAt(index);
                avg.RemoveAt(index);
                Console.WriteLine("Öğrenci silindi");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Geçerli bir numara giriniz");
                listele(no, name, surname, age, avg);
                goto here;

            }

        }

        static void soyadbul(List<int> no, List<string> name, List<string> surname, List<int> age, List<double> avg)
        {
            bool exit = true;
            int Firstİndex = 0;
            int index = 0;



            Console.WriteLine("Bulmak istediğiniz soyadı giriniz");
            string soyad = Console.ReadLine();

                while (exit)
                {

                    try
                    {

                        index = surname.IndexOf(soyad, Firstİndex);
                        Console.WriteLine("Index :" + index);
                    if (index == -1 && Firstİndex == 0)
                    {
                        Console.WriteLine("Soyadı bulunamadı");
                        break;
                    }
                    else if (index == -1)
                        Console.WriteLine("Çıkış yapılıyor");
                        break;
                
                        Firstİndex = index + 1;
                        Console.WriteLine($"Sunuç :{no[index]}-{name[index]}-{surname[index]}-{age[index]}-{avg[index]}");
                    


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                        Console.WriteLine("Geçerli bir soyadı giriniz");
                        listele(no, name, surname, age, avg);
                        break;                    

                    }
                }
                
            
        }


    }
}
