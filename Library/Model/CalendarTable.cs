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
        public string id { get; set; }= String.Empty;
        public string status { get; set; }= String.Empty;
        public string htmlLink { get; set; }= String.Empty;
        public string created { get; set; }= String.Empty;
        public string updated { get; set; }= String.Empty;
        public string summary { get; set; } = String.Empty;
        public string description { get; set; } = String.Empty;
        public string location { get; set; }= String.Empty;
        public string creator { get; set; }= String.Empty;
        public string organizer { get; set; }= String.Empty;
        public string start { get; set; } = String.Empty;
        public string end { get; set; }= String.Empty;
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

