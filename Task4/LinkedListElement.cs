#nullable enable

namespace Kursovaya
{
    public class LinkedListElement
    {
        public LinkedListElement(int number)
        {
            this.number = number;
            Next = null;
        }
        public int number { get; set; }
        public LinkedListElement? Next { get; set; }
    }
}

