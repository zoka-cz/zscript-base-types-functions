using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will compare two strings</summary>
	public class CompareStrings : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "COMPARE_STRINGS";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 2)
				throw new ArgumentException($"{Name} function expects 2 arguments (1/ left side of comparison, 2/ right side of comparison) and returns int result of string.Compare function");

			var left_side = (string)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);
			var right_side = (string)_arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider);

			return string.Compare(left_side, right_side);
		}
	}
}
