using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeLevelButton : MonoBehaviour 
{
    public void ChangeLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
}
