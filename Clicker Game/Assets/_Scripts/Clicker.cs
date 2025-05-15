using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public event Action OnClickerPressed;
    public static Clicker Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        OnClickerPressed?.Invoke();
        //Debug.Log("clicker was just pressed");
    }
}
