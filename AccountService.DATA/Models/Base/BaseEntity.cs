namespace AccountService.Data.Models.Base
{
    public class BaseEntity:IBaseEntity
    {
        public long Id { get; set; }
        public bool IsDelete { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
