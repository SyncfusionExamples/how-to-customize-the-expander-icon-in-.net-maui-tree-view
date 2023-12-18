# how-to-customize-the-expander-icon-in-.net-maui-tree-view
This example demonstrates how to customize the the expander appearance in .NET MAUI TreeView (SfTreeView).

In [.NET MAUI TreeView](https://www.syncfusion.com/maui-controls/maui-treeview), you can have a flexible way to display hierarchical data. A common requirement is to customize the appearance of the TreeView, including the expander icon used to collapse and expand nodes. This article demonstrates how to replace the default expander icon with custom images in the Syncfusion .NET MAUI TreeView control.

## Hiding the Default Expander Icon

To hide the default expander icon, set the **ExpanderWidth** property to "0" in the SfTreeView control. This will remove the space reserved for the default expander, allowing you to use your own images for expanding and collapsing nodes.

```xml
<syncfusion:SfTreeView x:Name="treeView"
                       ExpanderWidth="0"
                       ItemsSource="{Binding ImageNodeInfo}"
                       ChildPropertyName="SubFiles"
                       ItemTemplateContextType="Node">
    <!-- ItemTemplate and other properties -->
</syncfusion:SfTreeView>
```

## Defining Custom Expander Images

Within the ItemTemplate, define a Grid that contains an Image for the expander. Bind the Source property of the Image to a converter that returns the appropriate image based on the expansion state of the node.

```xml
<syncfusion:SfTreeView.ItemTemplate>
    <DataTemplate>
        <Grid x:Name="grid" ColumnDefinitions="40, 40, *">
            <!-- Other grid definitions -->
            <Image x:Name="expanderImage"
                   Source="{Binding IsExpanded, Converter={StaticResource ExpanderIconConverter}}"
                   IsVisible="{Binding HasChildNodes, Converter={StaticResource ExpanderIconVisibilityConverter}}"
                   VerticalOptions="Center"
                   HorizontalOptions="Center"
                   HeightRequest="35"
                   WidthRequest="35">
            </Image>
            <!-- Other grid definitions -->
        </Grid>
    </DataTemplate>
</syncfusion:SfTreeView.ItemTemplate>
```

## Implementing Converters for Image Source and Visibility

Create converters that determine the image to display and whether the image should be visible based on the node's state.

```csharp
public class ExpanderIconConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? "expand.png" : "collapse.png";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

public class ExpanderIconVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (bool)value ? true : false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
```

## Handling Tap Gestures on the Custom Expander Image

To allow users to expand and collapse nodes by tapping the custom image, add a **TapGestureRecognizer** to the image and handle the tap event.

```csharp
protected override void OnAttachedTo(Grid bindable)
{
    expImage = bindable.FindByName<Image>("expanderImage");
    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
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
```

To see a working example of customizing the expander icon in .NET MAUI TreeView, you can view the sample on GitHub:

[View sample in GitHub](https://github.com/SyncfusionExamples/how-to-customize-the-expander-icon-in-.net-maui-tree-view)

## Conclusion

I hope you enjoyed learning about How to customize the expander icon in .NET MAUI TreeView.
You can refer to our [.NET MAUI TreeView](https://www.syncfusion.com/maui-controls/maui-treeview) feature tour page to know about its other groundbreaking feature representations and documentation, and how to quickly get started for configuration specifications. You can also explore our .NET MAUI TreeView example to understand how to create and present data. For current customers, you can check out our components from the License and Downloads page. If you are new to Syncfusion, you can try our 30-day free trial to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our support forums, Direct-Trac, or feedback portal. We are always happy to assist you!