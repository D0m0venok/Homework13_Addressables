using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public class PauseScreenLoader
    {
        public GameObject PauseScreen { get; private set; }
        
        public async UniTask LoadAsync()
        {
            PauseScreen = await Addressables.LoadAssetAsync<GameObject>("PauseScreen");
        }
    }
}