using System;
using Entap.Forms.Effects.Platform.Android;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(Entap.Froms.Effects.Android.PaddingPlatformEffect), "PaddingEffect")]
namespace Entap.Froms.Effects.Android
{
    /// <summary>
    /// PaddingEffect　Platform実装
    /// </summary>
    public class PaddingPlatformEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            UpdatePadding();
        }


        protected override void OnDetached()
        {
        }

        void UpdatePadding()
        {
            var padding = PaddingEffect.GetPadding(Element);
            if (Control != null)
            {
                Control.SetPadding(
                    (int)(padding.Left * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Top * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Right * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Bottom * DeviceDisplay.MainDisplayInfo.Density));
                return;
            }

            if (Container != null)
            {
                Control.SetPadding(
                    (int)(padding.Left * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Top * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Right * DeviceDisplay.MainDisplayInfo.Density),
                    (int)(padding.Bottom * DeviceDisplay.MainDisplayInfo.Density));
                return;
            }
        }
    }
}
