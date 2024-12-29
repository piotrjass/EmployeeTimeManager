using System.Text.Json.Serialization;

namespace HalfbitZadanie.Models
{
    public class TimeEntry
    {
        [JsonIgnore]
        public int Id { get; set; } 
        [JsonIgnore]
        public int EmployeeId { get; set; } 
        public DateTime Date { get; set; } 
        public int HoursWorked { get; set; } 
    }
}