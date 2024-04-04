namespace Kursovaya
{

    public class AVLNode

    {
        public int Value;
        public AVLNode Left;
        public AVLNode Right;

        public AVLNode(int value)
        {
            Value = value;
        }
    }

    public class AVL
    {
        public AVLNode Root;

        public AVL()
        {
            Root = null;
        }

        public void Add(int data)
        {
            AVLNode newItem = new AVLNode(data);
            if (Root == null)
            {
                Root = newItem;
            }
            else
            {
                Root = RecursiveInsert(Root, newItem);
            }
        }

        private AVLNode RecursiveInsert(AVLNode current, AVLNode n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.Value < current.Value)
            {
                current.Left = RecursiveInsert(current.Left, n);
                current = Balance(current);
            }
            else if (n.Value > current.Value)
            {
                current.Right = RecursiveInsert(current.Right, n);
                current = Balance(current);
            }
            return current;
        }

        private AVLNode Balance(AVLNode current)
        {
            int b_factor = BalanceFactor(current);
            if (b_factor > 1)
            {
                if (BalanceFactor(current.Left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (BalanceFactor(current.Right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }

        private int GetHeight(AVLNode current)
        {
            int height = 0;
            if (current != null)
            {
                int left = GetHeight(current.Left);
                int right = GetHeight(current.Right);
                height = Math.Max(left, right) + 1;
            }
            return height;
        }

        private int BalanceFactor(AVLNode current)
        {
            int l = GetHeight(current.Left);
            int r = GetHeight(current.Right);
            int b_factor = l - r;
            return b_factor;
        }

        private AVLNode RotateRR(AVLNode parent)
        {
            AVLNode pivot = parent.Right;
            parent.Right = pivot.Left;
            pivot.Left = parent;
            return pivot;
        }
        private AVLNode RotateLL(AVLNode parent)
        {
            AVLNode pivot = parent.Left;
            parent.Left = pivot.Right;
            pivot.Right = parent;
            return pivot;
        }
        private AVLNode RotateLR(AVLNode parent)
        {
            AVLNode pivot = parent.Left;
            parent.Left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private AVLNode RotateRL(AVLNode parent)
        {
            AVLNode pivot = parent.Right;
            parent.Right = RotateLL(pivot);
            return RotateRR(parent);
        }
    }
}