using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    [SerializeField] int _numScene;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        SceneManager.LoadScene(_numScene);
    }
}
