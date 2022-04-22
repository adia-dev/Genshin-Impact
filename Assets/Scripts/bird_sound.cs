using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_sound : MonoBehaviour
{

    public AudioSource randomSound;

    public AudioClip[] audioSources;

    public float SoundDelay;
    float SoundTimer;
    // Start is called before the first frame update
    void Start()
    {
	RandomSoundness();    
    }

    // Update is called once per frame
    void Update()
    {
	SoundTimer += Time.deltaTime;
	if(SoundTimer >= SoundDelay){
	
        RandomSoundness();
	SoundTimer = 0f;
	}
    }
    
     void CallAudio()
     {
         Invoke ("RandomSoundness", 10);
     }
 
     void RandomSoundness()
     {
         randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
         randomSound.Play ();
         CallAudio ();
     }
}
