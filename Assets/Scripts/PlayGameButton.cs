using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevelButton : MonoBehaviour 
{
    public void ChangeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void GazeAnimation(bool gazed)
    {
        gameObject.GetComponent<Animator>().SetBool("gazedAt", gazed);
    }
}
