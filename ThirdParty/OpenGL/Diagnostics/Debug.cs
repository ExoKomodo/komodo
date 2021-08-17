#region Using statements
using System;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
#endregion

namespace OpenGLBindings.Diagnostics
{
	/// <summary>
	/// Helper class for detailed debugging.
	/// </summary>
	internal static class Debug
	{
		#region Methods
		[Conditional( "DEBUG" )]
		public static void Log( string message, ConsoleColor color = ConsoleColor.White, int frame = 1 )
		{
			StackTrace stack = new StackTrace();
			MethodBase method = stack.GetFrame( frame ).GetMethod();

			Console.ForegroundColor = color;
			Console.WriteLine( string.Format( "{0}::{1}@{2}\t>> {3}", method.DeclaringType.Name, method.Name, Thread.CurrentThread.ManagedThreadId, message ) );
		}

		[Conditional( "DEBUG" )]
		public static void Warn( string message )
		{
			Log( message, ConsoleColor.Yellow, 2 );
		}

		[Conditional( "DEBUG" )]
		public static void Error( string message )
		{
			Log( message, ConsoleColor.Red, 2 );
			Thread.Sleep( 1000 );
		}
		#endregion
	}
}