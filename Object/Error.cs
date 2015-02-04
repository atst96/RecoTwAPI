using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecoTwAPI
{
	public class Error
	{
		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("code")]
		public int Code { get; set; }
	}
}
