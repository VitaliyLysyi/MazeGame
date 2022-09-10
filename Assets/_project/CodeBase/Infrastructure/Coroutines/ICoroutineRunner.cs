using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace codeBase.infrastructure.Coroutines
{
    public interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        
        public void StopCoroutine(Coroutine coroutine);
    }
}