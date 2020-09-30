namespace RestorauntMenu.Data
{
    public class DbObject
    {
        public static void Initialize(AppDbContext context)
        {                      
            context.SaveChanges();
        }       
    }
}
