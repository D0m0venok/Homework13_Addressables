using System.Collections.Generic;
using Cysharp.Threading.Tasks;
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
            var tasks = new List<UniTask>
            {
                _menuScreenLoader.LoadAsync(),
                _pauseScreenLoader.LoadAsync()
            };

            await UniTask.WhenAll(tasks);
            _menuLoader.LoadMenu().Forget();
        }
    }
}