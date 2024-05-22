namespace Kursovaya;

public partial class Task7 : ContentPage
{
    public Task7()
    {
        InitializeComponent();
        volumes.Add(12);
        volumes.Add(1);
        volumes.Add(2);
        volumes.Add(1);
        volumes.Add(4);

        prices.Add(4);
        prices.Add(2);
        prices.Add(2);
        prices.Add(1);
        prices.Add(10);
        printList();
    }

    static int V;
    static int S;
    static List<int> volumes = new List<int>();
    static List<int> prices = new List<int>();

    bool isFinished = false;

    static bool[] bestSolution;
    static int maxProfit = int.MinValue;

    static void BackPack(int i, int currentVolume, int currentProfit, bool[] massiv)
    {
        if (i == volumes.Count)
        {
            if (currentVolume <= V && currentProfit > maxProfit)
            {
                maxProfit = currentProfit;
                Array.Copy(massiv, bestSolution, massiv.Length);
            }
            return;
        }

        massiv[i] = true;
        BackPack(i + 1, currentVolume + volumes[i], currentProfit + prices[i], massiv);
        massiv[i] = false;
        BackPack(i + 1, currentVolume, currentProfit, massiv);
    }

    //static bool BackPack2(int i, int currentVolume, int currentProfit, bool[] massiv)
    //{
    //    massiv[i] = true;

    //    if (currentVolume + volumes[i] <= V && currentProfit + prices[i] >= S)
    //    {
    //        Array.Copy(massiv, bestSolution, massiv.Length);
    //        return true;
    //    }

    //    if (i == massiv.Length - 1) return false;

    //    if (BackPack2(i + 1, currentVolume + volumes[i], currentProfit + prices[i], massiv)) return true;
    //    else
    //    {
    //        massiv[i] = false;
    //        return BackPack2(i + 1, currentVolume, currentProfit, massiv);
    //    }
    //}


    void calcualteButton_Clicked(System.Object sender, System.EventArgs e)
    {
        maxProfit = int.MinValue;
        V = int.Parse(sliderValue.Text);
        labelAnswer.Text = String.Empty;

        int n = volumes.Count;
        bestSolution = new bool[n];

        BackPack(0, 0, 0, new bool[n]);

        FormattedString formattedString = new FormattedString();
        formattedString.Spans.Add(new Span() { Text = "Максимальная прибыль: " });
        formattedString.Spans.Add(new Span() { Text = maxProfit.ToString(), TextColor = Colors.Green });
        labelAnswer.FormattedText = formattedString;
        isFinished = true;
        printList();
    }


    void printList()
    {
        ItemsListGrid.Children.Clear();
        ItemsListGrid.RowDefinitions.Clear();
        for (int i = 0; i < volumes.Count; i++)
        {
            ItemsListGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            int currentRow = ItemsListGrid.RowDefinitions.Count - 1;
            int id = i;

            Label priceLabel = new Label() { Text = prices[i].ToString(), HorizontalOptions = LayoutOptions.Center };
            Label volumeLabel = new Label() { Text = volumes[i].ToString(), HorizontalOptions = LayoutOptions.Center };
            Button deletebutton = new Button() { Text = "x" };
            deletebutton.Clicked += (s, e) => deleteButtonClicked(id);

            if (isFinished && bestSolution[i])
            {
                priceLabel.TextColor = Colors.Green;
                volumeLabel.TextColor = Colors.Green;
            }

            ItemsListGrid.Add(priceLabel, 0, currentRow);
            ItemsListGrid.Add(volumeLabel, 1, currentRow);
            ItemsListGrid.Add(deletebutton, 2, currentRow);
        }
    }


    void addButton_Clicked(System.Object sender, System.EventArgs e)
    {
        isFinished = false;
        labelAnswer.Text = String.Empty;

        int price = int.Parse(priceEntry.Text);
        int volume = int.Parse(volumeEntry.Text);
        prices.Add(price);
        volumes.Add(volume);

        priceEntry.Text = String.Empty;
        volumeEntry.Text = String.Empty;

        printList();
    }


    public void deleteButtonClicked(int id)
    {
        isFinished = false;
        labelAnswer.Text = String.Empty;

        prices.RemoveAt(id);
        volumes.RemoveAt(id);
        printList();
    }


    void Slider_ValueChanged(System.Object sender, Microsoft.Maui.Controls.ValueChangedEventArgs e)
    {
        isFinished = false;
        labelAnswer.Text = String.Empty;
        int value = (int)e.NewValue;
        sliderValue.Text = value.ToString();
    }
}