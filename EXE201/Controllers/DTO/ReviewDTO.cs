using System;

namespace EXE201.Controllers.DTO
{
    public class ReviewDTO
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long PackageId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
    }
}
