using Microsoft.Maui.Controls;

namespace Anacrusa.Views.SideBar
{
    public partial class SideBarItemView : ContentView
    {
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(SideBarItemView), string.Empty);

        public static readonly BindableProperty GlyphProperty =
            BindableProperty.Create(nameof(Glyph), typeof(string), typeof(SideBarItemView), string.Empty);

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(SideBarItemView), false, propertyChanged: OnSelectionChanged);

        public static readonly BindableProperty IsExpandedProperty =
            BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(SideBarItemView), true, propertyChanged: OnExpansionChanged);

        public string Text { get => (string)GetValue(TextProperty); set => SetValue(TextProperty, value); }
        public string Glyph { get => (string)GetValue(GlyphProperty); set => SetValue(GlyphProperty, value); }
        public bool IsSelected { get => (bool)GetValue(IsSelectedProperty); set => SetValue(IsSelectedProperty, value); }
        public bool IsExpanded { get => (bool)GetValue(IsExpandedProperty); set => SetValue(IsExpandedProperty, value); }

        public SideBarItemView()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private static void OnSelectionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SideBarItemView)bindable;
            control.Indicator.IsVisible = (bool)newValue;
        }
        
        private static void OnExpansionChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SideBarItemView)bindable;
            control.SectionName.IsVisible = (bool)newValue;
        }
    }
}
