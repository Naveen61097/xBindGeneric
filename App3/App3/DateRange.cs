using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App3
{
    public sealed class DateRange : Control
    {
        public DateRange()
        {
            this.DefaultStyleKey = typeof(DateRange);
        }

        #region Header

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof(Header), typeof(string), typeof(DateRange), new PropertyMetadata(default));

        #endregion

        #region Format

        public string Format
        {
            get => (string)GetValue(FormatProperty);
            set => SetValue(FormatProperty, value);
        }

        public static readonly DependencyProperty FormatProperty = DependencyProperty.Register(nameof(Format), typeof(string), typeof(DateRange), new PropertyMetadata(default));

        #endregion

        #region StartDate

        public string StartDate
        {
            get => (string)GetValue(StartDateProperty);
            set => SetValue(StartDateProperty, value);
        }

        public static readonly DependencyProperty StartDateProperty = DependencyProperty.Register(nameof(StartDate), typeof(string), typeof(DateRange), new PropertyMetadata(null));

        #endregion

        #region EndDate

        public string EndDate
        {
            get => (string)GetValue(EndDateProperty);
            set => SetValue(EndDateProperty, value);
        }

        public static readonly DependencyProperty EndDateProperty = DependencyProperty.Register(nameof(EndDate), typeof(string), typeof(DateRange), new PropertyMetadata(null));

        #endregion
    }

    public class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
              object parameter, string language)
        {
            if ((string)parameter == "no_default" && string.IsNullOrEmpty((string)value))
            {
                return null;
            }

            if (value == null || string.IsNullOrEmpty((string)value))
            {
                return null;
            }
            else
            {
                try
                {
                    if (DateTime.TryParse(value?.ToString(), out DateTime date))
                    {
                        date = DateTime.SpecifyKind(date, DateTimeKind.Local);
                        return (DateTimeOffset)date;
                    }
                }
                catch { }

                return null;
            }
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string language)
        {
            string Data = string.Empty;
            if (value == null)
            {
                return Data;
            }
            else
            {
                DateTime d = new DateTime();
                d = ((DateTimeOffset)value).LocalDateTime;
                Data = d.Date.ToString("yyyy-MM-dd");
            }

            return Data;
        }
    }
}
