using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StockMonitor.Controllers;

[ApiController]
[Route("[controller]")]
public sealed class BooksController : Controller
{
    private readonly AppDbContext dbContext;

    public BooksController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> GetAll()
    {
        return await dbContext.Books.ToListAsync();
    }
}