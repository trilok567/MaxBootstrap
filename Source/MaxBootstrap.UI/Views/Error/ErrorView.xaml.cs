﻿namespace MaxBootstrap.UI.Views.Error
{
    using System.Windows.Controls;
    using Core.View;

    /// <summary>
    /// Interaction logic for ErrorView.xaml
    /// </summary>
    public partial class ErrorView : UserControl, IView
    {
        public ErrorView()
        {
            this.InitializeComponent();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return (IViewmodel)this.DataContext;
            }

            set
            {
                this.DataContext = value;
            }
        }
    }
}
