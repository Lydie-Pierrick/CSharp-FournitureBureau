using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Mercure.View
{
    class ListViewItemComparator : IComparer
    {
        private int Column;
        private SortOrder Order;
        public ListViewItemComparator()
        {
            Column = 0;
            Order = SortOrder.Ascending;
        }
        public ListViewItemComparator(int Column, SortOrder Order)
        {
            this.Column = Column;
            this.Order = Order;
        }
        public int Compare(object X, object Y)
        {
            int ReturnValue = -1;
            float A = 0, B = 0;
            if (float.TryParse(((ListViewItem)X).SubItems[Column].Text, out A) && float.TryParse(((ListViewItem)Y).SubItems[Column].Text, out B))
            {
                ReturnValue = A >= B ? (A == B ? 0 : 1) : -1;
                if (Order == SortOrder.Descending)
                {
                    ReturnValue *= -1;
                }
            }
            else
            {
                ReturnValue = String.Compare(((ListViewItem)X).SubItems[Column].Text, ((ListViewItem)Y).SubItems[Column].Text);
                // Determine whether the sort order is descending.
                if (Order == SortOrder.Descending)
                {
                    // Invert the value returned by String.Compare.
                    ReturnValue *= -1;
                }
            }
            return ReturnValue;
        }
    }
}
