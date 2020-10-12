using System;
using Entap.Forms.Effects.Platform.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Entap.Froms.Effects.iOS.KeyboardOverlappingPlatformEffect), nameof(KeyboardOverlappingEffect))]
namespace Entap.Froms.Effects.iOS
{
    public class KeyboardOverlappingPlatformEffect : PlatformEffect
    {
        // KeyboardObserver
        NSObject _keyboardShownObserver;
        NSObject _keyboardHiddenObserver;

        Thickness _margin;
        double _absoluteY = -1;
        double _parentHeight;

        protected override void OnAttached()
        {
            SubscribeKeyboardObserver();
        }

        protected override void OnDetached()
        {
            UnsubscribeKeyboardObserver();
        }

        void SubscribeKeyboardObserver()
        {
            _keyboardShownObserver = UIKeyboard.Notifications.ObserveWillShow(OnKeyboardShown);
            _keyboardHiddenObserver = UIKeyboard.Notifications.ObserveWillHide(OnKeyboardHidden);
        }

        void UnsubscribeKeyboardObserver()
        {
            _keyboardShownObserver?.Dispose();
            _keyboardHiddenObserver?.Dispose();
        }

        void OnKeyboardShown(object sender, UIKeyboardEventArgs e)
        {
            if (Element is null) return;
            if (!(Element is View view)) return;

            if (_absoluteY < 0)
            {
                // ViewがMaringを退避
                _margin = view.Margin;

                // Viewの絶対位置Yと、Pageの高さを取得
                _absoluteY = view.Y;
                _parentHeight = view.Height;
                var element = view.Parent;
                while (element is VisualElement visualElement)
                {
                    _absoluteY += visualElement.Y;
                    _parentHeight = visualElement.Height;
                    element = visualElement.Parent;

                    // NavigationPageはスキップ
                    // NavigationPageを処理すると以下の不整合が生じる
                    // ・_absoluteYにはNavigaitonBar.Heightが含まれない
                    // ・_parentHeightにはNavigationBar.Heightが含まれる
                    if (element is Page) break;
                }
            }
            var bottomMargin = KeyboardOverlappingEffect.GetBottomMargin(Element);
            var bottom = e.FrameEnd.Height -
                (_parentHeight - _absoluteY - view.Height - view.TranslationY) +
                bottomMargin;
            if (bottom <= 0) return;

            view.Margin = new Thickness(
                _margin.Left,
                _margin.Top,
                _margin.Right,
                bottom);
        }

        void OnKeyboardHidden(object sender, UIKeyboardEventArgs e)
        {
            if (Element is null) return;
            if (!(Element is View view)) return;

            // Viewが保有していたMaringに戻す
            view.Margin = _margin;
        }
    }
}

