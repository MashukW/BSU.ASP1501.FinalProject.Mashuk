namespace DAL.Interface.DTO
{
    public class RoleDTO : IEntityDAL
    {
        public RoleDTO()
        {
            
        }

        public RoleDTO(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
