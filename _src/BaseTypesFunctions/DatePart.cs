using System;
using System.Collections.Generic;

namespace Zoka.ZScript.BaseTypesFunctions
{
	/// <summary>Will return the date time part of passed DT</summary>
	public class DatePart : IZScriptFunction
	{
		/// <summary>Enumeration of part to retrieve</summary>
		public enum EDatePartType
		{
			/// <summary>Year</summary>
			Year,
			/// <summary>Month</summary>
			Month,
			/// <summary>Day</summary>
			Day,
			/// <summary>DayOfWeek</summary>
			DayOfWeek,
			/// <summary>Hour</summary>
			Hour,
			/// <summary>Minute</summary>
			Minute,
			/// <summary>Second</summary>
			Second
		}

		/// <summary>Name of the function</summary>
		public const string									NAME = "DATE_PART";

		/// <inheritdoc />
		public string										Name => NAME;

		/// <inheritdoc />
		public object										EvaluateFunctionToValue(List<IZScriptExpression> _arguments, DataStorages _data_storages, IServiceProvider _service_provider)
		{
			if (_arguments.Count != 2)
				throw new ArgumentException($"{Name} function expects 2 arguments (1st is datetime, 2nd is the unit to be retrieved (Year, Month, Day, DayOfWeek, Hour, Minute, Second))");

			var dt = (DateTime)_arguments[0].EvaluateExpressionToValue(_data_storages, _service_provider);
			var addition_type = (EDatePartType)Enum.Parse(typeof(EDatePartType), (string)_arguments[1].EvaluateExpressionToValue(_data_storages, _service_provider));

			switch (addition_type)
			{
				case EDatePartType.Year:
					return dt.Year;
				case EDatePartType.Month:
					return dt.Month;
				case EDatePartType.Day:
					return dt.Day;
				case EDatePartType.DayOfWeek:
					return (int)dt.DayOfWeek;
				case EDatePartType.Hour:
					return dt.Hour;
				case EDatePartType.Minute:
					return dt.Minute;
				case EDatePartType.Second:
					return dt.Second;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
