using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CSVReader : MonoBehaviour
{

    public TextAsset textAssetData;

    public int beatOffset;

    [System.Serializable]
    public class Note
    {
        public int beat;
        public int key;
    }

    [System.Serializable]
    public class NoteList
    {
        public int[] notes;
    }

    public NoteList allNotes = new NoteList();

    private void Awake()
    {
        ReadCSV();
    }

    void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        int tableSize = data.Length;
        allNotes.notes = new int[tableSize];

        for (int i = 0; i < data.Length; i++)
        {
            if (data[i].Length == 1)
            {
                data[i] = "-1";
                Convert.ToString(data[i]);
                Debug.Log(data[i]);
            }

            int newNote = Convert.ToInt32(data[i]);
            if(i >= beatOffset)
            {
                allNotes.notes[i - beatOffset] = newNote;
            }
            else if(i >= data.Length - beatOffset)
            {

            }
        }
    }
}
