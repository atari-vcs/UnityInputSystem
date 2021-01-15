using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

namespace Atari.VCS.Demo.LocalMultiplayer
{
    public class Player : MonoBehaviour
    {
        private Vector2 myMovement = Vector2.zero;

        private InputSource CurrentInputSource = InputSource.NONE;

        public event Action<ButtonType, InputSource> OnButtonPressed;

        private Rigidbody2D rb2d;

        private SpriteRenderer spriteRenderer;

        private Transform myTransform;

        private Vector3 screenBounds;

        private int _Score = 0;

        public TextMeshPro scoreText;

        private void Awake()
        {
            rb2d = this.GetComponent<Rigidbody2D>();

            spriteRenderer = this.GetComponent<SpriteRenderer>();

            myTransform = this.GetComponent<Transform>();

            UpdatePlayerScore(0);
        }

        public void UpdatePlayerScore(int x)
        {
            _Score += x;

            scoreText.text = _Score.ToString();
        }

        private void Start()
        {
            screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

            Debug.LogError(screenBounds);
        }

        public void SetColor(Color _color)
        {
            if (spriteRenderer == null)
            {
                spriteRenderer = this.GetComponent<SpriteRenderer>();
            }
            spriteRenderer.color = _color;
        }

        public Color GetColor()
        {
            if (spriteRenderer != null)
                return spriteRenderer.color;

            return Color.white;
        }

        #region ControllerMappedLayout
        public void A(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.A, context);
            }
        }

        public void B(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.B, context);
            }
        }


        public void X(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.X, context);
            }
        }

        public void Y(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.Y, context);
            }
        }

        public void LeftBumper(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.LeftBumper, context);
            }
        }

        public void RightBumper(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {

                ButtonPressed(ButtonType.RightBumper, context);
            }
        }

        public void LeftTrigger(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (context.ReadValue<float>() >= 0.99f)
                {
                    ButtonPressed(ButtonType.LeftTrigger, context);
                }
            }
        }

        public void RightTrigger(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                if (context.ReadValue<float>() >= 0.99f)
                {
                    ButtonPressed(ButtonType.RightTrigger, context);
                }
            }
        }

        public void LeftStick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.LeftStick, context);
            }
        }

        public void RightStick(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.RightStick, context);
            }
        }

        public void Back(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.Back, context);
            }
        }

        public void Atari(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.Atari, context);
            }
        }

        public void Menu(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ButtonPressed(ButtonType.Menu, context);
            }
        }

        public void Movement(InputAction.CallbackContext context)
        {
            myMovement = context.ReadValue<Vector2>();
        }

        #endregion

        private void FixedUpdate()
        {
            myTransform.Translate(myMovement * 0.5f);
        }

        private void LateUpdate()
        {
            Vector2 playerPos;
            playerPos.x = Mathf.Clamp(myTransform.position.x, screenBounds.x * -1 + 0.5f, screenBounds.x - 0.5f);
            playerPos.y = Mathf.Clamp(myTransform.position.y, screenBounds.y * -1 + 0.5f, screenBounds.y - 0.5f);
            myTransform.position = playerPos;
        }

        private void ButtonPressed(ButtonType buttonType, InputAction.CallbackContext context)
        {
            CurrentInputSource = GetInputSource(context);

            OnButtonPressed?.Invoke(buttonType, CurrentInputSource);
        }

        private InputSource GetInputSource(InputAction.CallbackContext context)
        {
            if (context.control == null)
            {
                Debug.LogErrorFormat("<UnityInputSystem/GetInputSource> Context.Control ({0})", "Null");

                return InputSource.NONE;
            }
            else if (context.control.device == null)
            {
                Debug.LogErrorFormat("<UnityInputSystem/GetInputSource> Context.Control.Device ({0})", "Null");

                return InputSource.NONE;
            }

            string current = context.control.device.description.product;

            if (context.control.device.deviceId > 2)
            {
                if (string.IsNullOrEmpty(current))
                {
                    Debug.LogErrorFormat("<UnityInputSystem/GetInputSource> Context.Control.Device.Description.Product ({0})", "Null");

                    return InputSource.NONE;
                }

                for (int i = 0; i < ControllerNames.ControllerName("Modern").Count; i++)
                {
                    if (current.Equals(ControllerNames.ControllerName("Modern")[i]))
                    {
                        return InputSource.MODERN_CONTROLLER;
                    }
                }

                for (int i = 0; i < ControllerNames.ControllerName("Classic").Count; i++)
                {
                    if (current.Equals(ControllerNames.ControllerName("Classic")[i]))
                    {
                        return InputSource.CLASSIC_JOYSTICK;
                    }
                }

                for (int i = 0; i < ControllerNames.ControllerName("Xbox").Count; i++)
                {
                    if (current.Equals(ControllerNames.ControllerName("Xbox")[i]))
                    {
                        return InputSource.XBOX_CONTROLLER;
                    }
                }

                for (int i = 0; i < ControllerNames.ControllerName("XboxBluetooth").Count; i++)
                {
                    if (current.Equals(ControllerNames.ControllerName("XboxBluetooth")[i]))
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Food"))
            {
                UpdatePlayerScore(collision.transform.GetComponent<Food>().FoodBonus);

                FoodSpawner.Instance.RemoveFood(collision.transform.GetComponent<Food>());
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
        }
    }
}