namespace Kursovaya;

public partial class Task3 : ContentPage
{
    public bool isOpen = false;
    int zadachiCount = 0;
    public int currentId = 0;

    Random rnd = new Random();
    public Queue<Zadacha> queue1 = new Queue<Zadacha>();
    public Queue<Zadacha> queue2 = new Queue<Zadacha>();


    static public Color[] colors = { Colors.Green, Colors.Red };

    private Timer generatorTimer;
    private Timer processor1Timer;
    private Timer processor2Timer;

    (int, int) generatorDelays = (200, 300);
    (int, int) processorDelays = (600, 700);

    public Task3()
    {
        InitializeComponent();
    }

    public void printQueue(Label label, Queue<Zadacha> queue)
    {
        label.Text = String.Empty;
        FormattedString formattedString = new FormattedString();
        foreach (Zadacha task in queue)
        {
            Span span = new Span { Text = task.Id.ToString() + '\n' };
            span.TextColor = colors[task.Type - 1];
            formattedString.Spans.Add(span);
        }
        label.FormattedText = formattedString;
        label.FontSize = 25;
    }

    void startButton_Clicked(System.Object sender, System.EventArgs e)
    {
        endButton.IsEnabled = true;
        startButton.IsEnabled = false;
        isOpen = true;

        generatorTimer = new Timer(Generator, null, 0, Timeout.Infinite);
        processor1Timer = new Timer(Processor1, null, 0, Timeout.Infinite);
        processor2Timer = new Timer(Processor2, null, 0, Timeout.Infinite);
    }

    void endButton_Clicked(System.Object sender, System.EventArgs e)
    {
        isOpen = false;
        endButton.IsEnabled = false;
        generatorTimer.Dispose();
    }

    async void Generator(object state)
    {
        if (isOpen)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                int type = rnd.Next(0, 101);
                type = type < 15 ? 1 : 2;
                Zadacha newTask = new Zadacha(currentId, type,
                    rnd.Next(processorDelays.Item1, processorDelays.Item2));
                if (newTask.Type == 1)
                {
                    queue1.Enqueue(newTask);
                    printQueue(q1, queue1);
                }
                else
                {
                    if (queue1.Count > queue2.Count)
                    {
                        queue2.Enqueue(newTask);
                        printQueue(q2, queue2);
                    }
                    else
                    {
                        queue1.Enqueue(newTask);
                        printQueue(q1, queue1);
                    }
                }
                generatorTimer.Change(rnd.Next(generatorDelays.Item1, generatorDelays.Item2),
                    Timeout.Infinite);
                currentId++;
            });
        }
    }


    public void stopProccessors()
    {
        processor1Timer.Dispose();
        processor2Timer.Dispose();
        startButton.IsEnabled = true;
        p1Button.Text = String.Empty;
        p2Button.Text = String.Empty;
    }


    async void Processor1(object state)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            p1Button.Text = String.Empty;
            if (queue1.Count == 0)
            {
                if (!isOpen && queue2.Count == 0)
                {
                    stopProccessors();
                    return;
                }
                processor1Timer.Change(0, Timeout.Infinite);
                return;
            }

            Zadacha zadacha = queue1.Dequeue();
            printQueue(q1, queue1);

            p1Button.Text = zadacha.Id.ToString();
            p1Button.TextColor = colors[zadacha.Type - 1];
            zadachiCount++;
            zadachiCountButton.Text = zadachiCount.ToString();
            processor1Timer.Change(zadacha.ExecTime, Timeout.Infinite);
        });
    }


    async void Processor2(object state)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            p2Button.Text = String.Empty;
            if (queue2.Count == 0)
            {
                if (!isOpen && queue1.Count == 0)
                {
                    stopProccessors();
                    return;
                }
                processor2Timer.Change(0, Timeout.Infinite);
                return;
            }

            Zadacha zadacha = queue2.Dequeue();
            printQueue(q2, queue2);

            p2Button.Text = zadacha.Id.ToString();
            p2Button.TextColor = colors[zadacha.Type - 1];

            zadachiCount++;
            zadachiCountButton.Text = zadachiCount.ToString();
            processor2Timer.Change(zadacha.ExecTime, Timeout.Infinite);
        });
    }

}