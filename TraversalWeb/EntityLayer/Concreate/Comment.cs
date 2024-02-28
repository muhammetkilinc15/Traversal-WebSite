using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
	public class Comment
	{
        [Key]
        public int CommentID { get; set; }
        public string? Description { get; set; }
        public string? CommentUser { get; set; }
        public DateTime CommentDate { get; set; }
        public bool Status { get; set; }
        public int DestinationID { get; set; }
        public virtual Destination Destination { get; set; }
    }
}
