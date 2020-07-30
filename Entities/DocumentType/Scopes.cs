using System.Collections.Generic;

namespace Entities.DocumentType
{
    public sealed class Scopes
    {
        public Scopes()
        {
            DocumentTypes = new HashSet<DocumentTypes>();
            DomainScope = new HashSet<DomainScope>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DocumentTypes> DocumentTypes { get; set; }
        public ICollection<DomainScope> DomainScope { get; set; }
    }
}
