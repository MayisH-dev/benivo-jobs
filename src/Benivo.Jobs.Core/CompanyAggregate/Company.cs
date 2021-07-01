using Benivo.Jobs.SharedKernel;
using Benivo.Jobs.SharedKernel.Interfaces;
using System;

namespace Benivo.Jobs.Core.CompanyAggregate
{
    public sealed class Company : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; } = string.Empty;
        /// <summary>
        /// Logo image
        /// </summary>
        public byte[] Logo { get; set; } = Array.Empty<byte>();
    }
}
