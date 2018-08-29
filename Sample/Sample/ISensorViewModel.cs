﻿using System;
using System.Windows.Input;


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
