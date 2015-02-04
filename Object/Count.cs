using Newtonsoft.Json;

namespace RecoTwAPI
{
	public class Count
	{
		[JsonProperty("count")]
		public int count { get; set; }
	}
}
