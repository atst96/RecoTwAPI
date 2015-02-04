using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RecoTwAPI
{
    public class Tweet
    {
		/// <summary>
		/// 登録されたすべてのツイート情報を返します。
		/// </summary>
		/// <returns>StatusCollection</returns>
		public static StatusCollection GetAllTweet()
		{
			return Core.ApiGet<StatusCollection>("tweet/get_tweet_all");
		}


		/// <summary>
		/// 指定ユーザのツイートを返します。
		/// </summary>
		/// <param name="parameters">
		/// sn: SCREEN_NAME[required]
		/// id: USER_ID[required]
		/// callback: jsonp
		/// </param>
		/// <returns>StatusCollection</returns>
		public static StatusCollection UserTweets(params Expression<Func<string, object>>[] parameters)
		{
			return Core.ApiGet<StatusCollection>("tweet/user_tweet", parameters);
		}


		/// <summary>
		/// 登録されたツイート数を返します。
		/// </summary>
		/// <returns>int</returns>
		public static int Count()
		{
			return Core.ApiGet<Count>("tweet/count_tweet").count;
		}


		/// <summary>
		/// ツイートを登録します
		/// </summary>
		/// <param name="id">ツイートのID</param>
		/// <returns>Status</returns>
		public static Status Record(long id)
		{
			return Core.ApiPost<Status>("tweet/record_tweet", string.Format("id={0}", id));
		}
    }
}
