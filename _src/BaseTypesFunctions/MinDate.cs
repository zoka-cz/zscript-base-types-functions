using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return DateTime.MinDate</summary>
	public class MinDate : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "MIN_DATE";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 0)
				throw new ArgumentException($"{Name} function expects no arguments.");

			return DateTime.MinValue;
		}
	}
}
