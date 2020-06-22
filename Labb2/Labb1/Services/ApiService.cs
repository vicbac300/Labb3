using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text;
using System.Net.Http;

namespace Labb1.Services
{
	public class ApiService
	{


		public const string PRODUCT_SERVICE_DOMAIN = "https://localhost:44391";
		public const string ORDER_SERVICE_DOMAIN = "https://localhost:44329";

		private readonly HttpClient client;

		public ApiService(IHttpClientFactory clientFactory)
		{
			this.client = clientFactory.CreateClient();
		}

		public void Post<T>(T item, string apiPath, string domain)
		{
			Post<T, object>(item, apiPath, domain);
		}

		public ReturnType Post<T, ReturnType>(T item, string apiPath, string domain)
		{
			var request = new HttpRequestMessage(HttpMethod.Post, domain + "/" + apiPath);

			var postJson = JsonSerializer.Serialize(item);
			request.Content = new StringContent(postJson, Encoding.UTF8, "application/json");

			var response = SendRequestAsync(request).GetAwaiter().GetResult();
			ReturnType returnedObject = default;
			if (response != null && response.Content != null)
			{
				try
				{
					returnedObject = DeserializeJson<ReturnType>(response).GetAwaiter().GetResult();
				}
				catch { }
				
			}

			return returnedObject;

		}



		public IEnumerable<T> GetAll<T>(string apiPath, string domain)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, domain + "/" + apiPath);
			var response = client.SendAsync(request).GetAwaiter().GetResult();
			return DeserializeJson<IEnumerable<T>>(response).GetAwaiter().GetResult();
		}

		public T GetOne<T>(string apiPath, string domain)
		{
			var request = new HttpRequestMessage(HttpMethod.Get, domain + "/" + apiPath);
			var response = client.SendAsync(request).GetAwaiter().GetResult();
			return DeserializeJson<T>(response).GetAwaiter().GetResult();
		}

		private async Task<T> DeserializeJson<T>(HttpResponseMessage content)
		{

			string jsonStr = await content.Content.ReadAsStringAsync();
			var result = JsonSerializer.Deserialize<T>(jsonStr, new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true
			});

			return result;
		}

		private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
		{
			return await client.SendAsync(request);
		}
	}
}
