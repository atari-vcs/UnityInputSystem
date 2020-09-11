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
    [InputControlLayout (stateType = typeof (XControllerBluetoothLayout))]
    public class XControllerBluetooth : Gamepad
    {
        public DpadControl Dpad { get; private set; }
        public ButtonControl Button { get; private set; }

        static XControllerBluetooth ()
        {
            List<string> namesToRegister = InputManager.XInputBluetoothController;

            for (int i = 0; i < namesToRegister.Count; i++)
            {
                InputSystem.RegisterLayout<XControllerBluetooth> (
                matches: new InputDeviceMatcher ()
                    .WithProduct (namesToRegister [i]));
            }
        }

        // In the player, trigger the calling of our static constructor
        // by having an empty method annotated with RuntimeInitializeOnLoadMethod.
        [RuntimeInitializeOnLoadMethod]
        static void Init () { }
    }
}