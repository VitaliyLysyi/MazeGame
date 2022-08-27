using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Coroutines
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        
        public void StopCoroutine(Coroutine coroutine);
    }
}