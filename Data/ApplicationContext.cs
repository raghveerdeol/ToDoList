using Microsoft.EntityFrameworkCore;
using ToDoList.Models;
using static System.Net.Mime.MediaTypeNames;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
        
    public DbSet<TaskList> TaskLists { get; set; }
}