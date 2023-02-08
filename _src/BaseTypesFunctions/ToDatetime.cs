using System;
using System.Collections.Generic;
using System.Globalization;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will convert expression string in sortable format into DateTime</summary>
	public class ToDatetime : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "TO_DATETIME";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 1)
				throw new ArgumentException($"{Name} function expects one argument - the string in sortable format representing the datetime to be parsed");

			var dt_str = (string)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);

			if (DateTime.TryParseExact(dt_str, "s", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dt))
				return dt;

			throw new Exception($"The argument \"{_arguments[0].OriginalExpression}\" which evaluated into \"{dt_str}\" is not valid datetime string in sortable format.");
		}
	}
}
