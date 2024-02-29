using Microsoft.AspNetCore.Identity;

namespace TraversalWeb.Models
{
	public class CustomIdentityValidator:IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError()
			{
				Code= "PasswordRequiresLower",
				Description="* Şifre de en az bir tane küçük harf  içermelidir (a-z)"
			};
		}

		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError()
			{
				Code= "PasswordRequiresUpper",
				Description="* Şifre en az bir tane büyük karakter içermelidir (A-Z)"
			};
		}

		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError()
			{
				Code = "PasswordTooShort",
				Description = $"* Şifre en az {length} karakter içermelidir "
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError()
			{
				Code = "PasswordRequiresNonAlphanumeric",
				Description = "* Şifre en az bir tane özel karakter içermelidir "
			};
		}




	}
}
