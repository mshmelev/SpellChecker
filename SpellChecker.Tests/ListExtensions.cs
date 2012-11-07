using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellChecker.Tests
{
	public static class ListExtensions
	{
		public static bool ListEquals<T> (this List<T> list, List<T> list2)
		{
			if (list == null && list2 == null)
				return true;
			if (list == null || list2 == null)
				return false;
			if (list.Count != list2.Count)
				return false;

			for (int i = 0; i < list.Count; ++i)
			{
				if (!list[i].Equals (list2[i]))
					return false;
			}

			return true;
		}
	}
}
