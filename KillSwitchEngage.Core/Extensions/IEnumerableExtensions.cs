using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace KillSwitchEngage.Core.Extensions
{
	public static class IEnumerableExtensions
	{
		public static ObservableCollection<T> AsObservableCollection<T>(this IEnumerable<T> @this)
		{
        	var result = new ObservableCollection<T>();
			if (@this == null || @this.Count() < 1)
				return result;

			foreach (var item in @this)
			{
				result.Add(item);
			}
            return result;
        }
	}
}
