using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will format string as per string.Format function</summary>
	public class StrFormat : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "STR_FORMAT";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count < 1)
				throw new ArgumentException($"{Name} function expects at least 1 arguments (string with format), and optionally other arguments to be replaced in string (using {{X}} notation, where X is zero based parameter position.");

			var str_format = _arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider).ToString();
			var args = new List<object>();
			for (int i = 1; i < _arguments.Count; i++)
				args.Add(_arguments[i].EvaluateExpressionToValue(_data_storages, _service_provider));
			var result = string.Format(str_format ?? throw new InvalidOperationException("String format cannot be null"), args.ToArray());

			return result;
		}
	}
}
