namespace Entities.DocumentType
{
    public class IsAs
    {
        public int Id { get; set; }
        public long SuperDocumentTypeId { get; set; }
        public long SubDocumentTypeId { get; set; }
        public long SubDocumentTypeId1 { get; set; }

        public virtual DocumentTypes SubDocumentTypeId1Navigation { get; set; }
        public virtual DocumentTypes SuperDocumentType { get; set; }
    }
}
