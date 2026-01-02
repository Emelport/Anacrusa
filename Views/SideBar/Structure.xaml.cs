using Microsoft.Maui.Controls;
using Anacrusa.Views.Library;

namespace Anacrusa.Views.SideBar
{
    public partial class SideBarPage : ContentPage
    {
        bool _isCollapsed = true;
        const double CollapsedWidth = 48;
        const double ExpandedWidth = 220;
        const uint AnimationLength = 200;

        public SideBarPage()
        {
            InitializeComponent();

            LoadDetail(new LibraryView());
            SelectLibrary();
            ApplyCollapseState(animated: false);

            SizeChanged += SideBarPage_SizeChanged;
        }

        void SideBarPage_SizeChanged(object? sender, EventArgs e)
        {
            if (Width >= 900 && _isCollapsed)
            {
                _isCollapsed = false;
                ApplyCollapseState();
            }
            else if (Width < 900 && !_isCollapsed)
            {
                _isCollapsed = true;
                ApplyCollapseState();
            }
        }

        void ApplyCollapseState(bool animated = true)
        {
            double from = SidebarColumn.Width.Value;
            double to = _isCollapsed ? CollapsedWidth : ExpandedWidth;

            if (animated)
            {
                var animation = new Animation(v => SidebarColumn.Width = new GridLength(v), from, to);
                animation.Commit(this, "SideBarWidth", length: AnimationLength, easing: Easing.SinInOut);
            }
            else
            {
                SidebarColumn.Width = new GridLength(to);
            }

            bool expanded = !_isCollapsed;

            LibItem.IsExpanded = expanded;
            SetlistsItem.IsExpanded = expanded;
            SettingsItem.IsExpanded = expanded;
        }

        void ClearSelection()
        {
            LibItem.IsSelected = false;
            SetlistsItem.IsSelected = false;
            SettingsItem.IsSelected = false;
        }

        void SelectLibrary()
        {
            ClearSelection();
            LibItem.IsSelected = true;
            LoadDetail(new LibraryView());
        }

        void SelectSetlists()
        {
            ClearSelection();
            SetlistsItem.IsSelected = true;
            LoadDetail(new SetlistView());
        }

        void SelectSettings()
        {
            ClearSelection();
            SettingsItem.IsSelected = true;
            LoadDetail(new SettingsView());
        }

        void OnLibraryClicked(object sender, EventArgs e) => SelectLibrary();
        void OnSetlistsClicked(object sender, EventArgs e) => SelectSetlists();
        void OnSettingsClicked(object sender, EventArgs e) => SelectSettings();

        void LoadDetail(View view) => DetailContainer.Content = view;
        void OnToggleClicked(object sender, EventArgs e)
        {
            _isCollapsed = !_isCollapsed;
            ApplyCollapseState();
        }
    }
}
