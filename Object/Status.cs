using Newtonsoft.Json;
using System;

namespace RecoTwAPI
{
	public class Status
	{
		/// <summary>
		/// ツイート内容
		/// </summary>
		[JsonProperty("content")]
		public string Content { get; set; }


		/// <summary>
		/// 登録ID
		/// </summary>
		[JsonProperty("id")]
		public long Id { get; set; }


		[JsonProperty("record_date")]
		private string record_date { get; set; }
		/// <summary>
		/// 登録日時
		/// </summary>
		public DateTime RecordedAt
		{
			get { return DateTime.Parse(record_date); }
		}


		/// <summary>
		/// ツイートしたユーザのID
		/// </summary>
		[JsonProperty("target_id")]
		public long TargetId { get; set; }


		/// <summary>
		/// ツイートしたユーザの表示名(ScreenName)
		/// </summary>
		[JsonProperty("target_sn")]
		public string TargetScreenName { get; set; }


		/// <summary>
		/// ツイートのID
		/// </summary>
		[JsonProperty("tweet_id")]
		public long TweetId { get; set; }


		public override string ToString()
		{
			return string.Format("@{0}: {1}", TargetScreenName, Content);
		}
	}
}
