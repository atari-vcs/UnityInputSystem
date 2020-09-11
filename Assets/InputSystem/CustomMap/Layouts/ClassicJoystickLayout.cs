
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.Dashboard
{
    public struct ClassicJoystickLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('L', 'J', 'O', 'Y');

        [InputControl (name = "SelectButton", layout = "Button", bit = 0, offset = 0)]
        [InputControl (name = "B", layout = "Button", bit = 1, offset = 0)]
        [InputControl (name = "Back", layout = "Button", bit = 2, offset = 0)]
        [InputControl (name = "Atari", layout = "Button", bit = 4, offset = 0)]
        [InputControl (name = "Menu", layout = "Button", bit = 3, offset = 0)]

        [InputControl (name = "A_HAT", layout = "Dpad", format = "BIT", offset = 8, bit = 0, sizeInBits = 64)]
        [InputControl (name = "A_HAT/y", offset = 4, bit = 0, format = "BIT", sizeInBits = 64,
            parameters = "clamp=1,clampMin=-1,clampMax=1,invert")]
        [InputControl (name = "A_HAT/up", offset = 4, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=2147483647,invert")]
        [InputControl (name = "A_HAT/down", offset = 4, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=2147483647")]
        [InputControl (name = "A_HAT/x", offset = 0, bit = 0, format = "BIT", sizeInBits = 64,
            parameters = "clamp =1,clampMin=-1,clampMax=1")]
        [InputControl (name = "A_HAT/left", offset = 0, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=2147483647,invert")]
        [InputControl (name = "A_HAT/right", offset = 0, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=2147483647")]

        public int buttons;
    }
}
