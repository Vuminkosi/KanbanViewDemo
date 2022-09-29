using DraggableControlsDemo.Models;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraggableControlsDemo.ViewModels
{
    public class MainWindowViewModel : NotifyModel
    {

        public MainWindowViewModel()
        {
            _issues = new ObservableCollection<IssueModel>()
            {
                new IssueModel() {
                    About = "Information Capturing",
                    Description = "Information Capturing",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.Created,
                    IssueNo = 1,
                    DateCreated = DateTime.Now,
                    StatusChangedDate = DateTime.Now,
                },
                 new IssueModel() {
                    About = "Add Lead Management service",
                    Description = "Information Capturing",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.Review,
                    IssueNo = 2,
                    DateCreated = DateTime.Now,
                    StatusChangedDate = DateTime.Now,
                },
                  new IssueModel() {
                    About = "Release the lead service to production",
                    Description = "Information Capturing",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.Review,
                    IssueNo = 231,
                    DateCreated = DateTime.Now,
                    StatusChangedDate = DateTime.Now,
                },
                new IssueModel() {
                    About = "Wiring of Properties and Schedule Board",
                    Description = "Wiring of Properties and Schedule Board",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.InProgress,
                    IssueNo = 456,
                    DateCreated = DateTime.Now.AddDays(2),
                    StatusChangedDate = DateTime.Now.AddDays(2),
                },

                 new IssueModel() {
                    About = "Add Optional Contact Details",
                    Description = "Wiring of Properties and Schedule Board",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.InProgress,
                    IssueNo = 890,
                    DateCreated = DateTime.Now.AddDays(-1),
                    StatusChangedDate = DateTime.Now.AddDays(-1),
                },

                 new IssueModel() {
                    About = "Manage Client Opportunities",
                    Description = "Wiring of Properties and Schedule Board",
                    Owner = "Vuminkosi Vincent Matibe",
                    Status = IssueStatus.InProgress,
                    IssueNo = 345,
                    DateCreated = DateTime.Now.AddDays(11),
                    StatusChangedDate = DateTime.Now.AddDays(1),
                },
            };

        }
        private ObservableCollection<IssueModel> _issues;

        public ObservableCollection<IssueModel> Issues
        {
            get => _issues;
            set => SetProperty(ref _issues, value, nameof(Issues));
        }




        public void UpdateStatusAsync(IssueModel model, IssueStatus status)
        {
            model.Status = status;
            model.StatusChangedDate = DateTime.Now;
            model.IsClosed = status == IssueStatus.Closed;
            if (status == IssueStatus.Closed)
                model.ClosedCreated = DateTime.Now;

            //var issuesStore = new ObservableCollection<IssueModel>(Issues);

            //Issues = new ObservableCollection<IssueModel>(issuesStore.OrderByDescending(x => x.StatusChangedDate));
            //Notify UI
            OnPropertyChanged(nameof(Issues));

            // call the server/api for persistence
        }


    }
}
