﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concreate;
using DataAccessLayer.Repository;
using EntityLayer.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
	{
		public Destination GetDestinationListByGuide(int id)
		{
			using(var c = new Context())
			{
				return c.Destinations.Include(x=>x.Guide).Where(x=>x.DestinationID==id).FirstOrDefault();
			}
		}
	}
}
