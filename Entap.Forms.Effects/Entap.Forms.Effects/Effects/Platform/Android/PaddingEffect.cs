using System;
using System.Linq;
using Xamarin.Forms;

namespace Entap.Forms.Effects.Platform.Android
{
    /// <summary>
    /// ViewのPaddingを設定する
    /// Entry, Picker等のViewのデフォルトのPaddingを編集可
    /// </summary>
    public static class PaddingEffect
    {
        #region Padding
        public static readonly BindableProperty PaddingProperty =
            BindableProperty.CreateAttached("Padding", typeof(Thickness), typeof(PaddingEffect), new Thickness(-1), propertyChanged: OnPropertyChanged);

        public static Thickness GetPadding(BindableObject view)
        {
            return (Thickness)view.GetValue(PaddingProperty);
        }
        #endregion

        static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            var toRemove = view.Effects.FirstOrDefault((arg) => arg is PaddingRoutingEffect);
            if (toRemove != null)
                view.Effects.Remove(toRemove);

            view.Effects.Add(new PaddingRoutingEffect());
        }

        class PaddingRoutingEffect : RoutingEffect
        {
            public PaddingRoutingEffect() : base("Entap.Forms.Effects." + nameof(PaddingEffect))
            {
            }
        }
    }
}
