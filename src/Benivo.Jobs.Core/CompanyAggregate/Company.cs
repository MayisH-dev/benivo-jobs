using Ardalis.GuardClauses;
using Benivo.Jobs.SharedKernel;
using Benivo.Jobs.SharedKernel.Interfaces;

namespace Benivo.Jobs.Core.CompanyAggregate
{
    public sealed class Company : BaseEntity, IAggregateRoot
    {
        public Company(string title, byte[] logo)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Logo = Guard.Against.Null(logo, nameof(logo));
        }

        public string Title { get; private set; }

        /// <summary>
        /// Logo image
        /// </summary>
        public byte[] Logo { get; private set; }
    }
}
