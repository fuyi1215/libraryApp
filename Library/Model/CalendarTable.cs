using System;
using System.Collections.Generic;
using SQLite;
using Xamarin.Forms;

namespace Library
{


	public class CalendarTable 
	{
		//public Calendar Calendar { get; set; }
		//public string kind { get; set; }
		public string etag { get; set; }
		[PrimaryKey]
		public string id { get; set; }
		public string status { get; set; }
		public string htmlLink { get; set; }
		public string created { get; set; }
		public string updated { get; set; }
        public string summary { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
		public string location { get; set; }
		public string creator { get; set; }
		public string organizer { get; set; }
        public string start { get; set; } = String.Empty;
		public string end { get; set; }
		//public string iCalUID { get; set; }
		//public int? sequence { get; set; }
		//public bool? guestsCanSeeOtherGuests { get; set; }
		//public List<string> recurrence { get; set; }
		//public string transparency { get; set; }
		//public string recurringEventId { get; set; }
		//public string originalStartTime { get; set; }

		public CalendarTable()
		{

		}

		public CalendarTable(CalendarInfo.Item item)
		{
			//kind = item.kind;
			id = item.id;
			htmlLink = item.htmlLink;
			created = item.created;
			updated = item.updated;
			summary = item.summary;
			description = item.description;
			location = item.location;
			creator = item.created;
			//organizer = item.organizer.displayName;
			start = item.start.dateTime;
			end = item.start.dateTime;
			//iCalUID = item.iCalUID;
			//sequence = item.sequence;
			//guestsCanSeeOtherGuests = item.guestsCanSeeOtherGuests;
			//transparency = item.transparency;
			//recurringEventId = item.recurringEventId;
			//originalStartTime = item.originalStartTime.dateTime;
			//public string iCalUID { get; set; }
			//public int sequence { get; set; }
			//public bool? guestsCanSeeOtherGuests { get; set; }
			//public List<string> recurrence { get; set; }
			//public string transparency { get; set; }
			//public string recurringEventId { get; set; }
			//public DateTime originalStartTime { get; set; }
		}
	}





}

