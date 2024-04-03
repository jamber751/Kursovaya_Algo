namespace Kursovaya;

public partial class Task5 : ContentPage
{
    public Task5()
    {
        InitializeComponent();
    }

    Random rnd = new Random();
    static int SIZE = 20;
    int[] numbers = new int[SIZE];
    AVL tree = new AVL();

    public void GenerateNumbers(int size)
    {
        for (int i = 0; i < SIZE; i++)
        {
            numbers[i] = rnd.Next(1, 20);
        }
    }

    void startButton_Clicked(System.Object sender, System.EventArgs e)
    {
        foreach (int number in numbers)
        {
            tree.Add(number);
        }
    }


}