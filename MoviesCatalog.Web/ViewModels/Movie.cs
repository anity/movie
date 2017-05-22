using System;
using System.Collections.Generic;

namespace MoviesCatalog.Web.ViewModels
{
    public class MoviesViewModel
    {
        public MoviesViewModel(IEnumerable<MovieViewModel> movies, PageInfo pageInfo)
        {
            Movies = movies;
            PageInfo = pageInfo;
        }
        public PageInfo PageInfo { get; set; }
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }

    public class PageInfo
    {
        public PageInfo(int page, int pageSize, int totalItems)
        {
            CurrentPage = page;
            NextPage = page + 1;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
        public int CurrentPage { get; set; }
        public int NextPage { get; set; }
        public int PageSize { get; set; } 
        public int TotalItems { get; set; } 
        public int TotalPages  
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }

    public class MovieViewModel
    {
        public MovieViewModel(){}
        public MovieViewModel(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public short? Year { get; set; }
        public string Producer { get; set; }
        public string ImageName { get; set; }
        public string UserName { get; set; }
    }
}