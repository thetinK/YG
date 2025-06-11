using System;
using System.Reflection;

namespace RxjhServer.RxjhTool
{
	public class CustomProperty
	{
		private string _name = string.Empty;

		private object _defaultValue;

		private object _value;

		private object _对象;

		private PropertyInfo[] _propertyInfos;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				if (PropertyNames == null)
				{
					PropertyNames = new string[1] { _name };
				}
			}
		}

		public string[] PropertyNames { get; set; }

		public Type ValueType { get; set; }

		public object DefaultValue
		{
			get
			{
				return _defaultValue;
			}
			set
			{
				_defaultValue = value;
				if (_defaultValue != null)
				{
					if (_value == null)
					{
						_value = _defaultValue;
					}
					if (!(ValueType != null))
					{
						ValueType = _defaultValue.GetType();
					}
				}
			}
		}

		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
				OnValueChanged();
			}
		}

		public bool IsReadOnly { get; set; }

		public string Description { get; set; }

		public string Category { get; set; }

		public bool IsBrowsable { get; set; }

		public object ObjectSource
		{
			get
			{
				return _对象;
			}
			set
			{
				_对象 = value;
				OnObjectSourceChanged();
			}
		}

		public Type EditorType { get; set; }

		public bool ConverterType { get; set; }

		protected PropertyInfo[] PropertyInfos
		{
			get
			{
				if (_propertyInfos == null)
				{
					Type type = ObjectSource.GetType();
					_propertyInfos = new PropertyInfo[PropertyNames.Length];
					for (int i = 0; i < PropertyNames.Length; i++)
					{
						_propertyInfos[i] = type.GetProperty(PropertyNames[i]);
					}
				}
				return _propertyInfos;
			}
		}

		public CustomProperty()
		{
		}

		public CustomProperty(string name, string 属性名, bool isReadOnly, string category, string description, object 对象)
			: this(name, new string[1] { 属性名 }, null, null, null, (isReadOnly ? 1 : 0) != 0, isBrowsable: true, category, description, 对象, null, converterType: false)
		{
		}

		public CustomProperty(string name, string 属性名, bool isReadOnly, string category, string description, object 对象, bool converterType)
			: this(name, new string[1] { 属性名 }, null, null, null, (isReadOnly ? 1 : 0) != 0, isBrowsable: true, category, description, 对象, null, (converterType ? 1 : 0) != 0)
		{
		}

		public CustomProperty(string name, string 属性名, bool isReadOnly, string category, string description, object 对象, Type editorType)
			: this(name, new string[1] { 属性名 }, null, null, null, (isReadOnly ? 1 : 0) != 0, isBrowsable: true, category, description, 对象, editorType, converterType: false)
		{
		}

		public CustomProperty(string name, string 属性名, bool isReadOnly, string category, string description, object 对象, Type editorType, bool converterType)
			: this(name, new string[1] { 属性名 }, null, null, null, (isReadOnly ? 1 : 0) != 0, isBrowsable: true, category, description, 对象, editorType, (converterType ? 1 : 0) != 0)
		{
		}

		public CustomProperty(string name, string[] 属性名, Type valueType, object defaultValue, object value, bool isReadOnly, bool isBrowsable, string category, string description, object 对象, Type editorType, bool converterType)
		{
			Name = name;
			PropertyNames = 属性名;
			ValueType = valueType;
			_defaultValue = defaultValue;
			_value = value;
			IsReadOnly = isReadOnly;
			IsBrowsable = isBrowsable;
			Category = category;
			Description = description;
			ObjectSource = 对象;
			EditorType = editorType;
			ConverterType = converterType;
		}

		protected void OnObjectSourceChanged()
		{
			if (PropertyInfos.Length != 0)
			{
				object value = PropertyInfos[0].GetValue(_对象, null);
				if (_defaultValue == null)
				{
					DefaultValue = value;
				}
				_value = value;
			}
		}

		protected void OnValueChanged()
		{
			if (_对象 != null)
			{
				PropertyInfo[] propertyInfos = PropertyInfos;
				PropertyInfo[] array = propertyInfos;
				PropertyInfo[] array2 = array;
				foreach (PropertyInfo propertyInfo in array2)
				{
					propertyInfo.SetValue(_对象, _value, null);
				}
			}
		}

		public void ResetValue()
		{
			Value = DefaultValue;
		}
	}
}
