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

        private InputManager()
        {

        }

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InputManager>();
                }

                return instance;
            }
        }

        #endregion

        #region Object References

        [Space(10)]

        public EventSystem eventSystem;

        public EventSystem InputSystemEventSystem;

        #endregion

        #region Actions

        public static Action<ButtonType, InputSource> OnButtonPressed;

        public static event Action ControllerChange;

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

        public InputSource CurrentInputSource { get; private set; } = InputSource.NONE;

        private bool shouldMoveAxis = false;

        private bool isInputEnabled = false;

        public bool IsInputEnabled
        {
            get
            {
                return isInputEnabled;
            }

            set
            {
                isInputEnabled = value;

                InputSystemEventSystem.sendNavigationEvents = value;
            }
        }

        public bool IsBumperEnabled { get; set; } = false;

        private int moveCount = 0;

        private float DEFAULT_WAIT_TIME = 0.3f;

        private float lastMoveTime = 0;

        private float lastButtonMove = 0;

        private int controllerId = -1;

        private Vector2 myMovement = Vector2.zero;

        //private HashSet<IInputListener> listeners = new HashSet<IInputListener> ();

        #endregion

        private void OnDisable()
        {
            OnButtonPressed = null;
        }

        private void OnEnable()
        {
            isInputEnabled = true;
        }

        #region ControllerMappedLayout

        public void A(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.A, context);
                }
            }
        }

        public void B(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.B, context);
                }
            }
        }
    

        public void X(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.X, context);
                }
            }
        }

        public void Y(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.Y, context);
                }
            }
        }

        public void LeftBumper(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled || IsBumperEnabled)
                {
                    ButtonPressed(ButtonType.LeftBumper, context);
                }
            }
        }

        public void RightBumper(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled || IsBumperEnabled)
                {
                    ButtonPressed(ButtonType.RightBumper, context);
                }
            }
        }

        public void LeftTrigger(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (context.ReadValue<float>() >= 0.99f)
                {
                    if (isInputEnabled)
                    {
                        ButtonPressed(ButtonType.LeftTrigger, context);
                    }
                }
            }
        }

        public void RightTrigger(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (context.ReadValue<float>() >= 0.99f)
                {
                    if (isInputEnabled)
                    {
                        ButtonPressed(ButtonType.RightTrigger, context);
                    }
                }
            }
        }

        public void LeftStick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.LeftStick, context);
                }
            }
        }

        public void RightStick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.RightStick, context);
                }
            }
        }

        public void Back(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.Back, context);
                }
            }
        }

        public void Atari(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.Atari, context);
                }
            }
        }

        public void Menu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (isInputEnabled)
                {
                    ButtonPressed(ButtonType.Menu, context);
                }
            }
        }

        public void Movement(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                myMovement = context.ReadValue<Vector2>();

                myMovement = new Vector2(Mathf.RoundToInt(myMovement.x), Mathf.RoundToInt(myMovement.y));

                if (myMovement.sqrMagnitude > 0)
                {
                    shouldMoveAxis = true;

                    CurrentInputSource = GetInputSource(context);

                    Update();

                    CheckControllerSwitch(context);
                }
                else
                {
                    shouldMoveAxis = false;
                }
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                shouldMoveAxis = false;

                moveCount = 0;

                DEFAULT_WAIT_TIME = 0.3f;

                myMovement = Vector2.zero;
            }
        }

        #endregion

        private void Update()
        {
            if (isInputEnabled)
            {
                if (shouldMoveAxis && Time.time > (lastMoveTime + DEFAULT_WAIT_TIME))
                {
                    if (Mathf.Abs(myMovement.x) > Mathf.Abs(myMovement.y))
                    {
                        if ((myMovement.x) > 0)
                        {
                            OnButtonPressed?.Invoke(ButtonType.Right, CurrentInputSource);
                        }
                        else
                        {
                            OnButtonPressed?.Invoke(ButtonType.Left, CurrentInputSource);
                        }
                    }
                    else
                    {
                        if ((myMovement.y) > 0)
                        {
                            OnButtonPressed?.Invoke(ButtonType.Up, CurrentInputSource);
                        }
                        else
                        {
                            OnButtonPressed?.Invoke(ButtonType.Down, CurrentInputSource);
                        }
                    }

                    moveCount++;

                    if (moveCount > 1)
                    {
                        DEFAULT_WAIT_TIME = 0.15f;
                    }

                    lastMoveTime = Time.time;
                }
            }
        }

        private void ButtonPressed(ButtonType buttonType, InputAction.CallbackContext context)
        {
            CurrentInputSource = GetInputSource(context);

            OnButtonPressed?.Invoke(buttonType, CurrentInputSource);

            CheckControllerSwitch(context);
        }

        private InputSource GetInputSource(InputAction.CallbackContext context)
        {
            if (context.control == null)
            {
                Debug.LogErrorFormat("<InputManager/GetInputSource> Context.Control ({0})", "Null");

                return InputSource.NONE;
            }
            else if (context.control.device == null)
            {
                Debug.LogErrorFormat("<InputManager/GetInputSource> Context.Control.Device ({0})", "Null");

                return InputSource.NONE;
            }

            string current = context.control.device.description.product;

            if (context.control.device.deviceId > 2)
            {
                if (string.IsNullOrEmpty(current))
                {
                    Debug.LogErrorFormat("<InputManager/GetInputSource> Context.Control.Device.Description.Product ({0})", "Null");

                    return InputSource.NONE;
                }

                for (int i = 0; i < modernControllerNames.Count; i++)
                {
                    if (current.Equals(modernControllerNames[i]))
                    {
                        return InputSource.MODERN_CONTROLLER;
                    }
                }

                for (int i = 0; i < classicJoystickNames.Count; i++)
                {
                    if (current.Equals(classicJoystickNames[i]))
                    {
                        return InputSource.CLASSIC_JOYSTICK;
                    }
                }

                for (int i = 0; i < XInputController.Count; i++)
                {
                    if (current.Equals(XInputController[i]))
                    {
                        return InputSource.XBOX_CONTROLLER;
                    }
                }

                for (int i = 0; i < XInputBluetoothController.Count; i++)
                {
                    if (current.Equals(XInputBluetoothController[i]))
                    {
                        return InputSource.XBOX_CONTROLLER;
                    }
                }

                return InputSource.GENERIC;
            }
            else
            {
                return InputSource.KEYBOARD_AND_MOUSE;
            }
        }

        private void CheckControllerSwitch(InputAction.CallbackContext context)
        {
            if (context.control == null)
            {
                return;
            }
            else if (context.control.device == null)
            {
                return;
            }

            if (!controllerId.Equals(context.control.device.deviceId))
            {
                controllerId = context.control.device.deviceId;

                ControllerChange?.Invoke();
            }
        }
    }
}