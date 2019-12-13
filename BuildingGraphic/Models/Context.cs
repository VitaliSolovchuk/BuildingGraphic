using System.Data.Entity;


namespace BuildingGraphic.Models
{
    public class Context : DbContext
    {
        // Лично я тут вижу исполльзование ДБ как сохранение ранее введенных
        //уравнений, чтобы позже можно было вернуться. Шаг будет только засорять
        public DbSet<Equation> Equations { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}