namespace Kursovaya;

public partial class Task2 : ContentPage
{
    public Task2()
    {
        InitializeComponent();
    }

    void calculateButton_Clicked(System.Object sender, System.EventArgs e)
    {

        String vyrazhenie = labelVyrazhenie.Text;

        labelPostfix.Text = InfixToPostfix(vyrazhenie);

        Stack<double> stack = new Stack<double>();

        foreach (Char c in labelPostfix.Text)
        {
            if (Char.IsDigit(c))
            {
                stack.Push(double.Parse(c.ToString()));
            }
            else
            {
                double operand2 = stack.Pop();
                double operand1 = stack.Pop();
                double result = Operaciya(operand1, operand2, c);
                stack.Push(result);
            }
        }

        labelResult.Text = stack.Pop().ToString();
    }

    public double Operaciya(double op1, double op2, Char operaciya)
    {
        switch (operaciya)
        {
            case '+':
                return op1 + op2;
            case '-':
                return op1 - op2;
            case '*':
                return op1 * op2;
            case '/':
                return op1 / op2;
            case '^':
                return Math.Pow(op1, op2);
            default:
                throw new ArgumentException($"Неподдерживаемая операция: {operaciya}");
        }
    }

    static string InfixToPostfix(string s)
    {
        Stack<char> stack = new Stack<char>();
        String result = String.Empty;

        foreach (Char c in s)
        {
            if (Char.IsDigit(c))
            {
                result += c;
            }
            else if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                while (stack.Count > 0 && stack.Peek() != '(')
                {
                    result += stack.Pop();
                }
                stack.Pop();
            }
            else
            {
                while (stack.Count > 0 && (Prioritet(c) <= Prioritet(stack.Peek())))
                {
                    result += stack.Pop();
                }
                stack.Push(c);
            }
        }

        while (stack.Count > 0)
        {
            result += stack.Pop();
        }
        return result;
    }

    static int Prioritet(char c)
    {
        if (c == '^')
            return 3;
        else if (c == '/' || c == '*')
            return 2;
        else if (c == '+' || c == '-')
            return 1;
        else
            return -1;
    }
}