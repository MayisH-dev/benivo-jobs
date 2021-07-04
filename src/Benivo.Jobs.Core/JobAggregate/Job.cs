using Ardalis.GuardClauses;
using Benivo.Jobs.Core.CompanyAggregate;
using Benivo.Jobs.SharedKernel;
using Benivo.Jobs.SharedKernel.Interfaces;

namespace Benivo.Jobs.Core.JobAggregate
{
    public sealed class Job : BaseEntity, IAggregateRoot
    {
        private string _title;

        private string _description;

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

        public Bookmark? Bookmark { get; private set; }

        public bool IsBookmarked => Bookmark is not null;

        public void AddBookmark(Bookmark bookmark)
        {
            bookmark = Guard.Against.Null(bookmark, nameof(bookmark));
            bookmark.Job = this;
            Bookmark = bookmark;
        }

        public JobLocation JobLocation { get; set; }

        public Category Category { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public Company Company { get; set; }
    }
}
