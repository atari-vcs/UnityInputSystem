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

        private void ButtonPressed (ButtonType button,InputSource source)
        {
            m_ButtonText.text = string.Format("{0} was pressed \n <size=32>({1})</size>", button.ToString(), source.ToString());
        }
    }
}