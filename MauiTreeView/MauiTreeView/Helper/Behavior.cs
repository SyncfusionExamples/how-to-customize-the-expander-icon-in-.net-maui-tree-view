using Syncfusion.Maui.TreeView;
using Syncfusion.TreeView.Engine;

namespace MauiTreeView
{
    public class TreeViewBehavior : Behavior<Grid>
    {
        public SfTreeView treeView { get; set; }

        Image expImage;
        TapGestureRecognizer tapGestureRecognizer;
        protected override void OnAttachedTo(Grid bindable)
        {
            expImage = bindable.FindByName<Image>("expanderImage");
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnImageTapGestureTapped;
            expImage.GestureRecognizers.Add(tapGestureRecognizer);
            base.OnAttachedTo(bindable);
        }

        private void OnImageTapGestureTapped(object sender, TappedEventArgs e)
        {
            var treeViewNode = expImage.BindingContext as TreeViewNode;
            if (treeViewNode.IsExpanded)
                treeView.CollapseNode(treeViewNode);
            else
                treeView.ExpandNode(treeViewNode);
        }

        protected override void OnDetachingFrom(Grid bindable)
        {
            expImage.GestureRecognizers.Clear();
            tapGestureRecognizer.Tapped -= OnImageTapGestureTapped;
            tapGestureRecognizer = null;
            base.OnDetachingFrom(bindable);
        }
    }

}
