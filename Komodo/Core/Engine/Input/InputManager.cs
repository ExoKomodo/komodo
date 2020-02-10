using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Komodo.Core.Engine.Input
{
    public static class InputManager
    {
        static InputManager()
        {
            _inputMaps = new Dictionary<string, List<KomodoInputs>>[4];
            for (int i = 0; i < _inputMaps.Length; i++)
            {
                _inputMaps[i] = new Dictionary<string, List<KomodoInputs>>();
            }
            _gamePadStates = new GamePadState[4];
            _previousGamePadStates = new GamePadState[4];
            Update();
        }

        #region Static Members
        
        #region Private Static Members
        private static GamePadState[] _gamePadStates { get; set; }
        private static Dictionary<string, List<KomodoInputs>>[] _inputMaps { get; }
        private static KeyboardState _keyboardState { get; set; }
        private static MouseState _mouseState { get; set; }
        private static GamePadState[] _previousGamePadStates { get; set; }
        private static KeyboardState _previousKeyboardState { get; set; }
        private static MouseState _previousMouseState { get; set; }
        #endregion Private Static Members
        
        #endregion Static Members

        #region Static Methods
        
        #region Public Static Methods
        public static void AddInputMapping(string action, KomodoInputs input, int playerIndex = 0)
        {
            if (!IsValidPlayerIndex(playerIndex))
            {
                return;
            }
            var inputMap = _inputMaps[playerIndex];
            if (!inputMap.ContainsKey(action))
            {
                inputMap[action] = new List<KomodoInputs>();
            }
            var inputList = inputMap[action];
            if (!inputList.Contains(input))
            {
                inputList.Add(input);
            }
        }

        public static InputInfo GetInput(string action, int playerIndex = 0)
        {
            var result = new InputInfo();
            if (IsValidPlayerIndex(playerIndex))
            {
                var inputMap = _inputMaps[playerIndex];
                if (inputMap.ContainsKey(action))
                {
                    var inputList = inputMap[action];
                    // The input map has an implicit priority. The first input in the list
                    // it encounters that is InputState.Down will be the resulting input.
                    foreach (var input in inputList)
                    {
                        var inputInfo = GetInputInfo(input, playerIndex);
                        if (inputInfo.State == InputState.Undefined)
                        {
                            continue;
                        }
                        if (result.State == InputState.Undefined)
                        {
                            result = inputInfo;
                        }
                        if (result.State != InputState.Down && inputInfo.State == InputState.Down)
                        {
                            result = inputInfo;
                        }
                    }
                }
            }
            return result;
        }

        public static KomodoVector2 GetMousePosition()
        {
            var mouseState = Mouse.GetState();
            var position = mouseState.Position;
            return new KomodoVector2(position.X, position.Y);
        }

        public static bool IsValidPlayerIndex(int playerIndex)
        {
            return playerIndex >= 0 && playerIndex <= 3;
        }

        public static void RemoveInputMapping(string action, KomodoInputs input, int playerIndex = 0)
        {
            if (!IsValidPlayerIndex(playerIndex))
            {
                return;
            }
            var inputMap = _inputMaps[playerIndex];
            if (inputMap.ContainsKey(action))
            {
                var inputList = inputMap[action];
                inputList.Remove(input);
            }
        }

        public static void Update()
        {            
            _previousMouseState = _mouseState;
            _previousKeyboardState = _keyboardState;
            _keyboardState = Keyboard.GetState();
            _mouseState = Mouse.GetState();
            
            for (int i = 0; i < 4; i++)
            {
                var playerIndex = GetPlayerIndex(i);

                _previousGamePadStates[i] = _gamePadStates[i];
                _gamePadStates[i] = GamePad.GetState(playerIndex);
            }
        }
        #endregion Public Static Methods
        
        #region Private Static Methods
        private static InputInfo GetInputInfo(KomodoInputs input, int playerIndex = 0)
        {
            if (!IsValidPlayerIndex(playerIndex))
            {
                return new InputInfo();
            }
            var komodoInput = KomodoInputs.Undefined;
            var komodoInputState = InputState.Undefined;
            switch(input)
            {
                case KomodoInputs.MouseLeftClick:
                    var buttonState = _mouseState.LeftButton;
                    komodoInputState = buttonState == ButtonState.Pressed ? InputState.Down : InputState.Up;
                    return new InputInfo(komodoInputState, KomodoVector2.Zero, 0f);
                case KomodoInputs.MouseMiddleClick:
                    buttonState = _mouseState.MiddleButton;
                    komodoInputState = buttonState == ButtonState.Pressed ? InputState.Down : InputState.Up;
                    return new InputInfo(komodoInputState, KomodoVector2.Zero, 0f);
                case KomodoInputs.MouseRightClick:
                    buttonState = _mouseState.RightButton;
                    komodoInputState = buttonState == ButtonState.Pressed ? InputState.Down : InputState.Up;
                    return new InputInfo(komodoInputState, KomodoVector2.Zero, 0f);
                default:
                    var monogameButtonInput = InputMapper.ToMonoGameButton(input);
                    if (monogameButtonInput.HasValue)
                    {
                        var gamePadState = _gamePadStates[playerIndex];
                        komodoInput = InputMapper.ToKomodoInput(monogameButtonInput.Value);
                        bool isDown = gamePadState.IsButtonDown(monogameButtonInput.Value);
                        komodoInputState = isDown ? InputState.Down : InputState.Up;
                    }
                    
                    var monogameKeyInput = InputMapper.ToMonoGameKey(input);
                    if (monogameKeyInput.HasValue)
                    {
                        bool isDown = _keyboardState.IsKeyDown(monogameKeyInput.Value);
                        komodoInputState = isDown ? InputState.Down : InputState.Up;
                    }
                    
                    return new InputInfo(komodoInputState, KomodoVector2.Zero, 0f);
            }
        }

        private static int GetPlayerIndexAsInt(int playerIndex)
        {
            switch (playerIndex)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    playerIndex = 0;
                    break;
            }
            return playerIndex;
        }

        private static PlayerIndex GetPlayerIndex(int playerIndex)
        {
            switch (playerIndex)
            {
                case 0:
                    return PlayerIndex.One;
                case 1:
                    return PlayerIndex.Two;
                case 2:
                    return PlayerIndex.Three;
                case 3:
                    return PlayerIndex.Four;
                default:
                    return PlayerIndex.One;
            }
        }
        #endregion Private Static Methods
        
        #endregion Static Methods
    }
}