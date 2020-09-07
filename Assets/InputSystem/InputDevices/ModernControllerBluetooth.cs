using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.Dashboard
{
    // The device must be directed to the state struct we have created.
    [InputControlLayout (stateType = typeof (ModernControllerBluetoothLayout))]
    public class ModernControllerBluetooth : InputDevice
    {
        /*
        //public AxisControl axis { get; private set; }
        public ButtonControl button { get; private set; }

        static GameControllerBluetooth ()
        {
            InputSystem.RegisterLayout<GameControllerBluetooth> (matches: new InputDeviceMatcher ().WithProduct ("Rikiki Hard Drive"));
        }

        // In the player, trigger the calling of our static constructor
        // by having an empty method annotated with RuntimeInitializeOnLoadMethod.
        [RuntimeInitializeOnLoadMethod]
        static void Init () { }
        */
    }
}