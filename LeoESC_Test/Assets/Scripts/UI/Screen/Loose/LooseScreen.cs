using TickToe.Scripts.UI.Screen;

namespace TickToe.UI.Screen.Loose
{
    public class LooseScreen : UIScreen
    {
        public override void Show(bool state)
        {
            base.Show(state);
            
            gameObject.SetActive(state);
        }
    }
}