using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public TempoManager tempoManager;
    public float noteDuration;
    public float bounceAmount;

    // Start is called before the first frame update
    void Start()
    {
        //LeanTween.delayedCall(0.1f, StartBounce);
        noteDuration = tempoManager.msPerBeat * 4f;
        LeanTween.scale(this.gameObject, this.transform.localScale * bounceAmount, noteDuration / 4).setLoopCount(-1);
    }

    public void StartBounce()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
