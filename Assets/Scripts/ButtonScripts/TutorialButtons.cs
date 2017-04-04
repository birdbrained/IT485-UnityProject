using UnityEngine;
using System.Collections;
using TMPro;

public class TutorialButtons : MonoBehaviour 
{
    private TextMeshProUGUI myText;

    void Start ()
    {
        myText = GetComponent<TextMeshProUGUI>();
    }

    public void ProgressText(string s)
    {
        myText.SetText(s);
    }

    public void DisableSelf()
    {
        gameObject.SetActive(false);
    }

    public void EnableGameObject(GameObject obj)
    {
        obj.SetActive(true);
    }
}
