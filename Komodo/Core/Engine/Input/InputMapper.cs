using Buttons = Microsoft.Xna.Framework.Input.Buttons;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using KeyState = Microsoft.Xna.Framework.Input.KeyState;

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
        public static Inputs ToKomodoInput(Keys key)
        {
            return key switch
            {
                Keys.A => Inputs.KeyA,
                Keys.B => Inputs.KeyB,
                Keys.Back => Inputs.KeyBackSpace,
                Keys.C => Inputs.KeyC,
                Keys.CapsLock => Inputs.KeyCapsLock,
                Keys.D => Inputs.KeyD,
                Keys.Decimal => Inputs.KeyDecimal,
                Keys.Delete => Inputs.KeyDelete,
                Keys.Down => Inputs.KeyDown,
                Keys.E => Inputs.KeyE,
                Keys.Enter => Inputs.KeyEnter,
                Keys.Escape => Inputs.KeyEscape,
                Keys.F => Inputs.KeyF,
                Keys.F1 => Inputs.KeyF1,
                Keys.F10 => Inputs.KeyF10,
                Keys.F11 => Inputs.KeyF11,
                Keys.F12 => Inputs.KeyF12,
                Keys.F2 => Inputs.KeyF2,
                Keys.F3 => Inputs.KeyF3,
                Keys.F4 => Inputs.KeyF4,
                Keys.F5 => Inputs.KeyF5,
                Keys.F6 => Inputs.KeyF6,
                Keys.F7 => Inputs.KeyF7,
                Keys.F8 => Inputs.KeyF8,
                Keys.F9 => Inputs.KeyF9,
                Keys.G => Inputs.KeyG,
                Keys.H => Inputs.KeyH,
                Keys.I => Inputs.KeyI,
                Keys.J => Inputs.KeyJ,
                Keys.K => Inputs.KeyK,
                Keys.L => Inputs.KeyL,
                Keys.Left => Inputs.KeyLeft,
                Keys.LeftAlt => Inputs.KeyLeftAlt,
                Keys.LeftControl => Inputs.KeyLeftControl,
                Keys.LeftShift => Inputs.KeyLeftShift,
                Keys.M => Inputs.KeyM,
                Keys.N => Inputs.KeyN,
                Keys.O => Inputs.KeyO,
                Keys.P => Inputs.KeyP,
                Keys.Q => Inputs.KeyQ,
                Keys.R => Inputs.KeyR,
                Keys.Right => Inputs.KeyRight,
                Keys.RightAlt => Inputs.KeyRightAlt,
                Keys.RightControl => Inputs.KeyRightControl,
                Keys.RightShift => Inputs.KeyRightShift,
                Keys.S => Inputs.KeyS,
                Keys.T => Inputs.KeyT,
                Keys.Tab => Inputs.KeyTab,
                Keys.U => Inputs.KeyU,
                Keys.Up => Inputs.KeyUp,
                Keys.V => Inputs.KeyV,
                Keys.W => Inputs.KeyW,
                Keys.X => Inputs.KeyX,
                Keys.Y => Inputs.KeyY,
                Keys.Z => Inputs.KeyZ,
                _ => Inputs.Undefined,
            };
        }
        
        public static Inputs ToKomodoInput(Buttons button)
        {
            return button switch
            {
                Buttons.A => Inputs.ButtonA,
                Buttons.B => Inputs.ButtonB,
                Buttons.DPadDown => Inputs.ButtonDown,
                Buttons.BigButton => Inputs.ButtonHome,
                Buttons.LeftShoulder => Inputs.ButtonL1,
                Buttons.LeftTrigger => Inputs.ButtonL2,
                Buttons.LeftStick => Inputs.ButtonL3,
                Buttons.DPadLeft => Inputs.ButtonLeft,
                Buttons.RightShoulder => Inputs.ButtonR1,
                Buttons.RightTrigger => Inputs.ButtonR2,
                Buttons.RightStick => Inputs.ButtonR3,
                Buttons.DPadRight => Inputs.ButtonRight,
                Buttons.Back => Inputs.ButtonSelect,
                Buttons.Start => Inputs.ButtonStart,
                Buttons.DPadUp => Inputs.ButtonUp,
                Buttons.X => Inputs.ButtonX,
                Buttons.Y => Inputs.ButtonY,
                _ => Inputs.Undefined,
            };
        }

        public static InputState ToKomodoInputState(KeyState keyState)
        {
            return keyState switch
            {
                KeyState.Up => InputState.Up,
                KeyState.Down => InputState.Down,
                _ => InputState.Undefined,
            };
        }

        public static InputState ToKomodoInputState(ButtonState buttonState)
        {
            return buttonState switch
            {
                ButtonState.Released => InputState.Up,
                ButtonState.Pressed => InputState.Down,
                _ => InputState.Undefined,
            };
        }

        public static Buttons? ToMonoGameButton(Inputs input)
        {
            return input switch
            {
                Inputs.ButtonA => Buttons.A,
                Inputs.ButtonB => Buttons.B,
                Inputs.ButtonDown => Buttons.DPadDown,
                Inputs.ButtonHome => Buttons.BigButton,
                Inputs.ButtonL1 => Buttons.LeftShoulder,
                Inputs.ButtonL2 => Buttons.LeftTrigger,
                Inputs.ButtonL3 => Buttons.LeftStick,
                Inputs.ButtonLeft => Buttons.DPadLeft,
                Inputs.ButtonR1 => Buttons.RightShoulder,
                Inputs.ButtonR2 => Buttons.RightTrigger,
                Inputs.ButtonR3 => Buttons.RightStick,
                Inputs.ButtonRight => Buttons.DPadRight,
                Inputs.ButtonSelect => Buttons.Back,
                Inputs.ButtonStart => Buttons.Start,
                Inputs.ButtonUp => Buttons.DPadUp,
                Inputs.ButtonX => Buttons.X,
                Inputs.ButtonY => Buttons.Y,
                _ => null,
            };
        }
        
        public static Keys? ToMonoGameKey(Inputs input)
        {
            return input switch
            {
                Inputs.KeyA => Keys.A,
                Inputs.KeyB => Keys.B,
                Inputs.KeyBackSpace => Keys.Back,
                Inputs.KeyC => Keys.C,
                Inputs.KeyCapsLock => Keys.CapsLock,
                Inputs.KeyD => Keys.D,
                Inputs.KeyDecimal => Keys.Decimal,
                Inputs.KeyDelete => Keys.Delete,
                Inputs.KeyDown => Keys.Down,
                Inputs.KeyE => Keys.E,
                Inputs.KeyEnter => Keys.Enter,
                Inputs.KeyEscape => Keys.Escape,
                Inputs.KeyF => Keys.F,
                Inputs.KeyF1 => Keys.F1,
                Inputs.KeyF10 => Keys.F10,
                Inputs.KeyF11 => Keys.F11,
                Inputs.KeyF12 => Keys.F12,
                Inputs.KeyF2 => Keys.F2,
                Inputs.KeyF3 => Keys.F3,
                Inputs.KeyF4 => Keys.F4,
                Inputs.KeyF5 => Keys.F5,
                Inputs.KeyF6 => Keys.F6,
                Inputs.KeyF7 => Keys.F7,
                Inputs.KeyF8 => Keys.F8,
                Inputs.KeyF9 => Keys.F9,
                Inputs.KeyG => Keys.G,
                Inputs.KeyH => Keys.H,
                Inputs.KeyI => Keys.I,
                Inputs.KeyJ => Keys.J,
                Inputs.KeyK => Keys.K,
                Inputs.KeyL => Keys.L,
                Inputs.KeyLeft => Keys.Left,
                Inputs.KeyLeftAlt => Keys.LeftAlt,
                Inputs.KeyLeftControl => Keys.LeftControl,
                Inputs.KeyLeftShift => Keys.LeftShift,
                Inputs.KeyM => Keys.M,
                Inputs.KeyN => Keys.N,
                Inputs.KeyO => Keys.O,
                Inputs.KeyP => Keys.P,
                Inputs.KeyQ => Keys.Q,
                Inputs.KeyR => Keys.R,
                Inputs.KeyRight => Keys.Right,
                Inputs.KeyRightAlt => Keys.RightAlt,
                Inputs.KeyRightControl => Keys.RightControl,
                Inputs.KeyRightShift => Keys.RightShift,
                Inputs.KeyS => Keys.S,
                Inputs.KeyT => Keys.T,
                Inputs.KeyTab => Keys.Tab,
                Inputs.KeyU => Keys.U,
                Inputs.KeyUp => Keys.Up,
                Inputs.KeyV => Keys.V,
                Inputs.KeyW => Keys.W,
                Inputs.KeyX => Keys.X,
                Inputs.KeyY => Keys.Y,
                Inputs.KeyZ => Keys.Z,
                _ => null,
            };
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