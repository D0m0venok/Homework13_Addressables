using UnityEngine;
using Zenject;

namespace SampleGame.Installers
{
    
    public class MenuInstaller : MonoInstaller
    {
        [SerializeField] private Transform _screenParent;


        public override void InstallBindings()
        {
            var menuScreen = Container.Resolve<MenuScreenLoader>().MenuScreen;
            Container.InstantiatePrefab(menuScreen, _screenParent);
        }
    }
}