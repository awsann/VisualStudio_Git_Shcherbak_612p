using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;
try
{
    Console.Write("Введіть розмір масиву-->");
    int size = int.Parse(Console.ReadLine());
    if (size <= 0) throw new Exception("Невірний діапазон. Потрібно size > 0");
    int[] a = new int[size];
    RandArray(a);
    Console.WriteLine("Ініціалізація масиву");
    PrintArray(a);
    int index = First(a);
    index += 1;
    //умова index недорівнює 0
    if (index !=0 )
    {
        Console.WriteLine("Номер першого парного елемента: " + index);
        if (index==1)
        {
            Console.WriteLine("Елементи масиву залишаються без змін:");
            PrintArray(a);
        }
        else
        {
            DeleteEl(ref a);
            Console.WriteLine("Масив після видалення елементів перед першим парним:");
            PrintArray(a);
        }
    }
    else
    {
        Console.WriteLine("Парного елемента немає в масиві.");
        Console.WriteLine("Елементи масиву залишаються без змін:");
        PrintArray(a);
    }
}
catch (FormatException)
{
    Console.WriteLine("Невірний формат введених даних");
}
catch (Exception ex)
{
    Console.WriteLine("Помилка: " + ex.Message);
}

static void RandArray(int[] Mas)
{
    Random m = new Random();
    for (int i = 0; i < Mas.Length; i++)
    {
        Mas[i] = m.Next(-Mas.Length, Mas.Length+1);
    }
}

static void PrintArray(int[] Mas)
{
    foreach (int el in Mas)
        Console.Write(el.ToString() + "\t");
    Console.WriteLine();       
}

//знаходження першого парного елемента
static int First(int[] Mas)
{
    for (int i = 0; i < Mas.Length; i++)
    {
        if (Mas[i] % 2 == 0)
        {
            return i;
        }
    }
    return -1;
}

//видалення елементів, які знаходяться перед першим парним
static void DeleteEl(ref int[] Mas)
{
    int index = First(Mas);
    if (index > 0)
    {
        for (int i = 0; i < Mas.Length - index; i++)
        {
            Mas[i] = Mas[index + i];
        }
        Array.Resize(ref Mas, Mas.Length - index);
    }
}