using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private CameraConfig cameraConfig;

        [SerializeField]
        private new Camera camera;
        
        [SerializeField]
        private InputConfig inputConfig;
        
        [SerializeField]
        private TriggerZone[] triggerZones;
        
        [SerializeField]
        private Transform locationsParent;
        
        [SerializeField]
        private Transform _screenParent;

        public override void InstallBindings()
        {
            this.Container
                .Bind<Camera>()
                .FromInstance(this.camera);

            this.Container
                .Bind<ICharacter>()
                .FromComponentInHierarchy()
                .AsSingle();

            this.Container
                .BindInterfacesTo<MoveController>()
                .AsCached()
                .NonLazy();
            
            this.Container
                .Bind<IMoveInput>()
                .To<MoveInput>()
                .AsSingle()
                .WithArguments(this.inputConfig)
                .NonLazy();

            this.Container
                .BindInterfacesTo<CameraFollower>()
                .AsCached()
                .WithArguments(this.cameraConfig.cameraOffset)
                .NonLazy();
            
            this.Container
                .Bind<LocationLoader>()
                .AsSingle()
                .WithArguments(this.locationsParent);
            
            this.Container
                .BindInterfacesTo<TriggerObserver>()
                .AsSingle()
                .WithArguments(this.triggerZones)
                .NonLazy();
            
            InstantiatePauseScreen();
        }
        
        private void InstantiatePauseScreen()
        {
            var prefab = Container.Resolve<PauseScreenLoader>().PauseScreen;
            var pauseScreen = Container.InstantiatePrefab(prefab, _screenParent);
            pauseScreen.SetActive(false);
            Container.BindInstance(pauseScreen.GetComponent<PauseScreen>());
        }
    }
}