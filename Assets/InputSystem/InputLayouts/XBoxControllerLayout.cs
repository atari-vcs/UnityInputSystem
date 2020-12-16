using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.UnityInputSystem
{
    public struct XBoxControllerLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('G', 'P', 'A', 'D');
        [InputControl (name = "Atari", bit = (uint) 14, offset = 0, displayName = "Atari", layout = "Button")]
        public int button;
    }
}