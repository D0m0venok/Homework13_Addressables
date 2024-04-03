using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public class MenuScreenLoader
    {
        public GameObject MenuScreen { get; private set;}
        
        public async UniTask LoadAsync()
        {
            MenuScreen = await Addressables.LoadAssetAsync<GameObject>("MenuScreen");
        }
    }
}