using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;

public class Driver : MonoBehaviour
{
   [SerializeField] float steerSpeed = 1f;
   [SerializeField] float currentspeed = 0.05f;
   [SerializeField] float boostspeed = 10f;
   [SerializeField] float regularspeed = 5f;
    [SerializeField] TMP_Text boosttext;
    [SerializeField] AudioSource sfxsource;
    [SerializeField] AudioClip boostsound;
    void Start()
    {
        boosttext.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Boost"))
        {
            currentspeed = boostspeed;
            boosttext.gameObject.SetActive(true);
            sfxsource.PlayOneShot(boostsound , 3f);
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        currentspeed = regularspeed;
        boosttext.gameObject.SetActive(false);
    }
       
   [SerializeField] float acceleration = 8f;
[SerializeField] float maxSpeed = 10f;
[SerializeField] float turnSpeed = 200f;
[SerializeField] float drag = 3f;

float currentSpeed = 0f;

void Update()
{
    float moveInput = 0f;
    float steerInput = 0f;

    if (Keyboard.current.wKey.isPressed)
        moveInput = 1f;
    if (Keyboard.current.sKey.isPressed)
        moveInput = -1f;
    if (Keyboard.current.aKey.isPressed)
        steerInput = 1f;
    if (Keyboard.current.dKey.isPressed)
        steerInput = -1f;
    currentSpeed += moveInput * acceleration * Time.deltaTime;
    currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);
    currentSpeed = Mathf.Lerp(currentSpeed, 0, drag * Time.deltaTime);
    transform.Translate(Vector2.up * currentSpeed * Time.deltaTime);
    float speedFactor = Mathf.Clamp01(Mathf.Abs(currentSpeed) / maxSpeed);
   float direction = currentSpeed >= 0 ? 1f : -1f;

transform.Rotate(0, 0, steerInput * turnSpeed * speedFactor * direction * Time.deltaTime);
}
}
