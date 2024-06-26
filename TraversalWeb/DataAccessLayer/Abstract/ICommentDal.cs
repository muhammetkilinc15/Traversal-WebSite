﻿using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface ICommentDal:IGenericDal<Comment>
	{
		public List<Comment> TGetListWİthDestination();
		public List<Comment> TGetListWİthDestinationAndUser(int id);
	}
}
