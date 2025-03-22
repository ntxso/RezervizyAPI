namespace WebUI.Models
{
    public interface INameId
    {
        int Id { get; set; }
        string Name { get; set; }
    }
    public class NameId:INameId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
