using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Driver : MonoBehaviour
{
   [SerializeField] float steerSpeed = 1f;
   [SerializeField] float movespeed = 0.05f;
    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if(Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        if(Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if(Keyboard.current.dKey.isPressed)
        {
            steer = -1;
        }
        if(Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }

        float moveAmount = move*movespeed*Time.deltaTime;
        float steerAmount = steer*steerSpeed*Time.deltaTime;

        transform.Translate(0,moveAmount,0);
        transform.Rotate(0,0 , steerAmount);
         
    }
}
