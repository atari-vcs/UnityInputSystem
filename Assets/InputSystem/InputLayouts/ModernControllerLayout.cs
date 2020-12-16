using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;

namespace Atari.VCS.UnityInputSystem
{
    public struct ModernControllerLayout : IInputStateTypeInfo
    {
        public FourCC format => new FourCC ('L', 'J', 'O', 'Y');

        [InputControl (name = "D-Pad", layout = "Dpad", format = "BIT", offset = 28, bit = 0, sizeInBits = 64)]// Axis 7 and 8
        [InputControl (name = "D-Pad/y", offset = 4, bit = 0, format = "BIT", sizeInBits = 64,
            parameters = "clamp=1,clampMin=-1,clampMax=1,invert")]
        [InputControl (name = "D-Pad/up", offset = 4, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=2147483647,invert")]
        [InputControl (name = "D-Pad/down", offset = 4, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=2147483647")]
        [InputControl (name = "D-Pad/x", offset = 0, bit = 0, format = "BIT", sizeInBits = 64,
            parameters = "clamp =1,clampMin=-1,clampMax=1")]
        [InputControl (name = "D-Pad/left", offset = 0, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=2147483647,invert")]
        [InputControl (name = "D-Pad/right", offset = 0, bit = 0, format = "INT", sizeInBits = 32,
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=2147483647")]

        public byte Dpad;

        [InputControl (name = "SelectButton", layout = "Button", bit = 0, offset = 0)] // Button 0
        [InputControl (name = "B", layout = "Button", bit = 1, offset = 0)] // Button 1
        [InputControl (name = "Back", layout = "Button", bit = 6, offset = 0)]// Button 6
        [InputControl (name = "Atari", layout = "Button", bit = 8, offset = 0)]// Button 8
        [InputControl (name = "Menu", layout = "Button", bit = 7, offset = 0)]// Button 7
        [InputControl (name = "XButton", layout = "Button", bit = 3, offset = 0)]// Button 3
        [InputControl (name = "YButton", layout = "Button", bit = 2, offset = 0)]// Button 2
        [InputControl (name = "Left Bumper", layout = "Button", bit = 4, offset = 0)]// Button 4
        [InputControl (name = "Right Bumper", layout = "Button", bit = 5, offset = 0)]// Button 5
        [InputControl (name = "Left Trigger", layout = "Button", format = "INT", bit = 0, offset = 12, // Axis 3
        parameters = "clamp =0,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Right Trigger", layout = "Button", format = "INT", bit = 0, offset = 24,// Axis 6
        parameters = "clamp =0,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Left Stick Press", layout = "Button", bit = 9, offset = 0)] // Button 9
        [InputControl (name = "Right Stick Press", layout = "Button", bit = 10, offset = 0)]//Button 10

        public int buttons1;

        // Joysticks - Left // Modern 
        [InputControl (name = "Left Joystick", layout = "Stick", format = "VEC2", offset = 4, sizeInBits = 64, bit = 0)]//Axis X and Axis Y
        [InputControl (name = "Left Joystick/x", offset = 0, format = "INT",
            parameters = "clamp =1,clampMin=-1,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Left Joystick/left", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Left Joystick/right", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Left Joystick/y", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=1,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Left Joystick/up", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Left Joystick/down", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]

        public byte stick1x;
        public byte stick1y;

        //Joystick  - Right //Modern
        [InputControl (name = "Right Joystick", layout = "Stick", format = "VEC2", offset = 16, bit = 0)]// Axis 4 and 5
        [InputControl (name = "Right Joystick/x", offset = 0, format = "INT",
            parameters = "clamp =1,clampMin=-1,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Right Joystick/left", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Right Joystick/right", offset = 0, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        [InputControl (name = "Right Joystick/y", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=1,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Right Joystick/up", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=-1,clampMax=0,scale,scaleFactor=65538,invert")]
        [InputControl (name = "Right Joystick/down", offset = 4, format = "INT",
            parameters = "clamp=1,clampMin=0,clampMax=1,scale,scaleFactor=65538")]
        public byte stick2x;
        public byte stick2y;
    }
}