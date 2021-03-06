﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GladNet.ASP.Client.RestSharp.Middleware.Authentication
{
	/// <summary>
	/// JWT Token model.
	/// </summary>
	[JsonObject]
	public class JWTModel
	{
		/// <summary>
		/// JWT access token if authentication was successful.
		/// </summary>
		[JsonProperty(PropertyName = "access_token", Required = Required.Default)] //optional because could be an error
		public string AccessToken { get; private set; }

		/// <summary>
		/// Error type if an error was encountered.
		/// </summary>
		[JsonProperty(PropertyName = "error", Required = Required.Default)] //optional because could be a valid token
		public string Error { get; private set; }

		/// <summary>
		/// Humanreadable read description.
		/// </summary>
		[JsonProperty(PropertyName = "error_description", Required = Required.Default)] //optional because could be a valid token
		public string ErrorDescription { get; private set; }

		private Lazy<bool> _isTokenValid { get; }

		/// <summary>
		/// Indicates if the model contains a valid <see cref="AccessToken"/>.
		/// </summary>
		public bool isTokenValid => _isTokenValid.Value;

		public JWTModel()
		{
			_isTokenValid = new Lazy<bool>(CheckIfTokenIsValid, true);
		}

		private bool CheckIfTokenIsValid()
		{
			return !String.IsNullOrEmpty(AccessToken) && String.IsNullOrEmpty(Error) && String.IsNullOrEmpty(ErrorDescription);;
		}
	}
}
