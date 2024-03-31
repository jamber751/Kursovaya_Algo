namespace Kursovaya;

public partial class Task6 : ContentPage
{
    public Task6()
    {
        InitializeComponent();
    }

    Random rnd = new Random();
    static int RAZMER = 21;
    Person[] massiv = new Person[RAZMER];

    string[] names = { "Жамбыл", "Амир", "Коля", "Тимур", "Дони", "Хамзат", "Аружан", "Карлыгаш" };
    string[] familyNames = { "Отарбаев", "Пшембаев", "Ермаков", "Маханов", "Мендыбаев", "Мамышев", "Букенова", "Ризуанова" };

    public class Person
    {
        public String Name { get; set; }
        public int Height { get; set; }
        public Person(string name, int height)
        {
            this.Name = name;
            this.Height = height;
        }
    }

    public void generatePeople()
    {
        for (int i = 0; i < RAZMER; i++)
        {
            string name = names[rnd.Next(0, names.Length)] + " " + familyNames[rnd.Next(0, names.Length)];
            massiv[i] = new Person(name, rnd.Next(150, 200));
        }
    }

    public void sortPeople()
    {
        for (int i = 0; i < massiv.Length - 1; i++)
        {
            for (int j = 0; j < massiv.Length - 1 - i; j++)
            {
                if (massiv[j].Height > massiv[j + 1].Height)
                {
                    Person person = massiv[j];
                    massiv[j] = massiv[j + 1];
                    massiv[j + 1] = person;
                }
            }
        }
    }

    void generateButton_Clicked(System.Object sender, System.EventArgs e)
    {
        generatePeople();
        labelAnswer.Text = String.Empty;
        FormattedString formattedString = new FormattedString();
        for (int i = 0; i < RAZMER; i++)
        {
            Span span = new Span { Text = (i + 1).ToString() + ". " + massiv[i].Name + " - " + massiv[i].Height.ToString() + "\n" };
            formattedString.Spans.Add(span);
        }
        labelAnswer.FormattedText = formattedString;
    }

    void sortButton_Clicked(System.Object sender, System.EventArgs e)
    {
        sortPeople();
        labelAnswer.Text = String.Empty;
        FormattedString formattedString = new FormattedString();
        for (int i = 0; i < RAZMER; i++)
        {
            Span span = new Span { Text = (i + 1).ToString() + ". " + massiv[i].Name + " - " + massiv[i].Height.ToString() + "\n" };

            if (i == RAZMER / 2)
            {
                span.TextColor = Colors.Red;
            }

            formattedString.Spans.Add(span);
        }
        labelAnswer.FormattedText = formattedString;
    }
}
