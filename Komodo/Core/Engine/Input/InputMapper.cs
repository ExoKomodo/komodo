using Microsoft.Xna.Framework.Input;

namespace Komodo.Core.Engine.Input
{
    internal static class InputMapper
    {
        #region Members

        #region Public Members
        #endregion Public Members
        
        #region Protected Members
        #endregion Protected Members
        
        #region Private Members
        #endregion Private Members

        #endregion Members

        #region Member Methods
        
        #region Public Member Methods
        public static KomodoInputs ToKomodoInput(Keys key)
        {
            switch (key)
            {
                case Keys.A:
                    return KomodoInputs.KeyA;
                case Keys.B:
                    return KomodoInputs.KeyB;
                case Keys.Back:
                    return KomodoInputs.KeyBackSpace;
                case Keys.C:
                    return KomodoInputs.KeyC;
                case Keys.CapsLock:
                    return KomodoInputs.KeyCapsLock;
                case Keys.D:
                    return KomodoInputs.KeyD;
                case Keys.Decimal:
                    return KomodoInputs.KeyDecimal;
                case Keys.Delete:
                    return KomodoInputs.KeyDelete;
                case Keys.Down:
                    return KomodoInputs.KeyDown;
                case Keys.E:
                    return KomodoInputs.KeyE;
                case Keys.Enter:
                    return KomodoInputs.KeyEnter;
                case Keys.Escape:
                    return KomodoInputs.KeyEscape;
                case Keys.F:
                    return KomodoInputs.KeyF;
                case Keys.F1:
                    return KomodoInputs.KeyF1;
                case Keys.F10:
                    return KomodoInputs.KeyF10;
                case Keys.F11:
                    return KomodoInputs.KeyF11;
                case Keys.F12:
                    return KomodoInputs.KeyF12;
                case Keys.F2:
                    return KomodoInputs.KeyF2;
                case Keys.F3:
                    return KomodoInputs.KeyF3;
                case Keys.F4:
                    return KomodoInputs.KeyF4;
                case Keys.F5:
                    return KomodoInputs.KeyF5;
                case Keys.F6:
                    return KomodoInputs.KeyF6;
                case Keys.F7:
                    return KomodoInputs.KeyF7;
                case Keys.F8:
                    return KomodoInputs.KeyF8;
                case Keys.F9:
                    return KomodoInputs.KeyF9;
                case Keys.G:
                    return KomodoInputs.KeyG;
                case Keys.H:
                    return KomodoInputs.KeyH;
                case Keys.I:
                    return KomodoInputs.KeyI;
                case Keys.J:
                    return KomodoInputs.KeyJ;
                case Keys.K:
                    return KomodoInputs.KeyK;
                case Keys.L:
                    return KomodoInputs.KeyL;
                case Keys.Left:
                    return KomodoInputs.KeyLeft;
                case Keys.LeftAlt:
                    return KomodoInputs.KeyLeftAlt;
                case Keys.LeftControl:
                    return KomodoInputs.KeyLeftControl;
                case Keys.LeftShift:
                    return KomodoInputs.KeyLeftShift;
                case Keys.M:
                    return KomodoInputs.KeyM;
                case Keys.N:
                    return KomodoInputs.KeyN;
                case Keys.O:
                    return KomodoInputs.KeyO;
                case Keys.P:
                    return KomodoInputs.KeyP;
                case Keys.Q:
                    return KomodoInputs.KeyQ;
                case Keys.R:
                    return KomodoInputs.KeyR;
                case Keys.Right:
                    return KomodoInputs.KeyRight;
                case Keys.RightAlt:
                    return KomodoInputs.KeyRightAlt;
                case Keys.RightControl:
                    return KomodoInputs.KeyRightControl;
                case Keys.RightShift:
                    return KomodoInputs.KeyRightShift;
                case Keys.S:
                    return KomodoInputs.KeyS;
                case Keys.T:
                    return KomodoInputs.KeyT;
                case Keys.Tab:
                    return KomodoInputs.KeyTab;
                case Keys.U:
                    return KomodoInputs.KeyU;
                case Keys.Up:
                    return KomodoInputs.KeyUp;
                case Keys.V:
                    return KomodoInputs.KeyV;
                case Keys.W:
                    return KomodoInputs.KeyW;
                case Keys.X:
                    return KomodoInputs.KeyX;
                case Keys.Y:
                    return KomodoInputs.KeyY;
                case Keys.Z:
                    return KomodoInputs.KeyZ;
                default:
                    return KomodoInputs.Undefined;
            }
        }
        
        public static KomodoInputs ToKomodoInput(Buttons button)
        {
            switch (button)
            {
                case Buttons.A:
                    return KomodoInputs.ButtonA;
                case Buttons.B:
                    return KomodoInputs.ButtonB;
                case Buttons.DPadDown:
                    return KomodoInputs.ButtonDown;
                case Buttons.BigButton:
                    return KomodoInputs.ButtonHome;
                case Buttons.LeftShoulder:
                    return KomodoInputs.ButtonL1;
                case Buttons.LeftTrigger:
                    return KomodoInputs.ButtonL2;
                case Buttons.LeftStick:
                    return KomodoInputs.ButtonL3;
                case Buttons.DPadLeft:
                    return KomodoInputs.ButtonLeft;
                case Buttons.RightShoulder:
                    return KomodoInputs.ButtonR1;
                case Buttons.RightTrigger:
                    return KomodoInputs.ButtonR2;
                case Buttons.RightStick:
                    return KomodoInputs.ButtonR3;
                case Buttons.DPadRight:
                    return KomodoInputs.ButtonRight;
                case Buttons.Back:
                    return KomodoInputs.ButtonSelect;
                case Buttons.Start:
                    return KomodoInputs.ButtonStart;
                case Buttons.DPadUp:
                    return KomodoInputs.ButtonUp;
                case Buttons.X:
                    return KomodoInputs.ButtonX;
                case Buttons.Y:
                    return KomodoInputs.ButtonY;
                default:
                    return KomodoInputs.Undefined;
            }
        }

        public static InputState ToKomodoInputState(KeyState keyState)
        {
            switch (keyState)
            {
                case KeyState.Up:
                    return InputState.Up;
                case KeyState.Down:
                    return InputState.Down;
                default:
                    return InputState.Undefined;
            }
        }

        public static InputState ToKomodoInputState(ButtonState buttonState)
        {
            switch (buttonState)
            {
                case ButtonState.Released:
                    return InputState.Up;
                case ButtonState.Pressed:
                    return InputState.Down;
                default:
                    return InputState.Undefined;
            }
        }

        public static Buttons? ToMonoGameButton(KomodoInputs input)
        {
            switch (input)
            {
                case KomodoInputs.ButtonA:
                    return Buttons.A;
                case KomodoInputs.ButtonB:
                    return Buttons.B;
                case KomodoInputs.ButtonDown:
                    return Buttons.DPadDown;
                case KomodoInputs.ButtonHome:
                    return Buttons.BigButton;
                case KomodoInputs.ButtonL1:
                    return Buttons.LeftShoulder;
                case KomodoInputs.ButtonL2:
                    return Buttons.LeftTrigger;
                case KomodoInputs.ButtonL3:
                    return Buttons.LeftStick;
                case KomodoInputs.ButtonLeft:
                    return Buttons.DPadLeft;
                case KomodoInputs.ButtonR1:
                    return Buttons.RightShoulder;
                case KomodoInputs.ButtonR2:
                    return Buttons.RightTrigger;
                case KomodoInputs.ButtonR3:
                    return Buttons.RightStick;
                case KomodoInputs.ButtonRight:
                    return Buttons.DPadRight;
                case KomodoInputs.ButtonSelect:
                    return Buttons.Back;
                case KomodoInputs.ButtonStart:
                    return Buttons.Start;
                case KomodoInputs.ButtonUp:
                    return Buttons.DPadUp;
                case KomodoInputs.ButtonX:
                    return Buttons.X;
                case KomodoInputs.ButtonY:
                    return Buttons.Y;
                default:
                    return null;
            }
        }
        
        public static Keys? ToMonoGameKey(KomodoInputs input)
        {
            switch (input)
            {
                case KomodoInputs.KeyA:
                    return Keys.A;
                case KomodoInputs.KeyB:
                    return Keys.B;
                case KomodoInputs.KeyBackSpace:
                    return Keys.Back;
                case KomodoInputs.KeyC:
                    return Keys.C;
                case KomodoInputs.KeyCapsLock:
                    return Keys.CapsLock;
                case KomodoInputs.KeyD:
                    return Keys.D;
                case KomodoInputs.KeyDecimal:
                    return Keys.Decimal;
                case KomodoInputs.KeyDelete:
                    return Keys.Delete;
                case KomodoInputs.KeyDown:
                    return Keys.Down;
                case KomodoInputs.KeyE:
                    return Keys.E;
                case KomodoInputs.KeyEnter:
                    return Keys.Enter;
                case KomodoInputs.KeyEscape:
                    return Keys.Escape;
                case KomodoInputs.KeyF:
                    return Keys.F;
                case KomodoInputs.KeyF1:
                    return Keys.F1;
                case KomodoInputs.KeyF10:
                    return Keys.F10;
                case KomodoInputs.KeyF11:
                    return Keys.F11;
                case KomodoInputs.KeyF12:
                    return Keys.F12;
                case KomodoInputs.KeyF2:
                    return Keys.F2;
                case KomodoInputs.KeyF3:
                    return Keys.F3;
                case KomodoInputs.KeyF4:
                    return Keys.F4;
                case KomodoInputs.KeyF5:
                    return Keys.F5;
                case KomodoInputs.KeyF6:
                    return Keys.F6;
                case KomodoInputs.KeyF7:
                    return Keys.F7;
                case KomodoInputs.KeyF8:
                    return Keys.F8;
                case KomodoInputs.KeyF9:
                    return Keys.F9;
                case KomodoInputs.KeyG:
                    return Keys.G;
                case KomodoInputs.KeyH:
                    return Keys.H;
                case KomodoInputs.KeyI:
                    return Keys.I;
                case KomodoInputs.KeyJ:
                    return Keys.J;
                case KomodoInputs.KeyK:
                    return Keys.K;
                case KomodoInputs.KeyL:
                    return Keys.L;
                case KomodoInputs.KeyLeft:
                    return Keys.Left;
                case KomodoInputs.KeyLeftAlt:
                    return Keys.LeftAlt;
                case KomodoInputs.KeyLeftControl:
                    return Keys.LeftControl;
                case KomodoInputs.KeyLeftShift:
                    return Keys.LeftShift;
                case KomodoInputs.KeyM:
                    return Keys.M;
                case KomodoInputs.KeyN:
                    return Keys.N;
                case KomodoInputs.KeyO:
                    return Keys.O;
                case KomodoInputs.KeyP:
                    return Keys.P;
                case KomodoInputs.KeyQ:
                    return Keys.Q;
                case KomodoInputs.KeyR:
                    return Keys.R;
                case KomodoInputs.KeyRight:
                    return Keys.Right;
                case KomodoInputs.KeyRightAlt:
                    return Keys.RightAlt;
                case KomodoInputs.KeyRightControl:
                    return Keys.RightControl;
                case KomodoInputs.KeyRightShift:
                    return Keys.RightShift;
                case KomodoInputs.KeyS:
                    return Keys.S;
                case KomodoInputs.KeyT:
                    return Keys.T;
                case KomodoInputs.KeyTab:
                    return Keys.Tab;
                case KomodoInputs.KeyU:
                    return Keys.U;
                case KomodoInputs.KeyUp:
                    return Keys.Up;
                case KomodoInputs.KeyV:
                    return Keys.V;
                case KomodoInputs.KeyW:
                    return Keys.W;
                case KomodoInputs.KeyX:
                    return Keys.X;
                case KomodoInputs.KeyY:
                    return Keys.Y;
                case KomodoInputs.KeyZ:
                    return Keys.Z;
                default:
                    return null;
            }
        }
        #endregion Public Member Methods
        
        #region Protected Member Methods
        #endregion Protected Member Methods
        
        #region Private Member Methods
        #endregion Private Member Methods
        
        #endregion Member Methods

        #region Constructors
        #endregion Constructors
    }
}