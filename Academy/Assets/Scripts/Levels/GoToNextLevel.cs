using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToNextLevel : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            UnLockLevel();
            SceneManager.LoadScene(1);
        }
    }

    public void UnLockLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if(currentLevel >= PlayerPrefs.GetInt("levels"))
            PlayerPrefs.SetInt("levels", currentLevel + 1);
    }
}
