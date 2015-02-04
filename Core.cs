using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RecoTwAPI
{
	internal class Core
	{
		private static string Url = "http://api.recotw.black/1/";

		public static T ApiGet<T>(string endpoint)
		{
			return ApiGet<T>(endpoint, null);
		}

		public static T ApiGet<T>(string endpoint, params Expression<Func<string, object>>[] parameters)
		{
			return GetResponse<T>(CreateRequest(endpoint, parameters));
		}

		public static T ApiPost<T>(string endpoint, string postData, params Expression<Func<string, object>>[] parameters)
		{
			var req = CreateRequest(endpoint, parameters);
			req.Method = "POST";
			req.ContentType = "application/x-www-form-urlencoded";

			if (postData != null)
			{
				var data = Encoding.UTF8.GetBytes(postData);
				req.ContentLength = data.Length;

				using (var str = req.GetRequestStream())
					str.Write(data, 0, data.Length);
			}

			return GetResponse<T>(req);
		}


		private static HttpWebRequest CreateRequest(string endpoint, params Expression<Func<string, object>>[] parameters)
		{
			string parameter = "";
			if (parameters != null)
			{
				parameter = string.Join("&", parameters
					.Select(param =>
					{
						var exp = param.Compile();
						var name = param.Parameters[0].Name;
						return string.Format("{0}={1}", name, exp(name));
					}));
				if (!string.IsNullOrEmpty(parameter))
					parameter = "?" + parameter;
			}

			return HttpWebRequest.Create(Url + endpoint + parameter) as HttpWebRequest;
		}

		private static T GetResponse<T>(HttpWebRequest req)
		{
			try
			{
				using (var sr = new StreamReader(req.GetResponse().GetResponseStream()))
					return JsonConvert.DeserializeObject<T>(sr.ReadToEnd());
			}
			catch (WebException wex)
			{
				if (wex.Response != null &&
					wex.Status == WebExceptionStatus.ProtocolError)
				{
					using (var sr = new StreamReader(wex.Response.GetResponseStream()))
					{
						var json = sr.ReadToEnd();
						if (json.Contains("\"errors\""))
						{
							throw new RecoTwException(
								JsonConvert.DeserializeObject<ErrorCollection>(
								JObject.Parse(json).SelectToken("errors").ToString()));
						}
						else throw;
					}
				}
				else throw;
			}
		}
	}
}
