using TickToe.Core.Enums;
using TMPro;

namespace TickToe.Scripts.UI.Screen.Win
{
    public class WinScreen : UIScreen
    {
        private const string CROSS_WIN_TEXT = "Cross win!";
        private const string CIRCLE_WIN_TEXT = "Cirle win!";
        
        public TextMeshProUGUI WinnerText = null;

        public override void Show(bool state)
        {
            base.Show(state);
            gameObject.SetActive(state);
        }

        public void SetWinner(SignType winnerValue)
        {
            switch (winnerValue)
            {
                case SignType.Cross:
                    WinnerText.text = CROSS_WIN_TEXT;
                    break;
                case SignType.Circle:
                    WinnerText.text = CIRCLE_WIN_TEXT;
                    break;
            }
        }
    }
}