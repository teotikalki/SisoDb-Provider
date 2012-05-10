//
// http://code.google.com/p/servicestack/wiki/TypeSerializer
// ServiceStack.Text: .NET C# POCO Type Text Serializer.
//
// Authors:
//   Demis Bellot (demis.bellot@gmail.com)
//
// Copyright 2011 Liquidbit Ltd.
//
// Licensed under the same terms of ServiceStack: new BSD license.
//

using System;
using System.Globalization;
using System.IO;
using SisoDb.Serialization.Common;
using SisoDb.Serialization.Json;

namespace SisoDb.Serialization.Jsv
{
	internal class JsvTypeSerializer
		: ITypeSerializer
	{
		public static ITypeSerializer Instance = new JsvTypeSerializer();

		public string TypeAttrInObject { get { return "{__type:"; } }

		public WriteObjectDelegate GetWriteFn<T>()
		{
			return JsvWriter<T>.WriteFn();
		}

		public WriteObjectDelegate GetWriteFn(Type type)
		{
			return JsvWriter.GetWriteFn(type);
		}

		static readonly TypeInfo DefaultTypeInfo = new TypeInfo { EncodeMapKey = false };

		public TypeInfo GetTypeInfo(Type type)
		{
			return DefaultTypeInfo;
		}

		public void WriteRawString(TextWriter writer, string value)
		{
			writer.Write(value.ToCsvField());
		}

		public void WritePropertyName(TextWriter writer, string value)
		{
			writer.Write(value);
		}

		public void WriteBuiltIn(TextWriter writer, object value)
		{
			writer.Write(value);
		}

		public void WriteObjectString(TextWriter writer, object value)
		{
			if (value != null)
			{
				writer.Write(value.ToString().ToCsvField());
			}
		}

		public void WriteException(TextWriter writer, object value)
		{
			writer.Write(((Exception)value).Message.ToCsvField());
		}

		public void WriteString(TextWriter writer, string value)
		{
			writer.Write(value.ToCsvField());
		}

		public void WriteDateTime(TextWriter writer, object oDateTime)
		{
			writer.Write(DateTimeSerializer.ToShortestXsdDateTimeString((DateTime)oDateTime));
		}

		public void WriteNullableDateTime(TextWriter writer, object dateTime)
		{
			if (dateTime == null) return;
			writer.Write(DateTimeSerializer.ToShortestXsdDateTimeString((DateTime)dateTime));
		}

		public void WriteDateTimeOffset(TextWriter writer, object oDateTimeOffset)
		{
			writer.Write(((DateTimeOffset) oDateTimeOffset).ToString("o"));
		}

		public void WriteNullableDateTimeOffset(TextWriter writer, object dateTimeOffset)
		{
			if (dateTimeOffset == null) return;
			this.WriteDateTimeOffset(writer, dateTimeOffset);
		}

        public void WriteTimeSpan(TextWriter writer, object oTimeSpan)
        {
            writer.Write(DateTimeSerializer.ToXsdTimeSpanString((TimeSpan)oTimeSpan));
        }

        public void WriteNullableTimeSpan(TextWriter writer, object oTimeSpan)
        {
            if (oTimeSpan == null) return;
            writer.Write(DateTimeSerializer.ToXsdTimeSpanString((TimeSpan?)oTimeSpan));
        }

		public void WriteGuid(TextWriter writer, object oValue)
		{
			writer.Write(((Guid)oValue).ToString("N"));
		}

		public void WriteNullableGuid(TextWriter writer, object oValue)
		{
			if (oValue == null) return;
			writer.Write(((Guid)oValue).ToString("N"));
		}

		public void WriteBytes(TextWriter writer, object oByteValue)
		{
			if (oByteValue == null) return;
			writer.Write(Convert.ToBase64String((byte[])oByteValue));
		}

		public void WriteChar(TextWriter writer, object charValue)
		{
			if (charValue == null) return;
			writer.Write((char)charValue);
		}

		public void WriteByte(TextWriter writer, object byteValue)
		{
			if (byteValue == null) return;
			writer.Write((byte)byteValue);
		}

		public void WriteInt16(TextWriter writer, object intValue)
		{
			if (intValue == null) return;
			writer.Write((short)intValue);
		}

		public void WriteUInt16(TextWriter writer, object intValue)
		{
			if (intValue == null) return;
			writer.Write((ushort)intValue);
		}

		public void WriteInt32(TextWriter writer, object intValue)
		{
			if (intValue == null) return;
			writer.Write((int)intValue);
		}

		public void WriteUInt32(TextWriter writer, object uintValue)
		{
			if (uintValue == null) return;
			writer.Write((uint)uintValue);
		}

		public void WriteUInt64(TextWriter writer, object ulongValue)
		{
			if (ulongValue == null) return;
			writer.Write((ulong)ulongValue);
		}

		public void WriteInt64(TextWriter writer, object longValue)
		{
			if (longValue == null) return;
			writer.Write((long)longValue);
		}

		public void WriteBool(TextWriter writer, object boolValue)
		{
			if (boolValue == null) return;
			writer.Write((bool)boolValue);
		}

		public void WriteFloat(TextWriter writer, object floatValue)
		{
			if (floatValue == null) return;
			var floatVal = (float)floatValue;
			if (Equals(floatVal, float.MaxValue) || Equals(floatVal, float.MinValue))
				writer.Write(floatVal.ToString("r", CultureInfo.InvariantCulture));
			else
				writer.Write(floatVal.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteDouble(TextWriter writer, object doubleValue)
		{
			if (doubleValue == null) return;
			var doubleVal = (double)doubleValue;
			if (Equals(doubleVal, double.MaxValue) || Equals(doubleVal, double.MinValue))
				writer.Write(doubleVal.ToString("r", CultureInfo.InvariantCulture));
			else
				writer.Write(doubleVal.ToString(CultureInfo.InvariantCulture));
		}

		public void WriteDecimal(TextWriter writer, object decimalValue)
		{
			if (decimalValue == null) return;
			writer.Write(((decimal)decimalValue).ToString(CultureInfo.InvariantCulture));
		}

		public void WriteEnum(TextWriter writer, object enumValue)
		{
			if (enumValue == null) return;
			writer.Write(enumValue.ToString());
		}

		public void WriteEnumFlags(TextWriter writer, object enumFlagValue)
		{
			if (enumFlagValue == null) return;
			var intVal = (int)enumFlagValue;
			writer.Write(intVal);
		}

		public object EncodeMapKey(object value)
		{
			return value;
		}

		public ParseStringDelegate GetParseFn<T>()
		{
			return JsvReader.Instance.GetParseFn<T>();
		}

		public ParseStringDelegate GetParseFn(Type type)
		{
			return JsvReader.GetParseFn(type);
		}

		public string ParseRawString(string value)
		{
			return value;
		}

		public string ParseString(string value)
		{
			return value.FromCsvField();
		}

		public string EatTypeValue(string value, ref int i)
		{
			return EatValue(value, ref i);
		}

		public bool EatMapStartChar(string value, ref int i)
		{
			var success = value[i] == JsWriter.MapStartChar;
			if (success) i++;
			return success;
		}

		public string EatMapKey(string value, ref int i)
		{
			var tokenStartPos = i;

			var valueLength = value.Length;

			var valueChar = value[tokenStartPos];

			switch (valueChar)
			{
				case JsWriter.QuoteChar:
					while (++i < valueLength)
					{
						valueChar = value[i];

						if (valueChar != JsWriter.QuoteChar) continue;

						var isLiteralQuote = i + 1 < valueLength && value[i + 1] == JsWriter.QuoteChar;

						i++; //skip quote
						if (!isLiteralQuote)
							break;
					}
					return value.Substring(tokenStartPos, i - tokenStartPos);

				//Is Type/Map, i.e. {...}
				case JsWriter.MapStartChar:
					var endsToEat = 1;
					var withinQuotes = false;
					while (++i < valueLength && endsToEat > 0)
					{
						valueChar = value[i];

						if (valueChar == JsWriter.QuoteChar)
							withinQuotes = !withinQuotes;

						if (withinQuotes)
							continue;

						if (valueChar == JsWriter.MapStartChar)
							endsToEat++;

						if (valueChar == JsWriter.MapEndChar)
							endsToEat--;
					}
					return value.Substring(tokenStartPos, i - tokenStartPos);
			}

			while (value[++i] != JsWriter.MapKeySeperator) { }
			return value.Substring(tokenStartPos, i - tokenStartPos);
		}

		public bool EatMapKeySeperator(string value, ref int i)
		{
			return value[i++] == JsWriter.MapKeySeperator;
		}

		public bool EatItemSeperatorOrMapEndChar(string value, ref int i)
		{
			if (i == value.Length) return false;

			var success = value[i] == JsWriter.ItemSeperator
				|| value[i] == JsWriter.MapEndChar;
			i++;
			return success;
		}

		public string EatValue(string value, ref int i)
		{
			var tokenStartPos = i;
			var valueLength = value.Length;
			if (i == valueLength) return null;

			var valueChar = value[i];
			var withinQuotes = false;
			var endsToEat = 1;

			switch (valueChar)
			{
				//If we are at the end, return.
				case JsWriter.ItemSeperator:
				case JsWriter.MapEndChar:
					return null;

				//Is Within Quotes, i.e. "..."
				case JsWriter.QuoteChar:
					while (++i < valueLength)
					{
						valueChar = value[i];

						if (valueChar != JsWriter.QuoteChar) continue;

						var isLiteralQuote = i + 1 < valueLength && value[i + 1] == JsWriter.QuoteChar;

						i++; //skip quote
						if (!isLiteralQuote)
							break;
					}
					return value.Substring(tokenStartPos, i - tokenStartPos).FromCsvField();

				//Is Type/Map, i.e. {...}
				case JsWriter.MapStartChar:
					while (++i < valueLength && endsToEat > 0)
					{
						valueChar = value[i];

						if (valueChar == JsWriter.QuoteChar)
							withinQuotes = !withinQuotes;

						if (withinQuotes)
							continue;

						if (valueChar == JsWriter.MapStartChar)
							endsToEat++;

						if (valueChar == JsWriter.MapEndChar)
							endsToEat--;
					}
					return value.Substring(tokenStartPos, i - tokenStartPos);

				//Is List, i.e. [...]
				case JsWriter.ListStartChar:
					while (++i < valueLength && endsToEat > 0)
					{
						valueChar = value[i];

						if (valueChar == JsWriter.QuoteChar)
							withinQuotes = !withinQuotes;

						if (withinQuotes)
							continue;

						if (valueChar == JsWriter.ListStartChar)
							endsToEat++;

						if (valueChar == JsWriter.ListEndChar)
							endsToEat--;
					}
					return value.Substring(tokenStartPos, i - tokenStartPos);
			}

			//Is Value
			while (++i < valueLength)
			{
				valueChar = value[i];

				if (valueChar == JsWriter.ItemSeperator
					|| valueChar == JsWriter.MapEndChar)
				{
					break;
				}
			}

			return value.Substring(tokenStartPos, i - tokenStartPos);
		}
	}
}