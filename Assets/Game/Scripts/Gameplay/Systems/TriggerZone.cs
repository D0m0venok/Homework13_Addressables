using System;
using UnityEngine;

namespace SampleGame
{
    public sealed class TriggerZone : MonoBehaviour
    {
        [SerializeField] private int _number;

        public event Action<int, TriggerZone> TriggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out ICharacter character))
                TriggerEnter?.Invoke(_number, this);
        }
    }
}