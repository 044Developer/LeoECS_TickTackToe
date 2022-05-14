using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TickToe.Scripts.UI.Screen
{
    public class UIScreen : MonoBehaviour, IUIScreen
    {
        public Button RestartButton = null;
        
        private void Awake()
        {
            RestartButton.onClick.AddListener(OnRestartButtonClick);
        }

        public virtual void Show(bool state)
        {
        }

        private void OnRestartButtonClick()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDestroy()
        {
            RestartButton.onClick.RemoveListener(OnRestartButtonClick);
        }
    }
}