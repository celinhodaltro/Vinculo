using Core.Domain.Entities.Base;

namespace Person.Domain.Entities
{
    public class Document : AggregateRoot
    {
        public Document() { }

        public string Name { get; set; }
        public string Extension { get; set; }
        public string GoogleDriveId { get; set; }
        public string FullName => $"{Name}.{Extension}";
    }
}
