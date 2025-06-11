using System.Collections;
using System.Windows.Forms;

namespace UI.Helpers
{
	public class ListViewColumnSorter : IComparer
	{
		private int ColumnToSort;

		private SortOrder OrderOfSort;

		private CaseInsensitiveComparer ObjectCompare;

		public int SortColumn
		{
			get
			{
				return ColumnToSort;
			}
			set
			{
				ColumnToSort = value;
			}
		}

		public SortOrder Order
		{
			get
			{
				return OrderOfSort;
			}
			set
			{
				OrderOfSort = value;
			}
		}

		public ListViewColumnSorter()
		{
			ColumnToSort = 0;
			OrderOfSort = SortOrder.None;
			ObjectCompare = new CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			int num = ObjectCompare.Compare(((ListViewItem)x).SubItems[ColumnToSort].Text, ((ListViewItem)y).SubItems[ColumnToSort].Text);
			if (OrderOfSort == SortOrder.Ascending)
			{
				return num;
			}
			if (OrderOfSort != SortOrder.Descending)
			{
				return 0;
			}
			return -num;
		}
	}
}
