namespace Kursovaya
{
    public class LinkedList
    {
        public LinkedListElement First { get; set; }
        public int Length { get; set; }

        public LinkedList()
        {
            First = null;
            Length = 0;
        }

        public void AddLast(int number)
        {
            if (Length == 0)
            {
                First = new LinkedListElement(number);
            }
            else
            {
                LinkedListElement currentElement = First;
                while (currentElement.Next != null)
                {
                    currentElement = currentElement.Next;
                }
                currentElement.Next = new LinkedListElement(number);
            }
            Length++;
        }

        public void AddAfter(LinkedListElement currentElement, int number)
        {
            if (currentElement.Next is null || Length == 0)
            {
                AddLast(number);
                return;
            }
            LinkedListElement nextElement = currentElement.Next.Next;
            currentElement.Next = new LinkedListElement(number);
            currentElement.Next.Next = nextElement;
            Length++;
        }

        public void RemoveFirst()
        {
            if (Length == 0) return;
            First = First.Next;
            Length--;
        }

        public void RemoveAfter(LinkedListElement currentElement)
        {
            if (currentElement.Next is null) return;
            currentElement.Next = currentElement.Next.Next;
            Length--;
        }
    }
}