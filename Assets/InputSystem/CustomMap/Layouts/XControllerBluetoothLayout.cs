using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.Dashboard
{
    public class XControllerBluetoothLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('G', 'P', 'A', 'D');
        [InputControl (name = "atari", bit = (uint) 8, offset = 0, displayName = "Atari", layout = "Button")]
        [InputControl (name = "leftStickPress", bit = (uint) 9, offset = 0, displayName = "Left Stick Press", layout = "Button")]
        [InputControl (name = "rightStickPress", bit = (uint) 14, offset = 0, displayName = "Right Stick Press", layout = "Button")]
        public int button;
    }
}
