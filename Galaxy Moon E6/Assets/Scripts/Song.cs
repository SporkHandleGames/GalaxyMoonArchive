using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Song : MonoBehaviour
{
    public TempoManager tempoManager;
    public int beatNumber;
    public int totalBeats;

    public CSVReader reader;

    private void Start()
    {
        totalBeats = reader.allNotes.notes.Length;
    }

    public void CheckBeat()
    {
        if (beatNumber < totalBeats)
        {
            beatNumber += 1;

            if (reader.allNotes.notes[beatNumber] >= 0)
            {
                tempoManager.SpawnNote(reader.allNotes.notes[beatNumber]);
            }
        }
    }
}
