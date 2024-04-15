using System;
using Xamarin.Forms;

namespace KakuroGame.Model
{
	public class ValidateCells
	{
		public ValidateCells()
		{
		}

        public static readonly BindableProperty RowIdProperty =
        BindableProperty.CreateAttached("RowId", typeof(int), typeof(ValidateCells), defaultValue: -1);

        public static readonly BindableProperty ColumnIdProperty =
        BindableProperty.CreateAttached("ColumnId", typeof(int), typeof(ValidateCells), defaultValue: -1);

        public static int GetRowId(BindableObject view)
        {
            return (int)view.GetValue(RowIdProperty);
        }

        public static void SetRowId(BindableObject view, int value)
        {
            view.SetValue(RowIdProperty, value);
        }

        public static int GetColumnId(BindableObject view)
        {
            return (int)view.GetValue(ColumnIdProperty);
        }

        public static void SetColumnId(BindableObject view, int value)
        {
            view.SetValue(ColumnIdProperty, value);
        }

    }
}

