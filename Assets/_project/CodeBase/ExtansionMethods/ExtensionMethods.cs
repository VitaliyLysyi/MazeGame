using UnityEngine;

namespace codeBase.extansionMethods
{
    public static class ExtensionMethods
    {
        public static float toAudioValue01(this float value) => Mathf.Log10(value) * 20;
    }
}
