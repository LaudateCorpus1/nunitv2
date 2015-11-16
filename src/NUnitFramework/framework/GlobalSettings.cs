// ****************************************************************
// Copyright 2008, Charlie Poole
// This is free software licensed under the NUnit license. You may
// obtain a copy of the license at http://nunit.org
// ****************************************************************

using System;

namespace UnityEngine.TestTools.Assertions
{
	/// <summary>
	/// GlobalSettings is a place for setting default values used
	/// by the framework in performing asserts.
	/// </summary>
	public class GlobalSettings
	{
		/// <summary>
		/// Default tolerance for floating point equality
		/// </summary>
		public static double DefaultFloatingPointTolerance = 0.0d;

		/// <summary>
		/// The assertion exception signaller.
		/// </summary>
		public static ExceptionSignaller AssertionExceptionSignaller;

		/// <summary>
		/// Initializes the <see cref="UnityEngine.TestTools.Assertions.GlobalSettings"/> class.
		/// </summary>
		static GlobalSettings()
		{
			AssertionExceptionSignaller = new DefaultAssertionExceptionSignaller();
		}
	}
}
