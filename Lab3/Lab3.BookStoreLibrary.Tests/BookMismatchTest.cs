using Lab3.BookStoreLibrary;
namespace Lab3.BookStoreLibraryTests;

public class BookMismatchTest
{
    private List<string> _titles = new List<string>
        {
            "Война и мир",
            "Преступление и наказание",
            "Мастер и Маргарита",
            "1984",
            "Унесенные ветром"
        };
    private List<string> _authors = new List<string>
    {
        "Лев Толстой",
        "Федор Достоевский",
        "Михаил Булгаков",
        "Джордж Оруэлл",
        "Маргарет Митчелл"
    };
    [Fact]
    public void GeneratePlagiarism_ReturnsDifferentAuthorAndTitle()
    {
        var bookMismatch = new BookMismatch();

        List <string> res = bookMismatch.GeneratePlagiarism(
            _titles.ToList(),
            _authors.ToList());
        Assert.True(_titles.Contains(res[0]));
        Assert.True(_authors.Contains(res[1]));
        Assert.False(_titles[_titles.IndexOf(res[0])] == _authors[_authors.IndexOf(res[1])]);
    }
    [Fact]
    public void Shuffle_ListIsShuffled()
    {
        List<string> originalList = new List<string> { "A", "B", "C", "D" };
        List<string> clonedList = new List<string>(originalList);
        BookMismatch.Shuffle(clonedList);
        Assert.False(originalList.SequenceEqual(clonedList));
    }
    [Fact]
    public void GenerateTypo_CreatesValidTypo()
    {
        var bookMismatch = new BookMismatch();
        string original = "1984";
        string typo = bookMismatch.GenerateTypo(original);

        Assert.True(typo.Length == original.Length);
        Assert.False(typo == original);
    }
    [Fact]
    public void IsPlagiarism_Mismatch_ReturnsTrue()
    {

        Assert.True(BookMismatch.IsPlagiarism(_titles, _authors, "Мастер и Маргарита", "Федор Достоевский"));
    }
    [Fact]
    public void IsPlagiarism_Match_ReturnsFalse()
    {
        Assert.False(BookMismatch.IsPlagiarism(_titles, _authors, "Война и мир", "Лев Толстой"));
    }
    [Fact]
    public void IsTypo_SingleCharacterDifference_ReturnsTrue()
    {

        Assert.True(BookMismatch.IsTypo("Война а мир", _titles));
    }
    [Fact]
    public void IsTypo_NoDifference_Returns()
    {
        Assert.False(BookMismatch.IsTypo("Война и мир", _titles));
    }

    [Fact]
    public void CheckSingleDifference_OneDifference_ReturnsTrue()
    {
        Assert.True(BookMismatch.CheckSingleDifference("Война", "Вайна"));
    }

    [Fact]
    public void CheckSingleDifference_MultipleDifferences_ReturnsFalseFor()
    {
        Assert.False(BookMismatch.CheckSingleDifference("мир", "рим"));
    }
}