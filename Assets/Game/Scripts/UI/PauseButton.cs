using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;
        
        private PauseScreen pauseScreen;

        [Inject]
        public void Construct(PauseScreen pauseScreen)
        {
            this.pauseScreen = pauseScreen;
        }
        
        private void OnEnable()
        {
            this.button.onClick.AddListener(this.pauseScreen.Show);
        }

        private void OnDisable()
        {
            this.button.onClick.RemoveListener(this.pauseScreen.Show);
        }
    }
}