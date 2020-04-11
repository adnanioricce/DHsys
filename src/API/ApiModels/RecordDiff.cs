namespace Api.ApiModels
{
    public class RecordDiff
    {
        public int RecordIndex { get; set; }
        public string Column { get; set; }
        public object Value { get; set; }
        public bool IsNew { get; set; } = false;
    }
}