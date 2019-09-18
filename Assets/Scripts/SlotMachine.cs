using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public float payout;
    public float cost;
    public GameObject screen;
    public GameObject body;
    public int screenColorCode;
    public int winSoundCode;
    public AudioSource coinSound;
    public AudioSource winSound;
    public List<AudioClip> winSounds;
    public AudioSource spinSound;
    GameController gameController;
    bool isPlaying = false;

    void Start()
    {
        screenColorCode = Random.Range(1, 5);
        winSoundCode = Random.Range(0, winSounds.Count - 1);
        winSound.clip = winSounds[winSoundCode];
        SetScreenColor();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
    }

    public void StartSpin(){
        if(isPlaying && !gameController.isPaused || gameController.cash < cost){
            return;
        }
        coinSound.Play();
        spinSound.Play();
        gameController.AdjustCash(cost * -1);
        isPlaying = true;
        StartCoroutine("Spin");
    }

    public IEnumerator Spin(){
        while(spinSound.isPlaying){
            yield return new WaitForSeconds(.1f);
        }
        float payout = gameController.CalculatePayout(cost, winSoundCode, screenColorCode);
        gameController.AdjustCash(payout);        
        isPlaying = false;
        if(payout > 0){
            winSound.Play();
        }
    }

    public void SetScreenColor(){
        Color color = Color.red;
        switch(screenColorCode){
            case 1:
                color = Color.red;
                break;
            case 2:
                color = Color.green;
                break;
            case 3:
                color = Color.blue;
                break;
            case 4:
                color = Color.yellow;
                break;
            case 5:
                color = Color.white;
                break;
        }
        screen.GetComponent<SpriteRenderer>().color = color;
    }

    public class PayoutProperies{
        public Sprite screenImage;
        public Sprite background;
        public AudioClip sound;
        public bool shakeUp;
        public bool shakeRight;
    }
}
