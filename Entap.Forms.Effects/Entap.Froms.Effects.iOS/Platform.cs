using System;
using Entap.Forms.Effects;
using Xamarin.Forms.Internals;

namespace Entap.Froms.Effects.iOS
{
    [Preserve(AllMembers = true)]
    public static class Platform
    {
        public static void Init()
        {
            Initializer.Init();
        }
    }
}
