using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using System.Collections.Generic;

namespace Atari.VCS.Dashboard
{
    // The device must be directed to the state struct we have created.
    [InputControlLayout (stateType = typeof (GameControllerLayout))]
    public class GameController : Joystick
    {
        public StickControl LeftAxis { get; private set; }
        public StickControl RightAxis { get; private set; }
        public ButtonControl Button { get; private set; }
        public DpadControl Dpad { get; private set; }

        protected override void FinishSetup ()
        {
            LeftAxis = GetChildControl<StickControl> ("Joystick");
            RightAxis = GetChildControl<StickControl> ("RightJoystick");
            Dpad = GetChildControl<DpadControl> ("A_HAT");
            base.FinishSetup ();

        }

        static GameController ()
        {
            List<string> namesToRegister = InputManager.modernControllerNames;

            for(int i =0;i<namesToRegister.Count;i++)
            {
                InputSystem.RegisterLayout<GameController> (
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
