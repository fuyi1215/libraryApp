using System;
using System.Collections.Generic;
using SQLite;

namespace Library.Views.CollapseListView
{
	public class EntityClass
	{
		


		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string SelectedStateIcon { get; set; }

		public string DeselectedStateIcon { get; set; }

		public bool IsSelected { get; set; }

		public List<EntityClass> ChildItems { get; set; }

		public Action<EntityClass> OnClickListener { get; set; }


		public EntityClass()
		{

		}


	}
}
