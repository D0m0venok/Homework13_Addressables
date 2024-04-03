using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SampleGame
{
    public sealed class LocationLoader
    {
        private readonly Transform _parent;
        private readonly Dictionary<int, GameObject> _locations = new ();

        public LocationLoader(Transform parent)
        {
            _parent = parent;
        }
        
        public async UniTaskVoid InstantiateLocation(int locationNumber)
        {
            if(_locations.ContainsKey(locationNumber))
                return;
            
            await Addressables.InstantiateAsync($"Locations/Location{locationNumber}.prefab", _parent);
        }

        public void Unload()
        {
            foreach (var gameObject in _locations.Values)
            {
                Addressables.ReleaseInstance(gameObject);
            }
            
            _locations.Clear();
        }
    }
}