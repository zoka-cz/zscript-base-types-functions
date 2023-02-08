using System;
using System.Collections.Generic;
using System.Text;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will join multiple strings</summary>
	public class StrJoin : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "STR_JOIN";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count < 2)
				throw new ArgumentException($"{Name} function expects at least 2 string arguments to be joined");

			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < _arguments.Count; i++)
			{
				sb.Append(_arguments[i].EvaluateExpressionToValue(_data_storages, _service_provider));
			}

			return sb.ToString();
		}
	}
}
