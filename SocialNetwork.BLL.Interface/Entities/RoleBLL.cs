namespace BLL.Interface.Entities
{
    public class RoleBLL : IEntityBLL
    {
        public RoleBLL()
        {

        }

        public RoleBLL(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
