using DataAccess.Entities;
using System.Collections.Generic;
using TaskManagerMVC.Models;

namespace TaskManagerMVC.ViewModels
{
    public class BaseIndexVM<T, F>
        where T : BaseEntity
        where F : BaseFilterVM<T>
    {
        public List<T> Items { get; set; }

        public Pager Pager { get; set; }
        
        public F Filter { get; set; }
    }
}