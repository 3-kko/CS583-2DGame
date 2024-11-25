using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public float loopStartingPoint = 18f; //0:18
    public float loopEndingPoint = 121f; //2:01
    [SerializeField] private AudioSource audioSource;
    private static BGM bgm;

    // Start is called before the first frame update
    void Awake()
    {
        if(bgm == null)
        {
            bgm = this;
            DontDestroyOnLoad(bgm);
        }
        else
        {
            Destroy(gameObject);
        }
        // audioSource.Play();            // Start playback from the specified time
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the audio has reached the loop end point
        if (audioSource.time >= loopEndingPoint)
        {
            // Reset audio time to loop start time
            audioSource.time = loopStartingPoint;
        }
    }
}
