using System;
using System.Collections;

namespace Cake.Compression
{
	/// <summary>
	/// Provides static methods that help a constructor or method to verify correct arguments and
	/// state.
	/// </summary>
	internal static class Precondition
	{
		#region Public Static Methods
		/// <summary>
		/// Checks whether the value is between a minimum and maximum value.
		/// </summary>
		/// <param name="value">The value to test.</param>
		/// <param name="min">The minimum value to test.</param>
		/// <param name="max">The maximum value to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentOutOfRangeException"><em>value</em> is out of
		/// range.</exception>
		public static void IsBetween(IComparable value, IComparable min, IComparable max, string paramName)
		{
			if (value.CompareTo(min) == -1 || value.CompareTo(max) == 1)
			{
				throw new ArgumentOutOfRangeException(paramName);
			}
		}

		/// <summary>
		/// Checks whether the specified object is not <strong>null</strong>.
		/// </summary>
		/// <param name="obj">The object to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentNullException"><em>obj</em> is
		/// <strong>null</strong>.</exception>
		public static void IsNotNull(object obj, string paramName)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(paramName);
			}
		}

		/// <summary>
		/// Checks whether the specified collection is not <strong>null</strong> or an empty
		/// collection.
		/// </summary>
		/// <param name="col">The collection to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentNullException"><em>col</em> is
		/// <strong>null</strong>.</exception>
		/// <exception cref="ArgumentException"><em>col</em> is <strong>empty</strong>.</exception>
		public static void IsNotNullOrEmpty(ICollection col, string paramName)
		{
			if (col == null)
			{
				throw new ArgumentNullException(paramName);
			}
			else if (col.Count == 0)
			{
				string message = "The collection cannot be empty.";
				throw new ArgumentException(message, paramName);
			}
		}

		/// <summary>
		/// Checks whether the specified string is not <strong>null</strong> or an empty string.
		/// </summary>
		/// <param name="str">The string to test.</param>
		/// <param name="paramName">The name of the parameter that caused the exception.</param>
		/// <exception cref="ArgumentNullException"><em>str</em> is
		/// <strong>null</strong>.</exception>
		/// <exception cref="ArgumentException"><em>str</em> is <strong>empty</strong>.</exception>
		public static void IsNotNullOrEmpty(string str, string paramName)
		{
			if (str == null)
			{
				throw new ArgumentNullException(paramName);
			}
			else if (string.IsNullOrEmpty(str))
			{
				string message = "The string cannot be empty.";
				throw new ArgumentException(message, paramName);
			}
		}
		#endregion
	}
}