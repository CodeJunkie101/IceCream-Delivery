using UnityEngine;
using TMPro;

public class Collision : MonoBehaviour
{
    bool hasIceCream;
    [SerializeField] float timeToDestroy = 0.5f;
    [SerializeField] AudioSource sfxsource2;
    [SerializeField] AudioClip pickupsound2;
    [SerializeField] AudioClip deliverSound;
    [SerializeField] TMP_Text scoreText;
    int currentScore = 0;
    [SerializeField] int targetScore = 10;
    void Start()
    {
        UpdatescoreUI();
    }
    void UpdatescoreUI()
    {
        scoreText.text = currentScore + " / " + targetScore;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("IceCream") && hasIceCream == false)
        {
            Debug.Log("ice cream uthali hi");
            hasIceCream = true;
            GetComponent<ParticleSystem>().Play();
            sfxsource2.PlayOneShot (pickupsound2);
            Destroy(collision.gameObject , timeToDestroy);
        }
         if(collision.CompareTag("Customer") && hasIceCream == true)
        {
            Debug.Log("ice cream dedi hai");
            sfxsource2.PlayOneShot (deliverSound , 3f);
            currentScore++;
            UpdatescoreUI();
            CheckWin();
            GetComponent<ParticleSystem>().Stop();
            hasIceCream = false;
            Destroy(collision.gameObject , 0.4f);
        } 

    void CheckWin()
{
    if(currentScore >= targetScore)
    {
        Debug.Log("win condition");

        Time.timeScale = 0f; 
    }
}
    }
}
