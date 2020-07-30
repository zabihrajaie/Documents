namespace Entities.DocumentType
{
    public class DomainScope
    {
        public int DomainsId { get; set; }
        public int ScopesId { get; set; }

        public virtual Domains Domains { get; set; }
        public virtual Scopes Scopes { get; set; }
    }
}
