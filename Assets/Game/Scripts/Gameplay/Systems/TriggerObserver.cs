using System;

namespace SampleGame
{
    public sealed class TriggerObserver : IDisposable
    {
        private readonly TriggerZone[] _triggerZones;
        private readonly LocationLoader _locationLoader;

        public TriggerObserver(TriggerZone[] triggerZones, LocationLoader locationLoader)
        {
            _triggerZones = triggerZones;
            _locationLoader = locationLoader;

            foreach (var triggerZone in _triggerZones)
            {
                triggerZone.TriggerEnter += OnTriggerEnter;
            }
        }

        void IDisposable.Dispose()
        {
            foreach (var triggerZone in _triggerZones)
            {
                triggerZone.TriggerEnter -= OnTriggerEnter;
            }
            _locationLoader.Unload();
        }
        
        private void OnTriggerEnter(int number, TriggerZone triggerZone)
        {
            _locationLoader.InstantiateLocation(number).Forget();
            triggerZone.TriggerEnter -= OnTriggerEnter;
        }
    }
}