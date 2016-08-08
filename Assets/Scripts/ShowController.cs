using UnityEngine;
using System.Collections;

public enum ShowMode
{
    Nsdos=0, Blank, Rock, Logo, World_1, World_2, World_3, World_4, World_5, World_6, World_7, World_8, World_9, Null
}

public enum TerrainMode
{
	Intro=0, Dawn, Daytime, Dusk, Night
}

public class ShowController : MonoBehaviour
{
    public SceneFadeInOut[] scenes;
    public GameObject commonWorld;
    public WorldGuiController worldGui;
    public bool midiControlled = false;

    public ShowMode showMode = ShowMode.World_1;
    private ShowMode queuedShowMode = ShowMode.World_1;
    
    public AnimatedController[] controllers;
    public float[] terrainSceneTimes = new float[5];
    
    
    
    // --------------------------------------------------------------------------------------------------------
    //
    void Awake()
    {

        Debug.Log("displays connected: " + Display.displays.Length);
        for (int i = 1; i < Display.displays.Length; i++)
        {
            Debug.Log("display " + i + " activated.");
            Display.displays[i].Activate();
        }

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].OnFadeOut += OnSceneFadeOut;
        }

        queuedShowMode = showMode;
        ToggleScenes();
    }

    void Update()
	{
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Debug.Log("control");
            if (Input.GetKeyDown("q")) GoToMode(ShowMode.Nsdos);
            if (Input.GetKeyDown("w")) GoToMode(ShowMode.Blank);
            if (Input.GetKeyDown("e")) GoToMode(ShowMode.Rock);
            if (Input.GetKeyDown("r")) GoToMode(ShowMode.Logo);
            if (Input.GetKeyDown("t")) ToggleMidiControl();
            if (Input.GetKeyDown("a")) GoToMode(ShowMode.World_1);
            if (Input.GetKeyDown("s")) GoToMode(ShowMode.World_2);
            if (Input.GetKeyDown("d")) GoToMode(ShowMode.World_3);
            if (Input.GetKeyDown("f")) GoToMode(ShowMode.World_4);
            if (Input.GetKeyDown("g")) GoToMode(ShowMode.World_5);
            if (Input.GetKeyDown("h")) GoToMode(ShowMode.World_6);
            if (Input.GetKeyDown("j")) GoToMode(ShowMode.World_7);
            if (Input.GetKeyDown("k")) GoToMode(ShowMode.World_8);
            if (Input.GetKeyDown("l")) GoToMode(ShowMode.World_9);
        }
    }
    
    // --------------------------------------------------------------------------------------------------------
    //
    public void GoToMode(ShowMode mode)
    {
        // close current mode, add new one to queue
        queuedShowMode = mode;
        int sceneIndex = (int)showMode;
        if (sceneIndex > -1 && sceneIndex < (int)ShowMode.Null)
        {
            scenes[sceneIndex].FadeOut();
        }
        
    }

    public void ToggleMidiControl()
    {
        midiControlled = !midiControlled;
        var controls = FindObjectsOfType<SliderController>();
        foreach (var control in controls)
        {
            control.midiControlled = midiControlled;
        }
    }

    // --------------------------------------------------------------------------------------------------------
    //
    private void OnSceneFadeOut()
    {
        ToggleScenes();
    }

    public WorldController GetActiveWorld()
    {
        int sceneIndex = (int)showMode;
        if (sceneIndex > 3)
        {
            var world = scenes[sceneIndex].gameObject.GetComponent<WorldController>();
            return world;
        }
        else
        {
            return null;
        }
    }

    // --------------------------------------------------------------------------------------------------------
    //
    public void ToggleScenes()
    {
        showMode = queuedShowMode;
        int sceneIndex = (int)showMode;
        if (sceneIndex > -1 && sceneIndex < (int)ShowMode.Null)
        {
            SetAllActive(false);
            scenes[sceneIndex].gameObject.SetActive(true);
            scenes[sceneIndex].FadeIn();
        }

        if (sceneIndex > 3)
        {
            worldGui.Reset();
            commonWorld.SetActive(true);
        }
        else
        {
            commonWorld.SetActive(false);
        }
    }

    private void SetAllActive(bool active)
    {
        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i].gameObject.SetActive(false);
        }
    }

    public void GoNSDOS()
    {
        GoToMode(ShowMode.Nsdos);
    }
    public void GoBlank()
    {
        GoToMode(ShowMode.Blank);
    }
    public void GoRock()
    {
        GoToMode(ShowMode.Rock);
    }
    public void GoLogo()
    {
        GoToMode(ShowMode.Logo);
    }
    public void GoWorld1()
    {
        GoToMode(ShowMode.World_1);
    }
    public void GoWorld2()
    {
        GoToMode(ShowMode.World_2);
    }
    public void GoWorld3()
    {
        GoToMode(ShowMode.World_3);
    }
    public void GoWorld4()
    {
        GoToMode(ShowMode.World_4);
    }
    public void GoWorld5()
    {
        GoToMode(ShowMode.World_5);
    }
    public void GoWorld6()
    {
        GoToMode(ShowMode.World_6);
    }
    public void GoWorld7()
    {
        GoToMode(ShowMode.World_7);
    }
    public void GoWorld8()
    {
        GoToMode(ShowMode.World_8);
    }
    public void GoWorld9()
    {
        GoToMode(ShowMode.World_9);
    }

}
