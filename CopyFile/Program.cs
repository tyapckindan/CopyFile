public class Program
{
    public static void Main()
    {
        string src1 = @"C:\Users\DELL\Desktop\file1.txt";
        Console.WriteLine("Введите название файла:");
        string name = Console.ReadLine();
        Console.WriteLine("Введите путь файла:");
        string way = Console.ReadLine();
        File.Copy(src1, (@"" + way + name + ".txt"));

        Console.WriteLine("Последовательное копирование: ");
        DateTime dt1 = DateTime.Now;
        string src = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word.docx";
        string dest = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word копия.docx";
        try
        {
            if (File.Exists(src) && !File.Exists(dest))
            {
                FileInfo fi = new(src);
                fi.CopyTo(dest);
            }
            else
                Console.WriteLine("Исходный файл не существует или существует файл назначения.");
            string src2 = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word 2.docx";
            string dest2 = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word 2 копия.docx";
            if (File.Exists(src2) && !File.Exists(dest2))
            {
                FileInfo fi = new(src2);
                fi.CopyTo(dest2);
            }
            else
                Console.WriteLine("Исходный файл не существует или существует файл назначения.");
            Timer(dt1);

            Console.WriteLine("Паралельное копирование: ");
            DateTime dt2 = DateTime.Now;
            Thread th = new(Copy);
            th.Start();
            string src3 = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word.docx";
            string dest3 = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word 3 копия.docx";
            File.Copy(src3, dest3);
            Timer(dt2);
        }
        catch (Exception)
        {

        }
    }
    public static void Timer(DateTime dt1)
    {
        DateTime dt2 = DateTime.Now;
        TimeSpan ts = dt2 - dt1;
        Console.WriteLine("Total time: {0}", ts.TotalMilliseconds);
    }

    public static void Copy()
    {
        string src = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word 2.docx";
        string dest = @"C:\Users\DELL\Desktop\Документ Microsoft Office Word 4 копия.docx";
        File.Copy(src, dest);
    }
}