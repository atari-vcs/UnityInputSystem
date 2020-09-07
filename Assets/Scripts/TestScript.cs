using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Atari.VCS.Dashboard
{
    public class TestScript : MonoBehaviour
    {
        public TextMeshProUGUI m_ButtonText;

        private void Awake ()
        {
            InputManager.OnButtonPressed += ButtonPressed;
        }

        private void OnDestroy ()
        {
            InputManager.OnButtonPressed -= ButtonPressed;
        }

        private void ButtonPressed (ButtonType button)
        {
            m_ButtonText.text = string.Format ("{0} was pressed", button.ToString ());
        }
    }
}