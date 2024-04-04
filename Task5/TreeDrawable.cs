namespace Kursovaya
{
    public class TreeDrawable : IDrawable
    {
        public AVL Tree = new AVL();
        private int dXInitial = 150;
        private int D = 50;
        public int countNodes;

        (float, float) middlePoint = (1000, 100);

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            countNodes = 0;
            AVLNode node = Tree.Root;
            DrawLayer(canvas, node, middlePoint, dXInitial);
        }

        public void DrawLayer(ICanvas canvas, AVLNode node, (float, float) point, int dX)
        {
            canvas.StrokeColor = Colors.IndianRed;
            canvas.StrokeSize = 4;
            canvas.FontSize = 30;

            if (node.Left != null)
            {
                (float, float) newPoint = (point.Item1 - dX, point.Item2 + 100);
                canvas.DrawLine(point.Item1, point.Item2, newPoint.Item1, newPoint.Item2);
                DrawLayer(canvas, node.Left, newPoint, dX - 60);
            }
            if (node.Right != null)
            {
                (float, float) newPoint = (point.Item1 + dX, point.Item2 + 100);
                canvas.DrawLine(point.Item1, point.Item2, newPoint.Item1, newPoint.Item2);
                DrawLayer(canvas, node.Right, newPoint, dX - 60);
            }

            PathF path = new PathF();
            path.AppendCircle(point.Item1, point.Item2, D / 2);

            if ((node.Left == null && node.Right != null) || (node.Left != null && node.Right == null))
            {
                canvas.FillColor = Colors.LightSeaGreen;
                countNodes++;
            }
            else canvas.FillColor = Colors.AliceBlue;

            canvas.FillPath(path);
            canvas.DrawString(node.Value.ToString(), point.Item1 - D / 2, point.Item2 - D / 2, D, D, HorizontalAlignment.Center, VerticalAlignment.Center);
            canvas.DrawPath(path);
        }

        public void Count(AVLNode node)
        {
            if (node == null)
                return;

            if ((node.Left == null && node.Right != null) || (node.Left != null && node.Right == null))
                countNodes++;

            Count(node.Left);
            Count(node.Right);
        }
    }
}
