using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Function which will compare 2 int32</summary>
	public class CompareInts : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "COMPARE_INTS";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 3)
				throw new ArgumentException($"{Name} function expects 3 arguments (1/ left side of comparison, 2/ right side of comparison, 3/ string with comparison sign (C# style))");

			var left_side = (int)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);
			var right_side = (int)_arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider);
			var sign = (string)_arguments[2].EvaluateExpressionToValue(_data_storages, _service_provider);

			if (sign == "<")
				return left_side < right_side;
			else if (sign == ">")
				return left_side > right_side;
			else if (sign == "==")
				return left_side == right_side;
			else if (sign == "!=")
				return left_side != right_side;
			else
			{
				throw new Exception($"{NAME} function does not support {sign} sign.");
			}
		}
	}
}
