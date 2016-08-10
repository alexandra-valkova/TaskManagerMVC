using DataAccess.Entities;
using System;
using System.Linq.Expressions;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels
{
    public abstract class BaseFilterVM<T> where T : BaseEntity
    {
        public string Prefix
        {
            get
            {
                return "Filter.";
            }
        }

        public Pager ParentPager { get; set; }

        public abstract Expression<Func<T, bool>> BuildFilter();
    }
}