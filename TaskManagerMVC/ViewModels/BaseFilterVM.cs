using DataAccess.Entities;
using System;
using System.Linq.Expressions;

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

    public abstract Expression<Func<T, bool>> BuildFilter();
    }
}