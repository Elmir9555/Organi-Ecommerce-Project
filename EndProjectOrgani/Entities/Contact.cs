using System;
namespace EndProjectOrgani.Entities
{
    public class Contact:BaseEntity
    {
        public string Email { get; set; }
        public string Adress { get; set; }
        public string OpenTime { get; set; }
        public string Phone { get; set; }
    }
}
