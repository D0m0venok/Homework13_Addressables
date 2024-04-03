using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public sealed class MenuLoader
    {
        //TODO: Сделать через Addressables
        public async UniTaskVoid LoadMenu()
        {
            await Addressables.LoadSceneAsync("Menu");
        }
    }
}