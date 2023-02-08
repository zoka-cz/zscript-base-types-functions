using System;
using System.Collections.Generic;
using System.Data;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return the rows count in the datatable</summary>
	public class GetTableRowsCount : IZScriptFunction
	{
		/// <summary>Function name</summary>
		public const string									NAME = "GET_TABLE_ROWS_COUNT";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 1)
				throw new ArgumentException($"{Name} function expects 1 arguments (DataTable to retrieve row count)");

			var table = _arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider) as DataTable;
			if (table == null)
				throw new Exception($"{_arguments[0].OriginalExpression} has not evaluated into DataTable");
			return table.Rows.Count;
		}
	}
}
