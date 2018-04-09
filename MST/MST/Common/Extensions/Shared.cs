using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MST
{
	/// <summary>
	/// This class contains extensions for all objects.
	/// </summary>
	public static class Shared
	{
		#region methods

		/// <summary>
		/// Gets the deep clone of the given object.
		/// </summary>
		/// <returns>The deep clone.</returns>
		/// <param name="obj">Object.</param>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public static T DeepClone<T>(this T obj)
		{
			using (MemoryStream stream = new MemoryStream ())
			{
				BinaryFormatter formatter = new BinaryFormatter ();
				formatter.Serialize (stream, obj);
				stream.Position = 0;
				return (T)formatter.Deserialize (stream);
			}
		}

		#endregion
	}
}
