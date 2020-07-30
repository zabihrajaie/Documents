using System;

namespace Entities.DocumentType
{
    public class DocEvents
    {
        public long Id { get; set; }
        public long DocumentId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public virtual Documents Document { get; set; }
    }
}
