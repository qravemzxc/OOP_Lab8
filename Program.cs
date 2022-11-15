using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;
using static Lab8.Programmer;

namespace Lab8
{
    class Programmer
    {

        public delegate void LangHandler1(string name1,string name2,string name3);
        public delegate void LangHandlerMessage(string message);
        public event LangHandlerMessage? NewName;
        public event LangHandlerMessage? NewProperty;
        public delegate void LangHandler2(int version1, int version2, int version3);
        public delegate void LangHandler3(string[] opt1, string[] opt2, string[] opt3);
        public delegate void LambdaMessage();
        public delegate void Action();
        public string nameLang1 { get; set; }
        public int versionLang1 { get; set; }
        public string[] optArr1 = new string[10];
        public string nameLang2 { get; set; }
        public int versionLang2 { get; set; }
        public string[] optArr2 { get; set; }
        public string nameLang3 { get; set; }
        public int versionLang3 = 3;
        public string[] optArr3 { get; set; }
        public Programmer(string nameLang, int versionLang)
        {
            nameLang1 = nameLang;
            versionLang1 = versionLang;
            optArr1 = new string[] {"coding","compiling" };
        }
        public Programmer(int versionLang, string nameLang)
        {
            nameLang2 = nameLang;
            versionLang2 = versionLang;
            optArr2 = new string[] { "compiling"};
        }
        public Programmer(string nameLang)
        {
            nameLang3 = nameLang;
            optArr3 = new string[] { "coding", "compiling" };
        }
        static LambdaMessage mes1 = () => Console.WriteLine("Имя какого языка хотите изменить?");
        static LambdaMessage mes2 = () => Console.WriteLine("Версию какого языка хотите изменить?");
        static LambdaMessage mes3 = () => Console.WriteLine("Для какого языка хотите добавить новые функции?");
        public void Rename(string name1,string name2,string name3)
        {
            int number=0;
            while (number != 4)
            {
                mes1();
                number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    Console.WriteLine("Введите новое имя");
                    string newName = Console.ReadLine();
                    name1 = newName;
                    NewName?.Invoke($"Новое имя первого языка:{name1}");
                }
                else if (number == 2)
                {
                    Console.WriteLine("Введите новое имя");
                    string newName = Console.ReadLine();
                    name2 = newName;
                    NewName?.Invoke($"Новое имя второго языка:{name2}");
                }
                else if (number == 3)
                {
                    Console.WriteLine("Введите новое имя");
                    string newName = Console.ReadLine();
                    name3 = newName;
                    NewName?.Invoke($"Новое имя третьего языка:{name3}");

                }
                else {
                    break;
                }
            }
        }
        public void Reversion(int version1,int version2,int version3)
        {
            int number = 0;
            while (number != 4)
            {
                mes2();
                number = Convert.ToInt32(Console.ReadLine());
                if (number == 1)
                {
                    Console.WriteLine("Ввидет номер версии");
                    int newVersion = Convert.ToInt32(Console.ReadLine());
                    version1 = newVersion;
                    NewName?.Invoke($"Новая версия первого языка:{version1}");
                }
                if (number == 2)
                {
                    Console.WriteLine("Ввидет номер версии");
                    int newVersion = Convert.ToInt32(Console.ReadLine());
                    version2 = newVersion;
                    NewName?.Invoke($"Новая версия второго языка:{version2}");
                }
                if (number == 3)
                {
                    Console.WriteLine("Ввидет номер версии");
                    int newVersion = Convert.ToInt32(Console.ReadLine());
                    version3 = newVersion;
                    NewName?.Invoke($"Новая версия третьего языка:{version3}");
                }
            }
        }
        public void AddOptions(string[]opt1,string[]opt2,string []opt3)
        {
            int number = 0;
            while(number != 4)
            {
                mes3();
                number = Convert.ToInt32(Console.ReadLine());
                if(number == 1)
                {
                    string opt = "q";
                    while (opt != "0")
                    {
                        int i = 1;
                        Console.WriteLine("какую опцию хотите добавить?");
                        opt = Console.ReadLine();
                        if (opt == "0")
                            break;
                        Array.Resize(ref opt1, opt1.Length + i);
                        opt1[opt1.Length-1] = opt;
                        NewProperty?.Invoke($"Функция добавлена успешно");
                        i++;
                    }
                    Console.Write($"Функции первого языка:");
                    for (int i=0; i < opt1.Length; i++)
                    {
                        Console.Write($"{opt1[i]},");
                    }
                    Console.WriteLine();
                }
                if (number == 2)
                {
                    string opt = "q";
                    while (opt != "0")
                    {
                        int i = 1;
                        Console.WriteLine("какую опцию хотите добавить?");
                        opt = Console.ReadLine();
                        if (opt == "0")
                            break;
                        Array.Resize(ref opt2, opt2.Length + i);
                        opt2[opt2.Length - 1] = opt;
                        NewProperty?.Invoke($"Функция добавлена успешно");
                        i++;
                    }
                    Console.Write($"Функции первого языка:");
                    for (int i = 0; i < opt2.Length; i++)
                    {
                        Console.Write($"{opt2[i]},");
                    }
                    Console.WriteLine();
                }
                if (number == 3)
                {
                    string opt = "q";
                    while (opt != "0")
                    {
                        int i = 1;
                        Console.WriteLine("какую опцию хотите добавить?");
                        opt = Console.ReadLine();
                        if (opt == "0")
                            break;
                        Array.Resize(ref opt3, opt3.Length + i);
                        opt3[opt3.Length - 1] = opt;
                        NewProperty?.Invoke($"Функция добавлена успешно");
                        i++;
                    }
                    Console.Write($"Функции первого языка:");
                    for (int i = 0; i < opt3.Length; i++)
                    {
                        Console.Write($"{opt3[i]},");
                    }
                    Console.WriteLine();
                }
               
            }
        }

    }
    class UserProcess
    {
        public static void DltPM(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char c in str)
            {
                if(!char.IsPunctuation(c))
                    sb.Append(c);
            }
            Console.WriteLine($"Новая строка:{sb.ToString()}"); 
        }
        public static void AddSymbols(string str)
        {
            Console.Write("Введите символы для добавления:");
            string newStr = Console.ReadLine();
            Func<string, string, string> createString = (str,newStr) => $"Новая строка:{str.Insert(str.Length , newStr)}";
            Console.WriteLine(createString(str,newStr));
           
        }
        public static void UpperStr(string str)
        {
            Console.WriteLine($"Новая строка:{str.ToUpper()}");
        }
        public static void DltSpace(string str)
        {
            bool flag = true;
            Console.Write("Новая строка:");
            for(int i = 0; i < str.Length; i++)
            {
             
                    if(str[i]!=' ')
                    {
                        flag = true;
                        Console.Write($"{str[i]}");
                    }
                    else if (str[i]==' ')
                    {
                        
                        if (flag == true)
                        {
                            Console.Write($"{str[i]}");
                            flag = false;
                        }
                        
                    }
             }
        }
        public static void ReplaceSymb(string str)
        {
            Console.Write("Какой символ хотите заменить?");
            char s1 = Convert.ToChar(Console.ReadLine());
            Console.Write($"На что изменить символ {s1}?");
            char s2 = Convert.ToChar(Console.ReadLine());
            string str1 = str;
            str1 = str1.Replace(s1, s2);
            Console.WriteLine($"Новая строка:{str1}");
            Predicate<string> isPositive = (string str1) => str1!=str;
            Console.WriteLine($"Строка изменена?{isPositive(str1)}");
        }
      
 
    }
    class Program
    {
        static void Main(string[] args)
        {
            Programmer lang1 = new Programmer("java", 17);
            Programmer lang2 = new Programmer(9, "js");
            Programmer lang3 = new Programmer("python");


            lang1.NewName += DisplayMessage;
            lang1.NewProperty += DisplayMessage;
            lang2.NewName += DisplayMessage;
            lang2.NewProperty += DisplayMessage;
            lang3.NewName += DisplayMessage;
            lang3.NewProperty += DisplayMessage;
            void DisplayMessage(string message) => Console.WriteLine(message);


            LangHandler1 handler1 = lang1.Rename;
            handler1(lang1.nameLang1, lang2.nameLang2, lang3.nameLang3);
            LangHandler2 handler2 = lang1.Reversion;
            handler2(lang1.versionLang1, lang2.versionLang2, lang3.versionLang3);
            LangHandler3 handler3 = lang1.AddOptions;
            handler3(lang1.optArr1, lang2.optArr2, lang3.optArr3);

            Console.Write("Введите строку:");
            string userStr = Console.ReadLine();
            UserProcess.DoOperation(userStr, UserProcess.DltPM);


            Console.Write("Введите строку:");
            string userStr1 = Console.ReadLine();
            UserProcess.AddSymbols(userStr1);

         
            Console.Write("Введите строку:");
            string userStr2 = Console.ReadLine();
            UserProcess.UpperStr(userStr2);


            Console.Write("Введите строку:");
            string userStr3 = Console.ReadLine();
            UserProcess.DltSpace(userStr3);
            Console.WriteLine();


            Console.Write("Введите строку:");
            string userStr4 = Console.ReadLine();
            UserProcess.ReplaceSymb(userStr4);


        }

    }

}

