using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI.Fody.Helpers;


namespace Sample
{
    public interface ISensorViewModel
    {

        string Title { get; }
        ICommand Toggle { get; }
        string ValueName { get; }
        string Value { get; }
        string ToggleText { get; }
    }
}
