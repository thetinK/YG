using System;
using System.ComponentModel;
using System.Globalization;

namespace RxjhServer.RxjhTool
{
	public class SpellingOptionsConverter : ExpandableObjectConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(坐标类) || base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType != typeof(string) || !(value is 坐标类))
			{
				return base.ConvertTo(context, culture, value, destinationType);
			}
			坐标类 坐标类2 = (坐标类)value;
			return "地图ID:" + 坐标类2.地图Id + "，坐标X: " + 坐标类2.坐标X + "，坐标Y: " + 坐标类2.坐标Y;
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string text = value as string;
			if (text != null)
			{
				try
				{
					string text2 = text;
					int num = text2.IndexOf(':');
					int num2 = text2.IndexOf(',');
					if (num != -1 && num2 != -1)
					{
						text2.Substring(num + 1, num2 - num - 1);
						int num3 = text2.IndexOf(':', num2 + 1);
						int num4 = text2.IndexOf(',', num2 + 1);
						text2.Substring(num3 + 1, num4 - num3 - 1);
						int num5 = text2.IndexOf(':', num4 + 1);
						text2.Substring(num5 + 1);
						return new 坐标类();
					}
				}
				catch
				{
					throw new ArgumentException("无法将“" + text + "”转换为 SpellingOptions 类型");
				}
			}
			return base.ConvertFrom(context, culture, value);
		}
	}
}
