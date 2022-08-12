using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ПА_Лаб._6
{
	static class Program
	{
		static Random random = new Random();

		static void Main(string[] args)
		{
			Game.StartGame();
		}
		public static void Shuffle<T>(this IList<T> list)
		{
			int n = list.Count;
			while (n > 1)
			{
				n--;
				int k = random.Next(n + 1);
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
		public static string GetDescription(this Enum value)
		{
			return ((DescriptionAttribute)Attribute.GetCustomAttribute(
				value.GetType().GetFields(BindingFlags.Public | BindingFlags.Static)
					.Single(x => x.GetValue(null).Equals(value)),
				typeof(DescriptionAttribute)))?.Description ?? value.ToString();
		}
	}
}
