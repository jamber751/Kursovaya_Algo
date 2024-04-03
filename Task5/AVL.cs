namespace Kursovaya
{
    class AVL
    {
        class Node
        {
            public int Value;
            public Node Left;
            public Node Right;

            public Node(int value)
            {
                Value = value;
            }
        }

        Node Root;

        public AVL()
        {
            Root = null;
        }

        public void Add(int value)
        {
            Node newItem = new Node(value);
            if (Root == null)
            {
                Root = newItem;
            }
            else
            {
                Root = RecursiveInsert(Root, newItem);
            }
        }

        private Node RecursiveInsert(Node currentNode, Node newNode)
        {
            if (currentNode == null)
            {
                currentNode = newNode;
                return currentNode;
            }
            else if (newNode.Value < currentNode.Value)
            {
                currentNode.Left = RecursiveInsert(currentNode.Left, newNode);
                currentNode = Balance(currentNode);
            }
            else if (newNode.Value > currentNode.Value)
            {
                currentNode.Right = RecursiveInsert(currentNode.Right, newNode);
                currentNode = Balance(currentNode);
            }
            return currentNode;
        }

        private Node Balance(Node currentNode)
        {
            int b_factor = BalanceFactor(currentNode);
            if (b_factor > 1)
            {
                if (BalanceFactor(currentNode.Left) > 0)
                {
                    currentNode = RotateLL(currentNode);
                }
                else
                {
                    currentNode = RotateLR(currentNode);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(currentNode.Right) > 0)
                {
                    currentNode = RotateRL(currentNode);
                }
                else
                {
                    currentNode = RotateRR(currentNode);
                }
            }
            return currentNode;
        }

        private int Height(Node currentNode)
        {
            int height = 0;
            if (currentNode != null)
            {
                int l = Height(currentNode.Left);
                int r = Height(currentNode.Right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }

        private int BalanceFactor(Node currentNode)
        {
            int l = Height(currentNode.Left);
            int r = Height(currentNode.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private Node RotateRR(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }

        private Node RotateLL(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }

        private Node RotateLR(Node parent)
        {
            Node pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }

        private Node RotateRL(Node parent)
        {
            Node pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }

    }
}

