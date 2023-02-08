using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will add value to the datetime</summary>
	public class DateAdd : IZScriptFunction
	{
		/// <summary>Date addition type</summary>
		public enum EDateAdditionType
		{
			/// <summary>Year</summary>
			Year,
			/// <summary>Month</summary>
			Month,
			/// <summary>Day</summary>
			Day,
			/// <summary>Hour</summary>
			Hour,
			/// <summary>Minute</summary>
			Minute,
			/// <summary>Second</summary>
			Second
		}

		/// <summary>Name of the function</summary>
		public const string									NAME = "DATE_ADD";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 3)
				throw new ArgumentException($"{Name} function expects 3 arguments (1st is datetime, 2nd is the unit to be added (Year, Month, Day, Hour, Minute, Second), 3rd is value to be added)");

			var dt = (DateTime)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);
			var addition_type = (EDateAdditionType)Enum.Parse(typeof(EDateAdditionType), (string)_arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider));
			var to_add = (int)_arguments[2].EvaluateExpressionToValue(_data_storages, _service_provider);

			switch (addition_type)
			{
				case EDateAdditionType.Year:
					return dt.AddYears(to_add);
				case EDateAdditionType.Month:
					return dt.AddMonths(to_add);
				case EDateAdditionType.Day:
					return dt.AddDays(to_add);
				case EDateAdditionType.Hour:
					return dt.AddHours(to_add);
				case EDateAdditionType.Minute:
					return dt.AddMinutes(to_add);
				case EDateAdditionType.Second:
					return dt.AddSeconds(to_add);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
