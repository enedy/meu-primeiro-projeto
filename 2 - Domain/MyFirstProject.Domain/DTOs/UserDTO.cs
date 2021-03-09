using MyFirstProject.Domain.Enums;

namespace MyFirstProject.Domain.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string DocumentNumber { get; set; }
        public EDocumentType DocumentType { get; set; }
        public bool Status { get; set; }
    }
}