using UnityEngine;
using System;

namespace Atari.VCS.UnityInputManager
{
    public class UnityInputManager : MonoBehaviour
    {
        #region Singleton

        private static UnityInputManager instance;

        public static UnityInputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<UnityInputManager> ();
                }

                return instance;
            }
        }

        #endregion

        #region Actions

        public static Action<ButtonType> OnButtonPressed;

        #endregion

        #region Variables

        private ControllerInterface controllerInterface = new ModernController();// Assigning as Modern Controller on Launch

        private bool enabledClassicJoystick = false;

        #endregion

        private void Update ()
        {
            string [] connectedJoysticks = Input.GetJoystickNames ();

            ButtonType button = ButtonType.None;

            for (int a = 1; a < 9; a++)
            {
                float movement = Input.GetAxis (string.Format ("Axis {0}", a));

                if (movement != 0)
                {
                    button = controllerInterface.ButtonPressed (string.Format ("Axis {0}", a), movement);

                    if (button != ButtonType.None)
                    {
                        OnButtonPressed?.Invoke (button);
                    }
                }
            }

            for (int b = 0; b < 11; b++)
            {
                if (Input.GetButtonUp (string.Format ("Button {0}", b)))
                {
                    OnButtonPressed?.Invoke (controllerInterface.ButtonPressed (string.Format ("Button {0}", b), -1));
                }
            }
        }

        public bool ToggleControllerInterface ()
        {
            enabledClassicJoystick = !enabledClassicJoystick;

            if (enabledClassicJoystick)
            {
                controllerInterface = new ClassicJoystick ();
            }
            else
            {
                controllerInterface = new ModernController ();
            }

            return enabledClassicJoystick;
        }
    }
}