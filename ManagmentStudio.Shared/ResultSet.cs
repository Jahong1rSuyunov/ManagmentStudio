namespace ManagmentStudio.Shared
{
    public class ResultSet
    {
        public List<string> Columns { get; set; } = new();

        public List<Row> Rows { get; set; } = new();
    }
}
