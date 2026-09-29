using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Key")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    
}
