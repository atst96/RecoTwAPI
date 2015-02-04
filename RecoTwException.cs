using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecoTwAPI
{
	public class RecoTwException : Exception
	{
		public RecoTwException(ErrorCollection errors)
		{
			this.Errors = errors;
		}

		public ErrorCollection Errors { get; set; }
	}
}
