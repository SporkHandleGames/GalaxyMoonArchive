using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoManager : MonoBehaviour
{
    public float bpm;
    public float msPerBeat;

    public Note note;
    public Canvas thisCanvas;

    public AudioSource audioSource;
    public AudioClip music;
    public Song thisSong;

    public Image hitMarker;
    public Color defaultHitColor;
    public Color keyPressHitColor;

    private void Awake()
    {
        hitMarker.GetComponent<CanvasRenderer>().SetColor(defaultHitColor);
        msPerBeat = (60000 / bpm)/1000;
        Invoke("StartMusic", msPerBeat * 4);
        InvokeRepeating("BeatCounter", msPerBeat * 4, msPerBeat);
    }

    public void BeatCounter()
    {
        thisSong.CheckBeat();
    }

    public void StartMusic()
    {
        audioSource.clip = music;
        audioSource.Play();
    }

    public void SpawnNote(int key)
    {
        GameObject newNote = Instantiate(note.gameObject, thisCanvas.transform.Find("NoteBar Bottom").transform);
        newNote.GetComponent<Note>().NoteSetup(key);
        newNote.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            hitMarker.GetComponent<CanvasRenderer>().SetColor(keyPressHitColor);
            hitMarker.CrossFadeColor(defaultHitColor, 0.1f, true, true);
        }
    }
}
