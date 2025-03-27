using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterDataLoader>().AsTransient();

        Container.Bind<CharacterFactory>().AsSingle();

        Container.Bind<SaveSystem>().AsSingle();
    }
}
