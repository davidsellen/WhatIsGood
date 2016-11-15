namespace WhatsGood.Domain.Entities
{
    public class FileInformation : EntityBase
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public uint Size { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
    }

}