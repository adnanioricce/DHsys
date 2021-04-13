namespace Core.Entities.User
{
    public class Operator : BaseEntity
    {
        public Operator(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}