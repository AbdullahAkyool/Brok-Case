using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<CharacterFactory>().AsSingle();

        Container.Bind<SaveSystem>().AsSingle();
    }
}
