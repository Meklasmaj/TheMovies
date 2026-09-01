using TheMovies.Core.Interfaces;
using TheMovies.Core;
using TheMovies.Core.Repositories;

namespace TheMovies.Tests;

[TestClass]
public sealed class Test1
{
    // RAM Repo for testing
    public IGenericRepo<Movie> MovieRepo { get; set; } = new InMemoryRepository<Movie>();
    
    [TestMethod]
    public void RepoAddMovieSuccessfullyAddedToList()
    {
        
    }
}