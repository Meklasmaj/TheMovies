using TheMovies.Core.Interfaces;
using TheMovies.Core;
using TheMovies.Core.Repositories;

namespace TheMovies.Tests;

[TestClass]
public sealed class Test1
{
    
    [TestMethod]
    public void RepoAddMovieSuccessfullyAddedToList()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));
        
        Assert.AreEqual(3, movieRepo.GetAll().Count());
    }
    
    [TestMethod]
    public void RepoAddMovieSuccessfullyAddedIdToMovie()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));
        
        Assert.AreEqual(2, movieRepo.GetAll().ElementAt(2).Id);
        Assert.AreEqual(0, movieRepo.GetAll().ElementAt(0).Id);
    }
    
    [TestMethod]
    public void RepoAddMovieSuccessfullyAddedMovieToCorrectPlace()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));
        
        Assert.AreEqual("BatMan", movieRepo.GetAll().ElementAt(1).Title);
    }
    
    [TestMethod]
    public void RepoRemoveMovieSuccessfullyRemovedMovie()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));
        
        movieRepo.Remove(1);
        
        Assert.IsNull(movieRepo.GetAll().FirstOrDefault(x => x.Id == 1));
        Assert.IsNull(movieRepo.GetAll().FirstOrDefault(x => x.Title == "BatMan"));
        Assert.IsNotNull(movieRepo.GetAll().FirstOrDefault(x => x.Id == 2));
    }
    
    [TestMethod]
    public void RepoUpdateMovieSuccessfullyUpdatedMovie()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));

        Movie movie = movieRepo.Get(1);
        movie.Title = "Superman";
        movieRepo.Update(movie);
        
        Assert.IsNull(movieRepo.GetAll().FirstOrDefault(x => x.Title == "BatMan"));
        Assert.AreEqual("Superman", movieRepo.GetAll().ElementAt(1).Title);
    }
    
    [TestMethod]
    public void RepoGetMovieByIdSuccessfullyRetrievedMovie()
    {
        // RAM Repo for testing
        IGenericRepo<Movie> movieRepo = new InMemoryRepository<Movie>();
        
        movieRepo.Add(new Movie("Spiderman", MovieGenre.ActionandAdventure, 120, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("BatMan", MovieGenre.Comedy, 130, "Tim Burton", DateTime.Now));
        movieRepo.Add(new Movie("IronMan", MovieGenre.Drama, 160, "Tim Burton", DateTime.Now));

        Movie movie = movieRepo.Get(1);
        
        Assert.AreEqual(movie, movieRepo.GetAll().ElementAt(1));
    }
}