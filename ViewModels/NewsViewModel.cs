namespace App.Admin.ViewModels;

public class NewsViewModel
{
    public List<NewsVM> NewsArticles { get; set; }
    public PageInfo PageInfo { get; set; }
}

public class PageInfo
{
    public int CurrentPage { get; set; }
    public int ItemsPerPage { get; set; }
    public int TotalItems { get; set; }
}

public class NewsVM
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string CoverImagePath { get; set; }
    public string Content { get; set; }
    public string DatePublished { get; set; }
}
