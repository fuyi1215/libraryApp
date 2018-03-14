using System;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Library.Views.CollapseListView;

namespace Library.Droid
{
	public class DataAdopter : BaseExpandableListAdapter
	{
		readonly Activity Context;

		public static event EventHandler ProductRestoredCompleted;
		public DataAdopter(Activity newContext, List<EntityClass> newList) : base()
		{
			Context = newContext;
			DataList = newList;
		}

		public static List<EntityClass> DataList { get; set; }

		public override Android.Views.View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
		{
			View header = convertView;
			if (header == null)
			{
				header = Context.LayoutInflater.Inflate(Resource.Layout.NativeListViewCell, null);
			}
			header.FindViewById<TextView>(Resource.Id.txtView).Text = DataList[groupPosition].Title;
			return header;
		}

		public override View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
		{
			View row = convertView;
			if (row == null)
			{
				row = Context.LayoutInflater.Inflate(Resource.Layout.ChildCell, null);
			}
			List<EntityClass> newValue = new List<EntityClass>();
			GetChildViewHelper(groupPosition, out newValue);
			row.FindViewById<TextView>(Resource.Id.txtTitle).Text = newValue[childPosition].Title;
			return row;
		}

		public override int GetChildrenCount(int groupPosition)
		{
			var results = DataList[groupPosition].ChildItems == null ? 0 : DataList[groupPosition].ChildItems.Count;
			return results;
		}

		public override int GroupCount
		{
			get
			{
				return DataList.Count;
			}
		}

		private void GetChildViewHelper(int groupPosition, out List<EntityClass> Value)
		{
			var results = DataList[groupPosition].ChildItems;
			Value = results;
		}

		#region implemented abstract members of BaseExpandableListAdapter

		public override Java.Lang.Object GetChild(int groupPosition, int childPosition)
		{

			throw new NotImplementedException();
		}

		public override long GetChildId(int groupPosition, int childPosition)
		{
			return childPosition;
		}

		public override Java.Lang.Object GetGroup(int groupPosition)
		{
			throw new NotImplementedException();
		}

		public override long GetGroupId(int groupPosition)
		{
			return groupPosition;
		}

		public override bool IsChildSelectable(int groupPosition, int childPosition)
		{
			return true;
		}

		public override bool HasStableIds
		{
			get
			{
				return true;
			}
		}

		#endregion
	}

}
