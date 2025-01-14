﻿using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.MarkupExtensions;
using AvaloniaMarkupSample.MvuSample;
using AvaloniaMarkupSample.MvvmSample;

namespace AvaloniaMarkupSample;

public class MainView : ViewBase
{
    protected override object Build() =>
        new TabControl()
            .SelectedIndex(0)
            .Items(
                new TabItem()
                    .Header("Hot reload")
                    .Content(
                        new StackPanel()
                            .Children(
                                new TextBlock()
                                    .Ref(out var textBlock)
                                    .Padding(12)
                                    .FontSize(30)
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .Foreground(new DynamicResourceExtension("SystemAccentColor"))
                                    .Text("Hello Hot Reload!"),

                                new Button()
                                    .Content("click me!")
                                    .HorizontalAlignment(HorizontalAlignment.Center)
                                    .OnClick(_ => textBlock.Text("Button clicked!"))
                            )
                    ),

                new TabItem()
                    .Header("MVVM")
                    .Content(
                        new Border()
                            .BorderBrush(Brushes.Gray)
                            .BorderThickness(1)
                            .Child(
                                new MvvmSampleView()
                            )
                    ),

                new TabItem()
                    .Header("MVU")
                    .Content(
                        new Border()
                            .BorderBrush(Brushes.Gray)
                            .BorderThickness(1)
                            .Child(
                                new SampleView()
                            )
                    ),

                new TabItem()
                    .Header("Styles")
                    .Content(
                        new Border()
                            .BorderBrush(Brushes.Gray)
                            .BorderThickness(1)
                            .Child(
                                new StylesSampleView()
                            )
                    ),

                new TabItem()
                    .Header("Item control")
                    .Content(
                        new Border()
                            .BorderBrush(Brushes.Gray)
                            .BorderThickness(1)
                            .Child(
                                new ItemControlSampleView()
                            )
                    ),

                new TabItem().Header("Custom controls")
                    .Content(
                        new StackPanel()
                            .Width(300)
                            .Children(
                                new TextBlock()
                                    .Text("Custom control example:"),

                                new Border()
                                    .BorderBrush(Brushes.Gray)
                                    .BorderThickness(1)
                                    .Child(
                                        new MyCustomControl()
                                            .Margin(20)
                                    ),

                                new TextBlock()
                                    .Text("Custom templated control example:"),

                                new Border()
                                    .BorderBrush(Brushes.Gray)
                                    .BorderThickness(1)
                                    .Child(
                                        new MyCustomTemplatedControl()
                                            .Ref(out var myCustomTemplatedControl)
                                            .Margin(20)
                                            .Template(StaticResources.Templates.MyControlTemplate)
                                    ),
                                new ToggleButton()
                                    .Ref(out var tb)
                                    .Content("Change template")
                                    .OnClick(args =>
                                    {
                                        myCustomTemplatedControl.Template = !(tb.IsChecked ?? false)
                                            ? StaticResources.Templates.MyControlTemplate
                                            : StaticResources.Templates.MyAnotherControlTemplate;
                                    })
                            )
                    ));
}