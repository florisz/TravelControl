using System.Collections.Generic;

namespace TravelControl.TimeTableClient.DynamicGridView
{
    public class ColumnConfig
    {
        public ColumnConfig()
        {
            Columns = new List<Column>();
        }
        public List<Column> Columns { get; set; }
    }

}
