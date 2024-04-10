using AutoMapper;
using Kafein.ECommerce.Application.Responses;
using Kafein.ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Application.Mapping
{
	public class KafeinECommerceAutoMapperProfile : Profile
	{
		public KafeinECommerceAutoMapperProfile() 
		{
            CreateMap<Product, ProductResponse>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<Order, OrderResponse>().ReverseMap();
		}
	}
}
