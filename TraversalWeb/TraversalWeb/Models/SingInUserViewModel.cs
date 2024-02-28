using System.ComponentModel.DataAnnotations;

namespace TraversalWeb.Models
{
	public class SingInUserViewModel
	{
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string userName { get; set; }
		[Required(ErrorMessage = "Lütfen şifrenizi  giriniz")]
		public string password { get; set; }
    }
}
