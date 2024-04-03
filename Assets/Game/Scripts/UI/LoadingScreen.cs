using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class LoadingScreen : MonoBehaviour
    {
        private MenuLoader _menuLoader;
        private MenuScreenLoader _menuScreenLoader;
        private PauseScreenLoader _pauseScreenLoader;
        
        [Inject]
        public void Construct(MenuLoader menuLoader, MenuScreenLoader menuScreenLoader, PauseScreenLoader pauseScreenLoader)
        {
            _menuLoader = menuLoader;
            _menuScreenLoader = menuScreenLoader;
            _pauseScreenLoader = pauseScreenLoader;
        }

        private async void Awake()
        {
            await _menuScreenLoader.LoadAsync();
            await _pauseScreenLoader.LoadAsync();
            _menuLoader.LoadMenu().Forget();
        }
    }
}