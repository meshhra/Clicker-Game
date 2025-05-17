using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public event Action OnClickerPressed;
    public static Clicker Instance { get; private set; }
    private void Awake()
    {
        if(!Instance)
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
        GetComponent<Animator>().CrossFadeInFixedTime("Click", 0.1f,0 );
        //Debug.Log("clicker was just pressed");
    }
}
