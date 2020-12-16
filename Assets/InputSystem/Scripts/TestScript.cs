using UnityEngine;
using TMPro;

namespace Atari.VCS.UnityInputSystem
{
    public class TestScript : MonoBehaviour
    {
        public TextMeshProUGUI keyPressedText;

        private void Awake ()
        {
            UnityInputSystem.OnButtonPressed += ButtonPressed;
        }

        private void OnDestroy ()
        {
            UnityInputSystem.OnButtonPressed -= ButtonPressed;
        }

        private void ButtonPressed (ButtonType button, InputSource source)
        {
            keyPressedText.text = string.Format ("{0} was pressed \n<size=32>({1})</size>", button.ToString (), source.ToString ());
        }
    }
}