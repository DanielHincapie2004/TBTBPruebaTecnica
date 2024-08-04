namespace TBTBGlobal_PruebaTecnicaAPI.Models
{
    public class User
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public Boolean Status { get; set; }
        public Rol Rol { get; set; }
    }
}
