using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Ethan Blomgren
public class SceneMusic : MonoBehaviour
{
    AudioSource song;
    //From the Unity documentation
    //Play the music
    bool m_Play;
    //Detect when you use the toggle, ensures music isn’t played multiple times
    bool m_ToggleChange = true;
    // Start is called before the first frame update
    void Start()
    {
        song = GetComponent<AudioSource>();
        m_Play = true;
    }
    private void Update()
    {
        if (m_Play && m_ToggleChange)
        {
            song.Play();
            m_ToggleChange=false;
        }
        if (m_Play == false && m_ToggleChange) { 
            song.Stop();
            m_ToggleChange=false;
        
        }
    }
    private void OnGUI()
    {
        m_Play = GUI.Toggle(new Rect(10, 10, 100, 30), m_Play, "Play Music");
        if (GUI.changed)
        {
            m_ToggleChange = true;
        }
    }

}
