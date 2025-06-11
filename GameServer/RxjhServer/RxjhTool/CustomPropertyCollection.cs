using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;

namespace RxjhServer.RxjhTool
{
	public class CustomPropertyCollection : List<CustomProperty>, ICustomTypeDescriptor
	{
		public AttributeCollection GetAttributes()
		{
			return TypeDescriptor.GetAttributes(this, noCustomTypeDesc: true);
		}

		public string GetClassName()
		{
			return TypeDescriptor.GetClassName(this, noCustomTypeDesc: true);
		}

		public string GetComponentName()
		{
			return TypeDescriptor.GetComponentName(this, noCustomTypeDesc: true);
		}

		public TypeConverter GetConverter()
		{
			return TypeDescriptor.GetConverter(this, noCustomTypeDesc: true);
		}

		public EventDescriptor GetDefaultEvent()
		{
			return TypeDescriptor.GetDefaultEvent(this, noCustomTypeDesc: true);
		}

		public PropertyDescriptor GetDefaultProperty()
		{
			return TypeDescriptor.GetDefaultProperty(this, noCustomTypeDesc: true);
		}

		public object GetEditor(Type editorBaseType)
		{
			return TypeDescriptor.GetEditor(this, editorBaseType, noCustomTypeDesc: true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes)
		{
			return TypeDescriptor.GetEvents(this, attributes, noCustomTypeDesc: true);
		}

		public EventDescriptorCollection GetEvents()
		{
			return TypeDescriptor.GetEvents(this, noCustomTypeDesc: true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptorCollection propertyDescriptorCollection = new PropertyDescriptorCollection(null);
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CustomProperty current = enumerator.Current;
					List<Attribute> list = new List<Attribute>
					{
						new CategoryAttribute(current.Category)
					};
					if (!current.IsBrowsable)
					{
						list.Add(new BrowsableAttribute(current.IsBrowsable));
					}
					if (current.IsReadOnly)
					{
						list.Add(new ReadOnlyAttribute(current.IsReadOnly));
					}
					if (current.EditorType != null)
					{
						list.Add(new EditorAttribute(current.EditorType, typeof(UITypeEditor)));
					}
					if (current.ConverterType)
					{
						list.Add(new TypeConverterAttribute(typeof(SpellingOptionsConverter)));
					}
					propertyDescriptorCollection.Add(new CustomPropertyDescriptor(current, list.ToArray()));
				}
			}
			return propertyDescriptorCollection;
		}

		public PropertyDescriptorCollection GetProperties()
		{
			return TypeDescriptor.GetProperties(this, noCustomTypeDesc: true);
		}

		public object GetPropertyOwner(PropertyDescriptor pd)
		{
			return this;
		}
	}
}
