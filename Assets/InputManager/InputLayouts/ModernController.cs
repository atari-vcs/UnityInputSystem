namespace Atari.VCS.UnityInputManager
{
    public class ModernController : ControllerInterface
    {
        public ButtonType ButtonPressed (string button, float value)
        {
            ButtonType buttonType = ButtonType.None;

            switch (button)
            {
                case "Axis 1":

                if (value > 0)
                {
                    buttonType = ButtonType.Right;
                }
                else
                {
                    buttonType = ButtonType.Left;
                }

                break;

                case "Axis 2":

                if (value > 0)
                {
                    buttonType = ButtonType.Down;
                }
                else
                {
                    buttonType = ButtonType.Up;
                }

                break;

                case "Axis 3":

                if (value > 0)
                {
                    buttonType = ButtonType.LeftTrigger;
                }

                break;

                case "Axis 4":

                if (value > 0)
                {
                    buttonType = ButtonType.Right;
                }
                else
                {
                    buttonType = ButtonType.Left;
                }
                break;

                case "Axis 5":

                if (value > 0)
                {
                    buttonType = ButtonType.Down;
                }
                else
                {
                    buttonType = ButtonType.Up;
                }
                break;

                case "Axis 6":

                if (value > 0)
                {
                    buttonType = ButtonType.RightTrigger;
                }
                break;

                case "Axis 7":

                if (value > 0)
                {
                    buttonType = ButtonType.Right;
                }
                else
                {
                    buttonType = ButtonType.Left;
                }
                break;

                case "Axis 8":

                if (value > 0)
                {
                    buttonType = ButtonType.Down;
                }
                else
                {
                    buttonType = ButtonType.Up;
                }
                break;

                case "Button 0":

                buttonType = ButtonType.A;

                break;

                case "Button 1":

                buttonType = ButtonType.B;

                break;

                case "Button 2":

                buttonType = ButtonType.Y;

                break;

                case "Button 3":

                buttonType = ButtonType.X;

                break;

                case "Button 4":

                buttonType = ButtonType.LeftBumper;

                break;

                case "Button 5":

                buttonType = ButtonType.RightBumper;

                break;

                case "Button 6":

                buttonType = ButtonType.Back;

                break;

                case "Button 7":

                buttonType = ButtonType.Menu;

                break;

                case "Button 8":

                buttonType = ButtonType.Atari;

                break;

                case "Button 9":

                buttonType = ButtonType.LeftStick;

                break;

                case "Button 10":

                buttonType = ButtonType.RightStick;

                break;
            }

            return buttonType;
        }
    }
}