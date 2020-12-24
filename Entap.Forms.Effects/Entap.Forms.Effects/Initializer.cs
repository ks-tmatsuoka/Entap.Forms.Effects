using System;
namespace Entap.Forms.Effects
{
    internal class Initializer
    {
        public static void Init()
        {
#pragma warning disable 0219
            // HACK  Releaseモード時にEffectが適用されない不具合対応
            var dummy = Activator.CreateInstance(typeof(Initializer));
#pragma warning disable 0219
        }
    }
}
