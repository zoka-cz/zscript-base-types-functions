using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return random number</summary>
	public class Random : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "RANDOM";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 2)
				throw new ArgumentException($"{Name} function expects 2 arguments (min and max values).");

			var min_arg = (int)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);
			var max_arg = (int)_arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider);

			var rnd_number = new System.Random().Next(min_arg, max_arg);

			return rnd_number;
		}
	}
}
