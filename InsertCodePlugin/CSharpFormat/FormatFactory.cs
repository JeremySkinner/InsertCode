using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertCodePlugin.CSharpFormat
{
	public static class FormatFactory
	{
		private static readonly Dictionary<string, SourceFormat> formatters;

		static FormatFactory()
		{
			var formatters = from type in typeof(FormatFactory).Assembly.GetExportedTypes()
							 where typeof(SourceFormat).IsAssignableFrom(type)
							 where !type.IsAbstract
							 let instance = (SourceFormat)Activator.CreateInstance(type)
							 select new { instance.Name, Instance = instance };


			FormatFactory.formatters = formatters.ToDictionary(x => x.Name, x => x.Instance);
			
		}

		public static IEnumerable<SourceFormat> GetFormats()
		{
			return formatters.OrderBy(x => x.Key).Select(x => x.Value).ToList();
		}

		public static SourceFormat GetFormat(string name)
		{
			SourceFormat formatter = null;
			formatters.TryGetValue(name, out formatter);
			return formatter;
		}
	}
}