using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return the current date</summary>
	public class GetDate : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "GETDATE";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 0)
				throw new ArgumentException($"{Name} function expects no arguments.");

			return DateTime.Today;
		}
	}
}
