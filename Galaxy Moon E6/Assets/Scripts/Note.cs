using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Note : MonoBehaviour
{
    public char[] noteKeys;     //list of keys you can press for the notes
    public char thisNoteKey;    //the key you press for this note
    public Color[] noteColors;  //list of colors for the notes
    public Color noteColor;     //the color of this note
    private RectTransform rect;
    public bool isRandomNote = false;
    //public enum eDirection { left, right };
    //public eDirection direction; //the direction the note is moving

    public float maxX;          //Starting/ending position for the note
    public float offset;
    public RectTransform noteHit; //the position of the hit marker
    public RectTransform topBar;

    public float noteDuration;

    public Player player;
    public Animator animator; //The animator component for the player's mesh

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(maxX, 0);

        if (isRandomNote)
        {
            int randNote = (int)Random.Range(0, noteKeys.Length);
            NoteSetup(randNote);
        }

        GetComponent<CanvasRenderer>().SetColor(noteColor);

        transform.Find("Key").GetComponent<TextMeshProUGUI>().text = thisNoteKey.ToString();
        noteDuration = player.gameObject.GetComponent<TempoManager>().msPerBeat * 4f;
        LeanTween.moveLocalX(this.gameObject, -maxX, noteDuration).setOnComplete(MoveUp);

        LeanTween.scale(this.gameObject, Vector3.one * 0.75f, noteDuration / 4).setLoopCount(-1);
    }

    public void NoteSetup(int key)
    {
        thisNoteKey = noteKeys[key];
        noteColor = noteColors[key];
    }

    public void MoveUp()
    {
        rect.SetParent(topBar);
        rect.anchoredPosition = new Vector2(maxX, 0);
        LeanTween.moveLocalX(this.gameObject, noteHit.anchoredPosition.x, noteDuration);
        LeanTween.moveLocalX(this.gameObject, -maxX - offset, noteDuration / 8f).setDelay(noteDuration).setOnComplete(DamagePlayer);
        Destroy(this.gameObject, noteDuration * 2.5f);
    }

    public void DamagePlayer()
    {
        player.TakeDamage();
    }

    public void GetNoteScore()
    {
        if(rect.anchoredPosition.x > -542)
        {
            //EARLY
            Debug.Log("EARLY");
        }
        else if((rect.anchoredPosition.x < -542 && rect.anchoredPosition.x > -583) || (rect.anchoredPosition.x < -603 && rect.anchoredPosition.x > -642)){
            //GOOD
            Debug.Log("GOOD");

        }
        else if(rect.anchoredPosition.x >= -602 && rect.anchoredPosition.x <= -582){
            //AMAZING
            Debug.Log("AMAZING");

        }
        else if(rect.anchoredPosition.x < -642)
        {
            //LATE
            Debug.Log("LATE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(thisNoteKey.ToString()))
        {
            if (rect.anchoredPosition.x > -682 && rect.anchoredPosition.x < -522 && rect.parent == topBar)
            {
                GetNoteScore();

                LeanTween.cancel(this.gameObject);
                GetComponent<CanvasRenderer>().SetColor(Color.white);
                //this.gameObject.SetActive(false);
                Destroy(this.gameObject, 0.1f);

                animator.SetTrigger("Attack");
            }
            else
            {
                //do the miss animation
            }
        }
        else
        {
            //do the miss animation
        }
    }
}
