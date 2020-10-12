using System;
using Entap.Forms.Effects.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Entap.Froms.Effects.iOS.DatePickerStylePlatformEffect), nameof(DatePickerStyleEffect))]
namespace Entap.Froms.Effects.iOS
{
    /// <summary>
    /// DatePickerStyleEffect　Platform実装
    /// </summary>
    public class DatePickerStylePlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            UpdateDatePickerStyle();
        }


        protected override void OnDetached()
        {
        }

        void UpdateDatePickerStyle()
        {
            if (!UIDevice.CurrentDevice.CheckSystemVersion(14, 0)) return;
            if (Control is null) return;

            if (!(Control is UITextField textField)) return;
            if (!(textField.InputView is UIDatePicker datePicker)) return;
            datePicker.PreferredDatePickerStyle = GetDatePickerStyle();
        }

        UIDatePickerStyle GetDatePickerStyle()
        {
            var style = DatePickerStyleEffect.GetDatePickerStyle(Element);
            switch(style)
            {
                case DatePickerStyle.Compact:
                    return UIDatePickerStyle.Compact;
                case DatePickerStyle.Inline:
                    return UIDatePickerStyle.Inline;
                case DatePickerStyle.Wheels:
                    return UIDatePickerStyle.Wheels;
                case DatePickerStyle.Automatic:
                default:
                    return UIDatePickerStyle.Automatic;
            }
        }
    }
}
