using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will convert expression into short</summary>
	public class ToShort : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "TO_SHORT";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 1)
				throw new ArgumentException($"{Name} function expects 1 argument (string representation of number) which will be converted into int16 value.");

			var number_arg = _arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider).ToString();

			Int16 number;
			if (!Int16.TryParse(number_arg, out number))
				throw new ArgumentException($"Value {number_arg} is not valid string representing number.");

			return number;
		}
	}
}
