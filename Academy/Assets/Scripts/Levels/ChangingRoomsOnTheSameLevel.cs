using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangingRoomsOnTheSameLevel : MonoBehaviour
{
    [SerializeField] private int LevelToLoad;
    public Vector3 position;
    public VectorValue  PlayerStorage;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            PlayerStorage.initialValue = position;
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
