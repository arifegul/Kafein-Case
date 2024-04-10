using Flurl.Http;
using Kafein.ECommerce.Infrastructure.Dtos.Requests;
using Kafein.ECommerce.Infrastructure.Shared;
using Org.BouncyCastle.Utilities.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Kafein.ECommerce.Infrastructure.APIs
{
	public static class KafeinECommerceAPIs
	{
		static readonly string ipAddress = "localhost";

		public static async Task<T> GetUserById<T>(int id)
		{
			var response = await $"https://{ipAddress}:44351/api/User/GetUserById?id={id}".GetJsonAsync<ResponseInfra<T>>();

			return response.Data;
		}

		public static async Task<T> GetProductById<T>(int id)
		{
			var response = await $"https://{ipAddress}:44351/api/Product/GetProductById?id={id}".GetJsonAsync<ResponseInfra<T>>();

			return response.Data;
		}

		public static async Task<T> SendOrderEmail<T>(string email, string productName, int productQuantity, long unitPrice)
		{
			var response = await $"https://{ipAddress}:44351/api/Order/SendOrderEmail".PostJsonAsync(new SendOrderEmailRequest(email, productName, productQuantity, unitPrice)).ReceiveJson<ResponseInfra<T>>();

			return response.Data;
		}

		public static async Task<T> UpdateProduct<T>(int productId, int orderQuantity, int orderId)
		{
			var response = await $"https://{ipAddress}:44351/api/Product/UpdateProduct".PatchJsonAsync(new UpdateProductRequest(productId, orderQuantity, orderId)).ReceiveJson<ResponseInfra<T>>();

			return response.Data;
		}

		public static async Task<T> GetOrderById<T>(int id)
		{
			var response = await $"https://{ipAddress}:44351/api/Order/GetOrderById?id={id}".GetJsonAsync<ResponseInfra<T>>();

			return response.Data;
		}
	}
}
