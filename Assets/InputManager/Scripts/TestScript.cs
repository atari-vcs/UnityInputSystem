using UnityEngine;
using TMPro;

namespace Atari.VCS.UnityInputManager
{
    public class TestScript : MonoBehaviour
    {
        public TextMeshProUGUI keyPressedText;

        public TextMeshProUGUI toggleButtonText;

        private void Awake ()
        {
            UnityInputManager.OnButtonPressed += ButtonPressed;
        }

        private void Start ()
        {
            UpdateText (false);
        }

        private void OnDestroy ()
        {
            UnityInputManager.OnButtonPressed -= ButtonPressed;
        }

        private void ButtonPressed (ButtonType button, float value)
        {
            keyPressedText.text = string.Format ("{0} was pressed", button.ToString ());
        }

        public void OnToggleButtonClicked ()
        {
            UpdateText (UnityInputManager.Instance.ToggleControllerInterface ());
        }

        private void UpdateText (bool currentMode)
        {
            toggleButtonText.text = string.Format ("{0} Layout Enabled", currentMode ? "Classic Joystick" : "Modern Controller");
        }
    }
}