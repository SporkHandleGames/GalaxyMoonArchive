using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset textJSON;

    [System.Serializable]
    public class Song
    {
        public string name;
        public int bpm;
    }

    [System.Serializable]
    public class SongList
    {
        public Song[] songs;
    }

    public SongList songList = new SongList();

    private void Start()
    {
        songList = JsonUtility.FromJson<SongList>(textJSON.text);
    }
}
