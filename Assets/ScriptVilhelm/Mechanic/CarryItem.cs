using UnityEngine;

public class CarryItem : MonoBehaviour
{
    private InputManager _input;
    private Rigidbody2D _rigidbody2D;
    
    private GameObject player;
    
    public GameObject Macguffin;
    private Vector2 newItemDad;
    public Transform holdingSpot;
    private bool isHolding;
    
    
    void start()
    {
        //player =  GameObject.FindGameObjectWithTag("Player");
        //transform.parent = player.transform;
        //transform.parent.position = holdingSpot.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        //Instantiate(transform.parent.position, holdingSpot.position, Quaternion.identity);
        isHolding = true;

    }

}
