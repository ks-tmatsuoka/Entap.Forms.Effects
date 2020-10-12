using System;
using System.Linq;
using Xamarin.Forms;

namespace Entap.Forms.Effects.Platform.iOS
{
    /// <summary>
    /// iOS14で追加されたDatePickerStyleを指定する
    /// </summary>
    public static class DatePickerStyleEffect
    {
        #region DatePickerStyle
        public static readonly BindableProperty DatePickerStyleProperty =
            BindableProperty.CreateAttached("DatePickerStyle", typeof(DatePickerStyle), typeof(DatePickerStyleEffect), DatePickerStyle.Automatic, propertyChanged: OnPropertyChanged);

        public static DatePickerStyle GetDatePickerStyle(BindableObject view)
        {
            return (DatePickerStyle)view.GetValue(DatePickerStyleProperty);
        }
        #endregion

        static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            var toRemove = view.Effects.FirstOrDefault((arg) => arg is DatePickerStyleRoutingEffect);
            if (toRemove != null)
                view.Effects.Remove(toRemove);

            view.Effects.Add(new DatePickerStyleRoutingEffect());
        }

        class DatePickerStyleRoutingEffect : RoutingEffect
        {
            public DatePickerStyleRoutingEffect() : base("Entap.Forms.Effects." + nameof(DatePickerStyleEffect))
            {
            }
        }
    }

    /// <summary>
    /// スタイル
    /// https://developer.apple.com/documentation/uikit/uidatepickerstyle?language=objc
    /// </summary>
    public enum DatePickerStyle
    {
        Automatic,
        Compact,
        Inline,
        Wheels
    }
}
