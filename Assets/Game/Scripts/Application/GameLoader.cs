using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace SampleGame
{
    public sealed class GameLoader
    {
        private SceneInstance _sceneInstance;
        
        //TODO: Сделать через Addressables
        public void UnloadGame()
        {
            Addressables.UnloadSceneAsync(_sceneInstance);
        }
        
        //TODO: Сделать через Addressables
        public async void LoadGame()
        {
            _sceneInstance = await Addressables.LoadSceneAsync("Game").Task;
        }
    }
}