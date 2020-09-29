using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WinForm.Attributes
{
    /// <summary>
    /// NotifyPropertyChanged의 연결을 위한 Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DependsOnPropertiesAttribute : Attribute
    {
        public string[] ParentPropertyNames { get; set; }

        public DependsOnPropertiesAttribute(params string[] parentPropertyNames)
        {
            this.ParentPropertyNames = parentPropertyNames;
        }
    }
}
