using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Atari.VCS.Demo.LocalMultiplayer
{
    public class MultiplayerManager : MonoBehaviour
    {
        List<int> availableColors = new List<int> { 0, 1, 2, 3, 4 };

        List<int> coloursInUse = new List<int>();

        public void PlayerJoined(PlayerInput player)
        {
            Debug.Log("Joined : Devices Missing : " + player.hasMissingRequiredDevices + player.currentControlScheme);

            player.gameObject.GetComponent<Player>().SetColor(GetColorForPlayer());
        }

        public void PlayerLeft(PlayerInput player)
        {
            Debug.Log("Left : Devices Missing : " + player.hasMissingRequiredDevices);

            GetColorFromPlayer(player.gameObject.GetComponent<Player>().GetColor());
        }

        private int GetColorFromPlayer(Color color)
        {
            int _colorValue = -1;

            if (color == Color.red)
            {
                _colorValue = 0;
            }
            else if (color == Color.blue)
            {
                _colorValue = 1;
            }
            else if (color == Color.black)
            {
                _colorValue = 2;
            }
            else if (color == Color.magenta)
            {
                _colorValue = 3;
            }
            else if (color == Color.grey)
            {
                _colorValue = 4;
            }
            if (_colorValue != -1)
            {
                availableColors.Add(_colorValue);

                coloursInUse.Remove(_colorValue);
            }

            return _colorValue;
        }
        private Color GetColorForPlayer()
        {
            if (availableColors.Count > 0)
            {
                int x = Random.Range(0, availableColors.Count);

                x = availableColors[x];
                availableColors.Remove(x);
                coloursInUse.Add(x);
                switch (x)
                {
                    case 0: return Color.red;
                    case 1: return Color.blue;
                    case 2: return Color.black;
                    case 3: return Color.magenta;
                    case 4: return Color.grey;
                }
            }
            return Color.cyan;
        }
    }
}