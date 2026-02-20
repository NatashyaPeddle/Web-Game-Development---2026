using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("NPC"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        
    }


}
