#region Copyright (c) 2003, James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole, Philip A. Craig
/************************************************************************************
'
' Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' Copyright  2000-2002 Philip A. Craig
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright  2002-2003 James W. Newkirk, Michael C. Two, Alexei A. Vorontsov, Charlie Poole
' or Copyright  2000-2002 Philip A. Craig
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

namespace NUnit.Tests.CommandLine
{
	using System;
	using NUnit.Framework;
	using NUnit.Util;
	using Codeblast;

	[TestFixture]
	public class GuiFixture
	{
		[Test]
		public void NoParametersCount()
		{
			GuiOptions options = new GuiOptions(new string[] {});
			Assert.True(options.NoArgs);
		}

		[Test]
		public void Help()
		{
			GuiOptions options = new GuiOptions(new string[] {"/help"});
			Assert.True(options.help);
		}

		[Test]
		public void ShortHelp()
		{
			GuiOptions options = new GuiOptions(new string[] {"/?"});
			Assert.True(options.help);
		}

		[Test]
		public void AssemblyName()
		{
			string assemblyName = "nunit.tests.dll";
			GuiOptions options = new GuiOptions(new string[]{ assemblyName });
			Assert.Equals(assemblyName, options.Assembly);
		}

		[Test]
		public void ValidateSuccessful()
		{
			GuiOptions options = new GuiOptions(new string[] { "nunit.tests.dll" });
			Assert.True(options.Validate(), "command line should be valid");
		}

		[Test]
		public void InvalidArgs()
		{
			GuiOptions options = new GuiOptions(new string[] { "/asembly:nunit.tests.dll" });
			Assert.False(options.Validate());
		}


		[Test] 
		public void InvalidCommandLineParms()
		{
			GuiOptions parser = new GuiOptions(new String[]{"/garbage:TestFixture", "/assembly:Tests.dll"});
			Assert.False(parser.Validate());
		}

		[Test] 
		public void NoNameValuePairs()
		{
			GuiOptions parser = new GuiOptions(new String[]{"TestFixture", "Tests.dll"});
			Assert.False(parser.Validate());
		}
	}
}

