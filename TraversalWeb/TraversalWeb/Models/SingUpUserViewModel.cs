using System.ComponentModel.DataAnnotations;

namespace TraversalWeb.Models
{
	public class SingUpUserViewModel
	{
        [Required(ErrorMessage ="Lütfen isminizi giriniz")]
        public string name { get; set; }
		[Required(ErrorMessage = "Lütfen soyadınızı giriniz")]
		public string surname { get; set; }
		[Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
		public string username { get; set; }
		[Required(ErrorMessage = "Lütfen cinsiyetinizi giriniz")]
		public string gender { get; set; }
		[Required(ErrorMessage = "Lütfen fotoğraf url giriniz")]
		public string imageUrl { get; set; }
		[Required(ErrorMessage = "Lütfen isminizi giriniz")]

		public string password { get; set; }
        [Compare("password")]
        public string confirmPassowrd { get; set; }

		[Required(ErrorMessage = "Lütfen mail giriniz")]
		public string Mail { get; set; }
	}
}
