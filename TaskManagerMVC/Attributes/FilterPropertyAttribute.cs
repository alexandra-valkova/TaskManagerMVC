using System;

namespace TaskManagerMVC.Attributes
{
    public class FilterPropertyAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public string DropDownList { get; set; }
    }
}