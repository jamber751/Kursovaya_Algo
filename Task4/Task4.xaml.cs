namespace Kursovaya;

public partial class Task4 : ContentPage
{

    public int SIZE = 20;
    static (int, int) RANGE = (1, 100);
    public LinkedList list;

    Random rnd = new Random();

    public Task4()
    {
        InitializeComponent();
    }

    public void GenerateList()
    {
        list = new LinkedList();
        for (int i = 0; i < SIZE; i++)
        {
            list.AddLast(rnd.Next(RANGE.Item1, RANGE.Item2));
        }
    }

    public int countQ()
    {
        int count = 0;
        LinkedListElement currentElement = list.First;
        while (currentElement is not null)
        {
            if (isQ(currentElement.number)) count++;
            currentElement = currentElement.Next;
        }
        return count;
    }


    public bool isQ(int number)
    {
        while (number > 10) number /= 10;
        return number == 3;
    }

    public void removeT()
    {
        if (list.Length == 0) return;

        LinkedListElement currentElement = list.First;

        while (currentElement.Next != null)
        {
            if (isT(currentElement.Next.number))
            {
                list.RemoveAfter(currentElement);
                continue;
            }
            currentElement = currentElement.Next;
        }

        if (list.Length > 0 && isT(list.First.number))
        {
            list.RemoveFirst();
        }
    }

    public bool isT(int number)
    {
        if (number < 4) return false;

        if (number % 2 == 0 || number % 3 == 0) return true;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0) return true;
        }
        return false;
    }

    public void PrintList()
    {
        labelAnswer.Text = String.Empty;

        FormattedString formattedString = new FormattedString();

        LinkedListElement currentElement = list.First;
        while (currentElement != null)
        {
            Span span = new Span { Text = currentElement.number.ToString() + "\n" };
            bool Q = isQ(currentElement.number);
            bool T = isT(currentElement.number);

            if (Q && T)
            {
                span.TextColor = Colors.DarkGoldenrod;
            }
            else if (Q)
            {
                span.TextColor = Colors.Green;
            }
            else if (T)
            {
                span.TextColor = Colors.Red;
            }

            formattedString.Spans.Add(span);
            currentElement = currentElement.Next;
        }
        labelAnswer.FormattedText = formattedString;
    }

    void generateButton_Clicked(System.Object sender, System.EventArgs e)
    {
        GenerateList();
        PrintList();
    }

    void countQButton_Clicked(System.Object sender, System.EventArgs e)
    {
        labelCountQ.Text = countQ().ToString();
    }

    void removeTButton_Clicked(System.Object sender, System.EventArgs e)
    {
        removeT();
        PrintList();
    }
}
