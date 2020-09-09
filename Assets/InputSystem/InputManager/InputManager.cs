using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Atari.VCS.Dashboard
{
    public class InputManager : MonoBehaviour
    {
        #region Singleton

        private static InputManager instance = null;

        private InputManager ()
        {

        }

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InputManager> ();
                }

                return instance;
            }
        }

        #endregion

        #region Object References

        [Space (10)]

        #endregion

        #region Actions

        public static Action<ButtonType> OnButtonPressed;

        #endregion

        #region Variables

        public static readonly List<string> modernControllerNames = new List<string>
        {
            "Keyboard Hub",
        };

        public static readonly List<string> classicJoystickNames = new List<string>
        {
            "Cetus CDC Device"
        };

        public static readonly List<string> XInputController = new List<string>
        {
            "PlayStation 3 Memory Card Adaptor",
            "Xbox360 Controller"
        };

        public static readonly List<string> XInputBluetoothController = new List<string>
        {
            "DCP-J152N"
        };

        private Vector2 myMovement = Vector2.zero;

        private bool shouldMoveAxis = false;

        #endregion

        private void OnDisable ()
        {
            OnButtonPressed = null;
        }

        #region ControllerMappedLayout

        public void A (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                 {
                     OnButtonPressed?.Invoke (ButtonType.A);

                 }, context);
            }
        }

        public void B (InputAction.CallbackContext context)
        {
            // The Variation here in comparison to other button methods is for B Buttons' Backspace repeatability in Keyboard
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.B);

                }, context);
            }
        }

        public void X (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.X);
                }, context);
            }
        }

        public void Y (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.Y);
                }, context);
            }
        }

        public void LeftBumper (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.LeftBumper);
                }, context);
            }
        }

        public void RightBumper (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.RightBumper);
                }, context);
            }
        }

        public void LeftTrigger (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    if ((context.ReadValue<float> ()) >= 0.99f)
                    {
                        OnButtonPressed?.Invoke (ButtonType.LeftTrigger);
                    }

                }, context);
            }
        }

        public void RightTrigger (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    if ((context.ReadValue<float> ()) >= 0.99f)
                    {
                        OnButtonPressed?.Invoke (ButtonType.RightTrigger);
                    }
                }, context);
            }
        }

        public void LeftStick (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.LeftStick);

                }, context);
            }
        }

        public void RightStick (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.RightStick);

                }, context);
            }
        }

        public void Back (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    OnButtonPressed?.Invoke (ButtonType.Back);

                }, context);
            }
        }

        public void Menu (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {

                    OnButtonPressed?.Invoke (ButtonType.Menu);


                }, context);
            }
        }
        public void Atari (InputAction.CallbackContext context)
        {

            if (context.phase == InputActionPhase.Performed)
            {
                AtariButtonControl (context);
            }

        }

        public void Movement (InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PerformInputAction (() =>
                {
                    myMovement = context.ReadValue<Vector2> ();

                    myMovement = new Vector2 (Mathf.RoundToInt (myMovement.x), Mathf.RoundToInt (myMovement.y));

                    if (myMovement.sqrMagnitude > 0)
                    {
                        shouldMoveAxis = true;
                    }
                    else
                    {
                        shouldMoveAxis = false;
                    }

                }, context);
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                myMovement = Vector2.zero;

                shouldMoveAxis = false;
            }
        }

        #endregion

        private void Update ()
        {
            if (shouldMoveAxis)
            {
                if (Mathf.Abs (myMovement.x) > Mathf.Abs (myMovement.y))
                {
                    if (Mathf.RoundToInt (myMovement.x) > 0)
                    {
                        OnButtonPressed?.Invoke (ButtonType.Right);
                    }
                    else
                    {
                        OnButtonPressed?.Invoke (ButtonType.Left);
                    }
                }
                else
                {
                    if (Mathf.RoundToInt (myMovement.y) > 0)
                    {
                        OnButtonPressed?.Invoke (ButtonType.Up);
                    }
                    else
                    {
                        OnButtonPressed?.Invoke (ButtonType.Down);
                    }
                }
            }
        }

        private void AtariButtonControl (InputAction.CallbackContext context, bool toSwitch = true)
        {
            PerformInputAction (() =>
            {
                OnButtonPressed?.Invoke (ButtonType.Atari);

            }, context);
        }

        private void PerformInputAction (Action callback, InputAction.CallbackContext context)
        {
            callback?.Invoke ();
        }
    }
}