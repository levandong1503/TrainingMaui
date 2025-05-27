using Microsoft.EntityFrameworkCore;

namespace TrainingMaui.DataAccess.Configurations;

public class MyContext : DbContext
{

    public MyContext(DbContextOptions<MyContext> options) : base(options)
    {
    }
}
