using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmartAss {
	public partial static class SmartAss {
		public static T AssertInstanceOfType<T>(this object o,string message=null) {

			Assert.IsInstanceOfType(o, typeof(T), message);

			return (T)o;
		}
		public static IEnumerable<T> AssertNotAny<T>(this IEnumerable<T> list,Func<T,bool> predicate, string message=null) {
			Assert.IsFalse(list.Any(predicate), message);
			return list;
		}
		public static IEnumerable<T> AssertAny<T>(this IEnumerable<T> list, Func<T, bool> predicate, string message = null) {
			if (predicate == null) {
				predicate = e => true;
			}
			Assert.IsNotNull(list, message);
			Assert.IsTrue(list.Any(predicate), message);
			return list;
		}
		public static IEnumerable<T> AssertUnique<T>(this IEnumerable<T> list,string message = null) {

			Assert.IsFalse(list.GroupBy(e => e).Any(e => e.Count() > 1),message);

			return list;
		}
		public static T AssertNotNull<T>(this T item, string message = null) where T:class {
			Assert.IsNotNull(item, message);
			return item;
		}
		public static T AssertNotNull<T>(this Nullable<T> item, string message = null) where T:struct {
			Assert.IsTrue(item.HasValue, message);
			return item.Value;
		}
	}
}