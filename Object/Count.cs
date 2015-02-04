using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecoTwAPI
{
	public class Count
	{
		[JsonProperty("count")]
		public int count { get; set; }
	}
}
