using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DraggableControlsDemo
{
    /// <summary>
    /// Interaction logic for KanbanColumnEditorControl.xaml
    /// </summary>
    public partial class KanbanColumnEditorControl : UserControl
    {
        public KanbanColumnEditorControl()
        {
            InitializeComponent();

        }



        public string ColumnName
        {
            get { return (string)GetValue(ColumnNameProperty); }
            set { SetValue(ColumnNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnName.  This enables animation, styling, binding, etc... 
        public static readonly DependencyProperty ColumnNameProperty =
           DependencyProperty.Register(nameof(ColumnName), typeof(string), typeof(KanbanColumnEditorControl), new UIPropertyMetadata(default(string), null, ColumnNamePropertyChanged));

        private static object ColumnNamePropertyChanged(DependencyObject d, object baseValue)
        {
            //Get current values
            var currentColumnValue = (string)baseValue;

            if (!string.IsNullOrWhiteSpace(currentColumnValue) && d is KanbanColumnEditorControl column)
            {
                // Get the header textBlock
                TextBlock currentTextBlock = column.txtColumnName;
                currentTextBlock.Text = currentColumnValue;
            }

            return baseValue;
        }
         
        public ObservableCollection<IssueModel> FilteredIssues
        {
            get { return (ObservableCollection<IssueModel>)GetValue(FilteredIssuesProperty); }
            set { SetValue(FilteredIssuesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilteredIssuesProperty =
            DependencyProperty.Register(nameof(FilteredIssues), typeof(ObservableCollection<IssueModel>), typeof(KanbanColumnEditorControl), new UIPropertyMetadata(default(string), null, FilteredIssuesPropertyChanged));

        private static object FilteredIssuesPropertyChanged(DependencyObject d, object baseValue)
        {
            //Get current values
            var items = (ObservableCollection<IssueModel>)baseValue;
            if (items is not null && d is KanbanColumnEditorControl column)
            {
                // Get the header textBlock
                ItemsControl currentItemsCollection = column.issuesCollection;
                currentItemsCollection.ItemsSource = items;
            }
            return baseValue;
        }
    }
}
