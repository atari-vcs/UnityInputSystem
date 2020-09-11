using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.Dashboard
{
    public struct GameControllerBluetoothLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('L', 'J', 'O', 'Y');

        [InputControl (name = "A_HAT", layout = "Dpad", format = "BIT", offset = 28, bit = 0, sizeInBits = 64)]//(24 and 28)
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

        public byte Dpad;

        [InputControl (name = "SelectButton", layout = "Button", bit = 0, offset = 0)]
        [InputControl (name = "B", layout = "Button", bit = 1, offset = 0)]
        [InputControl (name = "Back", layout = "Button", bit = 6, offset = 0)]
        [InputControl (name = "Atari", layout = "Button", bit = 0, offset = 1)]
        [InputControl (name = "Menu", layout = "Button", bit = 7, offset = 0)]
        [InputControl (name = "XButton", layout = "Button", bit = 3, offset = 0)]
        [InputControl (name = "YButton", layout = "Button", bit = 2, offset = 0)]
        [InputControl (name = "LeftBumper", layout = "Button", bit = 4, offset = 0)]
        [InputControl (name = "RightBumper", layout = "Button", bit = 5, offset = 0)]
        [InputControl (name = "LeftTrigger", layout = "Button", format = "INT", bit = 0, offset = 12,
        parameters = "clamp =0,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "RightTrigger", layout = "Button", format = "INT", bit = 0, offset = 24,
        parameters = "clamp =0,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "LeftStick", layout = "Button", bit = 1, offset = 1)]
        [InputControl (name = "RightStick", layout = "Button", bit = 2, offset = 1)]

        public int buttons1;

        // Joysticks - Left // Modern 
        [InputControl (name = "Joystick", layout = "Stick", format = "VEC2", offset = 4, sizeInBits = 64, bit = 0)]// (4 and 8)
        [InputControl (name = "Joystick/x", offset = 0, format = "INT",
            parameters = "clamp =1,clampMin=-1,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Joystick/left", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Joystick/right", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Joystick/y", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=1,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Joystick/up", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Joystick/down", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]

        public byte stick1x;
        public byte stick1y;

        //Joystick  - Right //Modern
        [InputControl (name = "RightJoystick", layout = "Stick", format = "VEC2", offset = 16, bit = 0)]//(12 and 16)
        [InputControl (name = "RightJoystick/x", offset = 4, format = "INT",
            parameters = "clamp =1,clampMin=-1,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "RightJoystick/left", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "RightJoystick/right", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "RightJoystick/y", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=1,scale,scaleFactor=65538,invert")]
        [InputControl (name = "RightJoystick/up", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "RightJoystick/down", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]

        public byte stick2x;
        public byte stick2y;
    }
}
