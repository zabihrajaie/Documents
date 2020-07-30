using System.Collections.Generic;

namespace Entities.DocumentType
{
    public sealed partial class Domains
    {
        public Domains()
        {
            DomainScope = new HashSet<DomainScope>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DomainScope> DomainScope { get; set; }
    }
}
