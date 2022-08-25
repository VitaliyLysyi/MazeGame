using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Coroutines;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

public class PreloadInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain _loadingCurtain;

    private CoroutineRunner _coroutineRunner;
    private LoadingCurtain _curtain;

    public override void InstallBindings()
    {
        InitCoroutinRuner();
        InitCurtain();

        Container
            .Bind<LoadingCurtain>()
            .FromInstance(_curtain)
            .AsSingle();

        Container
            .Bind<ICoroutineRunner>()
            .FromInstance(_coroutineRunner)
            .AsSingle()
            .NonLazy();

        Container
            .Bind<Game>()
            .AsSingle();
    }

    private void InitCurtain()
    {
        _curtain = Instantiate(_loadingCurtain);
        DontDestroyOnLoad(_curtain.gameObject);
    }

    private void InitCoroutinRuner()
    {
        GameObject coroutineRunner = Instantiate(new GameObject());
        coroutineRunner.name = "CoroutinRunner";
        
        _coroutineRunner = coroutineRunner.AddComponent<CoroutineRunner>();
        
        DontDestroyOnLoad(coroutineRunner);
    }

}