using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extention
{
	public static class ListExtension
	{
		/// <summary>
		/// Determines whether the given IList object [is null or empty].
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if the given IList object [is null or empty]; otherwise, <c>false</c>.</returns>
		public static bool IsNullOrEmpty(this IList obj)
		{
			return obj == null || obj.Count == 0;
		}

		public static bool IsNullOrEmpty(this ArrayList arrayList)
		{
			if (arrayList == null || arrayList.Count == 0)
			{
				return true;
			}

			return false;
		}

		public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
		{
			return source
				.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value).ToList())
				.ToList();
		}

		public static List<List<T>> Split<T>(this List<T> items, int sliceSize = 30)
		{
			List<List<T>> list = new List<List<T>>();
			for (int i = 0; i < items.Count; i += sliceSize)
				list.Add(items.GetRange(i, Math.Min(sliceSize, items.Count - i)));
			return list;
		}

		public static IEnumerable<List<T>> SplitList<T>(this List<T> locations, int nSize = 30)
		{
			for (int i = 0; i < locations.Count; i += nSize)
			{
				yield return locations.GetRange(i, Math.Min(nSize, locations.Count - i));
			}
		}

		public static void Clear<T>(this ConcurrentQueue<T> queue)
		{
			T item;
			while (queue.TryDequeue(out item))
			{
				// do nothing
			}
		}

		public static bool HasValue<T>(this IEnumerable<T> lst)
		{
			return lst != null && lst.Any();
		}
	}
}
