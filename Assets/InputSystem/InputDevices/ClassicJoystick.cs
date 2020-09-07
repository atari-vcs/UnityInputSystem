using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.Dashboard
{
    // The device must be directed to the state struct we have created.
    [InputControlLayout (stateType = typeof (ClassicJoystickLayout))]
    public class ClassicJoystick : Joystick
    {
        public DpadControl Dpad { get; private set; }
        public ButtonControl Button { get; private set; }

        static ClassicJoystick ()
        {
            List<string> namesToRegister = InputManager.classicJoystickNames;

            for (int i = 0; i < namesToRegister.Count; i++)
            {
                InputSystem.RegisterLayout<ClassicJoystick> (matches: new InputDeviceMatcher ().WithProduct (namesToRegister [i]));
            }
        }

        // In the player, trigger the calling of our static constructor
        // by having an empty method annotated with RuntimeInitializeOnLoadMethod.
        [RuntimeInitializeOnLoadMethod]
        static void Init () { }
    }
}