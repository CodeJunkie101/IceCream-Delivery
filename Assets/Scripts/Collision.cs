using UnityEngine;

public class Collision : MonoBehaviour
{
    bool hasIceCream;
    [SerializeField] float timeToDestroy = 0.5f;
    void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("IceCream") && hasIceCream == false)
        {
            Debug.Log("ice cream uthali hi");
            hasIceCream = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject , timeToDestroy);
        }
         if(collision.CompareTag("Customer") && hasIceCream == true)
        {
            Debug.Log("ice cream dedi hai");
            GetComponent<ParticleSystem>().Stop();
            hasIceCream = false;
        } 
    }
}
