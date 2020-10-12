using System;
using System.Linq;
using Xamarin.Forms;

namespace Entap.Forms.Effects.Platform.iOS
{
    /// <summary>
    /// キーボード表示時に、指定されたViewのMarginを調整してキーボードとの重なりを避ける
    /// </summary>
    public static class KeyboardOverlappingEffect
    {
        #region BottomMargin
        /// <summary>
        /// キーボード表示時のViewとKeyboardとのMargin
        /// </summary>
        public static readonly BindableProperty BottomMarginProperty =
            BindableProperty.CreateAttached("BottomMargin", typeof(double), typeof(KeyboardOverlappingEffect), 2d, propertyChanged: OnPropertyChanged);

        public static double GetBottomMargin(BindableObject view)
        {
            return (double)view.GetValue(BottomMarginProperty);
        }
        #endregion

        #region IsEnabled
        /// <summary>
        /// Effectを有効にするか
        /// </summary>
        public static readonly BindableProperty IsEnabledProperty =
            BindableProperty.CreateAttached("IsEnabled", typeof(bool), typeof(KeyboardOverlappingEffect), false, propertyChanged: OnPropertyChanged);

        public static bool GetIsEnabled(BindableObject view)
        {
            return (bool)view.GetValue(IsEnabledProperty);
        }
        #endregion

        static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            var toRemove = view.Effects.FirstOrDefault((arg) => arg is KeyboardOverlappingRoutingEffect);
            if (toRemove != null)
                view.Effects.Remove(toRemove);
            if (GetIsEnabled(bindable))
                view.Effects.Add(new KeyboardOverlappingRoutingEffect());
        }

        class KeyboardOverlappingRoutingEffect : RoutingEffect
        {
            public KeyboardOverlappingRoutingEffect() : base("Entap.Forms.Effects." + nameof(KeyboardOverlappingEffect))
            {
            }
        }
    }
}
