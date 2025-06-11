using System;
using System.ComponentModel;

namespace RxjhServer.RxjhTool
{
	[DefaultProperty("Name")]
	public class Customer
	{
		private string _name;

		private int _age;

		private DateTime _dateOfBirth;

		private string _SSN;

		private string _address;

		private string _email;

		private bool _frequentBuyer;

		[Category("ID Settings")]
		[Description("Name of the customer")]
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		[Description("Social Security Number of the customer")]
		[Category("ID Settings")]
		public string SSN
		{
			get
			{
				return _SSN;
			}
			set
			{
				_SSN = value;
			}
		}

		[Category("ID Settings")]
		[Description("Address of the customer")]
		public string Address
		{
			get
			{
				return _address;
			}
			set
			{
				_address = value;
			}
		}

		[Category("ID Settings")]
		[Description("Date of Birth of the Customer (optional)")]
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
			set
			{
				_dateOfBirth = value;
			}
		}

		[Description("Age of the customer")]
		[Category("ID Settings")]
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
			}
		}

		[Category("Marketting Settings")]
		[Description("If the customer has bought more than 10 times, this is set to true")]
		public bool FrequentBuyer
		{
			get
			{
				return _frequentBuyer;
			}
			set
			{
				_frequentBuyer = value;
			}
		}

		[Category("Marketting Settings")]
		[Description("Most current e-mail of the customer")]
		public string Email
		{
			get
			{
				return _email;
			}
			set
			{
				_email = value;
			}
		}
	}
}
