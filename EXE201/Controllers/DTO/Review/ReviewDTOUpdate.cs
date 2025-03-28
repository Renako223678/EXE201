using System.Text.Json.Serialization;

namespace EXE201.Controllers.DTO.Review
{
    public class ReviewDTOUpdate
    {
        public int Rating { get; set; }
        public string Comment { get; set; }

        [JsonIgnore] // Bỏ qua khi serialize JSON
        public DateOnly CreateDate { get; set; }

        [JsonPropertyName("CreateDate")] // Ghi đè JSON để giữ tên cũ
        public DateTime CreateDateTime => CreateDate.ToDateTime(TimeOnly.MinValue);
    }
}
