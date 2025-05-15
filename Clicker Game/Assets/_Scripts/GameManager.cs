using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private int _score;
    private void Start()
    {
        Clicker.Instance.OnClickerPressed += Clicker_OnClikerPressed;
    }

    private void Clicker_OnClikerPressed()
    {
        _score += 10;
    }
}
