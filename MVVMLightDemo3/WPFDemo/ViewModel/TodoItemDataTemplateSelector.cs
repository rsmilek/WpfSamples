using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WPFDemo.Models;

namespace WPFDemo.ViewModel
{
    public class TodoItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is TodoItem)
            {
                TodoItem taskitem = item as TodoItem;

                if (taskitem.Priority == 1)
                    return
                        element.FindResource("TodoImportantItemDataTemplate") as DataTemplate;
                else
                    return
                        element.FindResource("TodoItemDataTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
