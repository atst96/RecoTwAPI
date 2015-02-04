# RecoTwAPI

RecoTw(<http://recotw.black/>)のAPI を勝手に.NETライブラリ化して使えるようにしたものです。  
ソースコードは汚いです。  
.NET Framework 4 以上が必要です

### 使用ライブラリ
* Newtonsoft.Json
https://github.com/JamesNK/Newtonsoft.Json

### 使い方(C#)
*名前空間: RecoTwAPI*

* 登録されている全ツイートの取得  
`Tweet.GetAllTweet();`

* 特定のアカウントのツイートの取得
`Tweet.UserTweets(id => [アカウントのID]);`
`Tweet.UserTweets(sn => [アカウントのScreenName]);`

* 登録されているツイート数の取得  
`Tweet.Count()`

* ツイートを登録する  
`Tweet.Record([ツイートのID]);`

### 例外
RecoTwからエラーが返ってきた場合は RecoTwException が発生します。  

### その他
説明わかりにくかったらスイマセンm(_ _)m