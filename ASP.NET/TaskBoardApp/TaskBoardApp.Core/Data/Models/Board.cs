using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Core.Data.DataConstants.Board;

namespace TaskBoardApp.Core.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }
        
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}