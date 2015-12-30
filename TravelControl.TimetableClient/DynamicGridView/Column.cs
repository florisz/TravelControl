namespace TravelControl.TimeTableClient.DynamicGridView
{
    public class Column
    {
        public Column(string header, string dataField)
        {
            Header = header;
            DataField = dataField;
        }
        public string Header { get; set; }
        public string DataField { get; set; }
    }
}
