using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLibrary : MonoBehaviour {

    public SoundGroup[] soundGroups;

    Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();

    void Awake()
    {
        foreach (SoundGroup SoundGroup in soundGroups)
        {
            groupDictionary.Add(SoundGroup.groupID, SoundGroup.clips);
        }
    }

    public AudioClip GetClipFromName(string name)
    {
        if (groupDictionary.ContainsKey(name))
        {
            AudioClip[] sounds = groupDictionary[name];
            return sounds[0];
        }
        return null;
    }
	[System.Serializable]
    public class SoundGroup
    {
        public string groupID;
        public AudioClip[] clips;
    }
}
