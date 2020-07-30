namespace Entities.DocumentType
{
    public partial class Attributes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public long DocumentTypeId { get; set; }
        public bool AllowNull { get; set; }

        public virtual DocumentTypes DocumentType { get; set; }
    }
}
