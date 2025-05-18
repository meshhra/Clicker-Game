using System;
using UnityEngine;

public class Clicker : MonoBehaviour
{
    public event Action OnClickerPressed;
    public static Clicker Instance { get; private set; }
    
    [SerializeField] private ParticleSystem clickParticles;
    
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
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // or any distance you want
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        clickParticles.transform.position = worldPos;
        clickParticles.Play();
    }
}
