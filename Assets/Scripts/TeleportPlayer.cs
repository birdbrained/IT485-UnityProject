using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour 
{
    [SerializeField]
    private GameObject player;
    private Vector3 teleportLocation;
    [SerializeField]
    private bool forceY1;
    public Material inactiveMaterial;
    public Material activeMaterial;
    private bool IsGazedAt;

    //Lerping colors
    public float lerpTime;
    private float colorStep;
    public Color[] colors;
    private int i;
    private Color lerpedColor = Color.white;

    void Start()
    {
        teleportLocation = transform.localPosition;
        if (forceY1)
            teleportLocation.y = 1;
        else
            teleportLocation.y += 0.5f;
        SetGazedAt(false);

        //colors[0] = Color.white;
        //colors[1] = Color.cyan;
        //colors[2] = Color.blue;
    }

    void Update()
    {
        if (IsGazedAt)
        {
            if (colorStep < lerpTime)
            {
                lerpedColor = Color.Lerp(colors[i], colors[i + 1], colorStep);
                GetComponent<Renderer>().material.color = lerpedColor;
                colorStep += 0.05f;
            }
            else
            {
                colorStep = 0;
                if (i < colors.Length - 2)
                    i++;
                else
                    i = 0;
            }
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void SetGazedAt(bool gazed)
    {
        IsGazedAt = gazed;
        if (inactiveMaterial != null && activeMaterial != null)
        {
            GetComponent<Renderer>().material = gazed ? activeMaterial : inactiveMaterial;
        }
        else
        {
            //GetComponent<Renderer>().material.color = gazed ? Color.Lerp(Color.white, Color.cyan, Mathf.PingPong(Time.time, 0.5f)) : Color.red;
        }
    }

    public void TeleportThePlayer()
    {
        player.transform.localPosition = teleportLocation;
    }

    //These functions are the ones that are called in the editor
    public void OnGazeEnter()
    {
        SetGazedAt(true);
    }

    public void OnGazeExit()
    {
        SetGazedAt(false);
    }

    public void OnGazeTrigger()
    {
        TeleportThePlayer();
    }
}
