using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will register the base types functions</summary>
	public static class BaseTypesFunctionsExtensions
	{
		/// <summary>Will configure all the functions to be usable by ZScript parser</summary>
		public static IServiceProvider						ConfigureBaseTypesFunctions(this IServiceProvider _service_provider)
		{
			var script_factory = _service_provider.GetService<ZScriptFunctionFactory>();

			script_factory?.RegisterScriptFunctionType(CompareDates.NAME, typeof(CompareDates));
			script_factory?.RegisterScriptFunctionType(CompareInts.NAME, typeof(CompareInts));
			script_factory?.RegisterScriptFunctionType(CompareStrings.NAME, typeof(CompareStrings));
			script_factory?.RegisterScriptFunctionType(DateAdd.NAME, typeof(DateAdd));
			script_factory?.RegisterScriptFunctionType(DatePart.NAME, typeof(DatePart));
			script_factory?.RegisterScriptFunctionType(GetDate.NAME, typeof(GetDate));
			script_factory?.RegisterScriptFunctionType(GetTableRowsCount.NAME, typeof(GetTableRowsCount));
			script_factory?.RegisterScriptFunctionType(MaxDate.NAME, typeof(MaxDate));
			script_factory?.RegisterScriptFunctionType(MinDate.NAME, typeof(MinDate));
			script_factory?.RegisterScriptFunctionType(MinOfDates.NAME, typeof(MinOfDates));
			script_factory?.RegisterScriptFunctionType(Random.NAME, typeof(Random));
			script_factory?.RegisterScriptFunctionType(StrFormat.NAME, typeof(StrFormat));
			script_factory?.RegisterScriptFunctionType(StrJoin.NAME, typeof(StrJoin));
			script_factory?.RegisterScriptFunctionType(ToDatetime.NAME, typeof(ToDatetime));
			script_factory?.RegisterScriptFunctionType(ToInt.NAME, typeof(ToInt));
			script_factory?.RegisterScriptFunctionType(ToLong.NAME, typeof(ToLong));
			script_factory?.RegisterScriptFunctionType(ToShort.NAME, typeof(ToShort));
			script_factory?.RegisterScriptFunctionType(BaseTypesFunctions.ToString.NAME, typeof(BaseTypesFunctions.ToString));

			return _service_provider;
		}
	}
}
