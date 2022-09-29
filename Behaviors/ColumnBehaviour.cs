

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

using DraggableControlsDemo.Models;
using DraggableControlsDemo.ViewModels;
using DraggableControlsDemo.Views.Controls;

namespace DraggableControlsDemo.Behaviors
{


    public class ControlBehaviour : Behavior<Grid>
    {
        private Grid? _parentColumnControl;

        protected override void OnAttached()
        {
            base.OnAttached();
            _parentColumnControl = AssociatedObject as Grid;
            if (_parentColumnControl is null)
                return;

            foreach (var obj in _parentColumnControl.Children)
            {

                if (obj is IssueItemControl materialCard && materialCard.Name == "CardItem")
                {
                    materialCard.MouseLeftButtonDown += (s, e) =>
                    {
                        if (s is IssueItemControl card)
                        {
                            DataObject data = new DataObject(card.DataContext);
                            DragDrop.DoDragDrop(card, data, DragDropEffects.Move);
                        }
                    };
                }
                var kanBanColumn = obj as KanbanColumnEditorControl;

                if (kanBanColumn is null)
                    continue;

                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.Created);
                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.Opened);
                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.WaitingAssignment);
                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.InProgress);
                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.Review);
                UpdateIssueAndAddToColumnAsync(kanBanColumn, IssueStatus.Closed);
            }
        }

        private void UpdateIssueAndAddToColumnAsync(KanbanColumnEditorControl kanBanColumn, IssueStatus status)
        {
            if (kanBanColumn is not null && kanBanColumn.Name == $"{status}")
            {
                kanBanColumn.Drop += (s, e) =>
                {
                    var vModel = kanBanColumn.DataContext as MainWindowViewModel;
                    var issue = e.Data.GetData(typeof(IssueModel)) as IssueModel;
                    if (issue is not null && vModel is not null)
                        vModel.UpdateStatusAsync(issue, status);
                };
            }
        }
    }
}
