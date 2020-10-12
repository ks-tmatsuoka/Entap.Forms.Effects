# Entap.Forms.Effects
Xamarin.Froms.Effect ライブラリ

## **導入手順**
#### ・パッケージを共通プロジェクトに追加
#### ・プラットフォーム毎に初期化

### iOS
AppDelegateに以下のコードを追加
```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
    global::Xamarin.Forms.Forms.Init();
    Entap.Froms.Effects.iOS.Platform.Init();    // 追加

    LoadApplication(new App());

    return base.FinishedLaunching(app, options);
}
```
### Android
MainActivityに以下のコードを追加
```csharp
protected override void OnCreate(Bundle savedInstanceState)
{
    base.SetTheme(Resource.Style.MainTheme);

    TabLayoutResource = Resource.Layout.Tabbar;
    ToolbarResource = Resource.Layout.Toolbar;

    base.OnCreate(savedInstanceState);

    Xamarin.Essentials.Platform.Init(this, savedInstanceState);
    global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
    Entap.Froms.Effects.Android.Platform.Init();    // 追加

    LoadApplication(new App());
}
```

## **使用例**
```xml
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage
	xmlns="http://xamarin.com/schemas/2014/forms"
	xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
	x:Class="App.Page"
	xmlns:local="clr-namespace:App"
	xmlns:iOSEffects="clr-namespace:Entap.Forms.Effects.Platform.iOS;assembly=Entap.Forms.Effects"
>
	<Editor
		iOSEffects:KeyboardOverlappingEffect.IsEnabled="True"
	/>
</ContentPage>
```