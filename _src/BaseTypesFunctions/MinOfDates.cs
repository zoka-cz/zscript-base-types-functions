using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return minimal of passed dates</summary>
	public class MinOfDates : IZScriptFunction
	{
		/// <summary>Name of the function</summary>
		public const string									NAME = "MIN_OF_DATES";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count < 2)
				throw new ArgumentException($"{Name} function expects at least 3 arguments (datetimes to select minimal of them)");

			var dates = new List<DateTime>();

			foreach (var argument in _arguments)
			{
				var dt = (DateTime)argument.EvaluateExpressionToValue(_data_storages, _service_provider);
				dates.Add(dt);
			}

			return dates.Min();
		}
	}
}
