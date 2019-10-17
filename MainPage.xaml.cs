using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Dokumentaci k šabloně položky Prázdná stránka najdete na adrese https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x405

namespace GStackPlayer
{
    /// <summary>
    /// Prázdná stránka, která se dá použít samostatně nebo v rámci objektu Frame
    /// </summary>
    public sealed partial class MainPage : Page
    {
        internal double PaneSquareFillSize { get; private set; }
        private readonly GridLength _collapsedHeight = new GridLength(1, GridUnitType.Star);
        private readonly GridLength _openHeight = new GridLength(15, GridUnitType.Star);
        private bool IsFileExplorerOpen { get; set; } = false;
        internal GridLength FileExplorerHeight { get { return this.IsFileExplorerOpen ? this._openHeight : this._collapsedHeight; } }
        internal GridLength PlayerHeight { get { return this.IsFileExplorerOpen ? this._collapsedHeight : this._openHeight; } }
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.SizeChanged += OnWindowResized;
        }

        private void OnWindowResized(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(8 * e.Size.Height / 7, 400));
            if (e.Size.Height < e.Size.Width) this.PaneSquareFillSize = e.Size.Width - e.Size.Height;
            else this.PaneSquareFillSize = 0;
            this.Bindings.Update();
        }


        private void CancelPaneClose(SplitView sender, SplitViewPaneClosingEventArgs args)
        {
            args.Cancel = true;
        }
    }
}
