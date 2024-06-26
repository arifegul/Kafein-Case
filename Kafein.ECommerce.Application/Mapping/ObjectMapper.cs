﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Mapping
{
	public class ObjectMapper
	{
		private static readonly Lazy<IMapper> lazy = new(() =>
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<KafeinECommerceAutoMapperProfile>();
			});
			return config.CreateMapper();
		});
		public static IMapper Mapper => lazy.Value;
	}
}
