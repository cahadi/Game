using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingRoomsOnTheSameLevel : MonoBehaviour
{
    public GameObject door;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            collision.gameObject.transform.position = 
                door.gameObject.transform.position;
        }
    }
}
