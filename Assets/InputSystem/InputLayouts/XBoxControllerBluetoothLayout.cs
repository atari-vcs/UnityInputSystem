using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.UnityInputSystem
{
    public class XBoxControllerBluetoothLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('G', 'P', 'A', 'D');
        [InputControl (name = "Atari", bit = (uint) 8, offset = 0, displayName = "Atari", layout = "Button")]
        [InputControl (name = "Left Stick Press", bit = (uint) 9, offset = 0, displayName = "Left Stick Press", layout = "Button")]
        [InputControl (name = "Right Stick Press", bit = (uint) 14, offset = 0, displayName = "Right Stick Press", layout = "Button")]
        public int button;
    }
}