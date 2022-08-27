using System;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.Coroutines;
using CodeBase.Infrastructure.SaveLoadSystem;
using CodeBase.Logic;
using UnityEngine;
using Zenject;

public class PreloadInstaller : MonoInstaller
{
    [SerializeField] private LoadingCurtain _loadingCurtain;

    private CoroutineRunner _coroutineRunner;
    private LoadingCurtain _curtain;
    private SettingsData _settingsData;

    public override void InstallBindings()
    {
        InitCoroutinRuner();
        InitCurtain();
        InitSettingsData();

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
        Container
            .Bind<SettingsData>()
            .FromInstance(_settingsData)
            .AsSingle()
            .NonLazy();
    }

    private void InitSettingsData()
    {
        if(DataHolder.Load(out SettingsData data))
            _settingsData = data;
        else
            _settingsData = new SettingsData();
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