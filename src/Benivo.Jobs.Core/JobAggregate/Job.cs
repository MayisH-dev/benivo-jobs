using Ardalis.GuardClauses;
using Benivo.Jobs.Core.CompanyAggregate;
using Benivo.Jobs.Core.JobAggregate.Events;
using Benivo.Jobs.SharedKernel;
using Benivo.Jobs.SharedKernel.Interfaces;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Job : BaseEntity, IAggregateRoot
    {
        private string _title;

        private string _description;

        private Bookmark? _bookmark;

        public Job(
            string title,
            string description)
        {
            _title = title;
            _description = description;
        }

        public string Title
        {
            get => _title;
            set => _title = Guard.Against.NullOrEmpty(value, nameof(Title));
        }

        public string Description
        {
            get => _description;
            set => _description = Guard.Against.NullOrEmpty(value, nameof(Description));
        }

        public Bookmark? Bookmark
        {
            get => _bookmark;
            private set => _bookmark = value;
        }

        public bool IsBookmarked => _bookmark is null;

        public JobLocation JobLocation { get; private set; }

        public Category Category { get; private set; }

        public EmploymentType EmploymentType { get; private set; }

        public Company Company { get; private set; }

        public void ToggleBookmark()
        {
            if (_bookmark is null)
            {
                _bookmark = new () { Job = this };
                AddDomainEvent(new JobBookmarkedEvent(this));
            }
            else
            {
                _bookmark = null;
                ClearDomainEvents();
            }
        }
    }
}
