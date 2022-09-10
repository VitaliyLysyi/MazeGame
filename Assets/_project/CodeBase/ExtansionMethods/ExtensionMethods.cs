using System.Collections.Generic;
using UnityEngine;

namespace codeBase.extansionMethods
{
    public static class ExtensionMethods
    {
        public static float toAudioValue01(this float value) => Mathf.Log10(value) * 20;

        public static T getLastElement<T>(this List<T> list)
        {
            try {
                return list[list.Count - 1];
            }
            catch (System.Exception eroor) {
                Debug.LogError(eroor.Message);
                throw;
            }
        }

        public static T getLastElement<T>(this T[] array)
        {
            try {
                return array[array.Length - 1];
            }
            catch (System.Exception eroor) {
                Debug.LogError(eroor.Message);
                throw;
            }
        }
    }
}
