using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will convert expression to string, with possibility to specify the format</summary>
	public class ToString : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "TO_STRING";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 1 && _arguments.Count != 2)
				throw new ArgumentException($"{Name} function expects 1 or 2 arguments. (1st is value to be converted to the string, 2nd is the format of the string conversion.)");

			var str_format = "{0";
			if (_arguments.Count == 2)
				str_format += ":" + _arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider).ToString();
			str_format += "}";


			var str_final = string.Format(str_format, _arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider));

			return str_final;
		}
	}
}
