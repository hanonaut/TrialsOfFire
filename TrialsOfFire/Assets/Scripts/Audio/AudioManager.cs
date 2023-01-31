using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }


    public List<Sound> sounds = new List<Sound>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Play(string soundName, GameObject otherObject = null)
    {
        Sound s = sounds.Find(i => i.soundName == soundName);
        if(s == null)
        {
            Debug.LogWarning("Sound " + soundName + " not Found.");
            return;
        }
        if (otherObject != null)
        {
            s.soundEvent.Post(otherObject);
        }
        else
        {
            s.soundEvent.Post(Player.Instance.gameObject);
        }
    }


    public void StopSound(string soundName, GameObject otherObject = null)
    {
        Sound s = sounds.Find(i => i.soundName == soundName);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found.");
            return;
        }
        if (otherObject != null)
        {
            s.soundEvent.Stop(otherObject);
        }
        else
        {
            s.soundEvent.Stop(Player.Instance.gameObject);
        }
    }
}
