namespace Kursovaya;

public partial class Task5 : ContentPage
{
    TreeDrawable treeDrawable;

    public Task5()
    {
        InitializeComponent();
        treeDrawable = (TreeDrawable)treeCanvas.Drawable;
    }

    void addButton_Clicked(System.Object sender, System.EventArgs e)
    {
        treeDrawable.Tree.Add(int.Parse(valueEntry.Text));
        treeCanvas.Invalidate();
        valueEntry.Text = String.Empty;

        treeDrawable.countNodes = 0;
        treeDrawable.Count(treeDrawable.Tree.Root);
        countLabel.Text = treeDrawable.countNodes.ToString();
    }

    void clearButton_Clicked(System.Object sender, System.EventArgs e)
    {
        treeDrawable.Tree = new AVL();
        treeCanvas.Invalidate();
        countLabel.Text = string.Empty;
    }
}