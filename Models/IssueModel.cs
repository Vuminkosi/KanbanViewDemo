using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing.Interop;
using System.Text;
using System.Threading.Tasks;

namespace DraggableControlsDemo.Models
{
    public class IssueModel : NotifyModel
    {
        private string? about;
        private string? _owner;
        private IssueStatus status;
        private DateTime dateCreated = DateTime.Now;
        private DateTime closedCreated = DateTime.Now;
        private bool isClosed;
        private DateTime statusChangedDate = DateTime.Now;
        private int issueNo;
        private string? description;

        public string? Description { get => description; set => SetProperty(ref description, value); }
        public int IssueNo { get => issueNo; set => SetProperty(ref issueNo, value); }
        public string? About { get => about; set => SetProperty(ref about, value); }
        public string? Owner { get => _owner; set => SetProperty(ref _owner, value); }
        public IssueStatus Status { get => status; set => SetProperty(ref status, value); }
        public DateTime DateCreated { get => dateCreated; set => SetProperty(ref dateCreated, value); }
        public DateTime ClosedCreated { get => closedCreated; set => SetProperty(ref closedCreated, value); }
        public bool IsClosed { get => isClosed; set => SetProperty(ref isClosed, value); }
        public DateTime StatusChangedDate { get => statusChangedDate; set => SetProperty(ref statusChangedDate, value); }
    }
}
