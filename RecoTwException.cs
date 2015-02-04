using System;

namespace RecoTwAPI
{
	[Serializable]
	public class RecoTwException : Exception
	{
		public RecoTwException(ErrorCollection errors)
		{
			this.Errors = errors;
		}

		public ErrorCollection Errors { get; set; }
	}
}
