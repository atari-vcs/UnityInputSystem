namespace Atari.VCS.UnityInputManager
{
    public class ClassicJoystick : ControllerInterface
    {
        public ButtonType ButtonPressed (string button, float value)
        {
            ButtonType buttonType = ButtonType.None;

            switch (button)
            {
                case "Button 0":

                buttonType = ButtonType.A;

                break;

                case "Button 1":

                buttonType = ButtonType.B;

                break;

                case "Button 2":

                buttonType = ButtonType.Back;

                break;

                case "Button 3":

                buttonType = ButtonType.Menu;

                break;

                case "Button 4":

                buttonType = ButtonType.Atari;

                break;

                case "Axis 2":

                buttonType = value > 0 ? ButtonType.Right : ButtonType.Left;

                break;

                case "Axis 3":

                buttonType = value > 0 ? ButtonType.Down : ButtonType.Up;

                break;
            }

            return buttonType;
        }
    }
}