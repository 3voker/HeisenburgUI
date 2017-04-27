using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    [SerializeField] protected List<AudioClip> audioClips;
    [SerializeField] List<AudioClip> musicClips;

    protected GameObject audioObject;
    protected AudioSource aSource;
    protected float audioLength;

    private int curSong = 0;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        audioObject = Resources.Load("AudioObject") as GameObject;
        GameObject narrativeAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(narrativeAudio, 0, true));
    }


    //Takes in instantiated audio object, current element of audioClips to play, and length of Audio Clip
    protected IEnumerator HandleAudio(GameObject curAudio, int curElement)
    {
        curAudio.GetComponent<AudioSource>().clip = audioClips[curElement];
        audioLength = curAudio.GetComponent<AudioSource>().clip.length;
        curAudio.GetComponent<AudioSource>().Play();
        Debug.Log(audioLength);
        yield return new WaitForSeconds(audioLength);
        Destroy(curAudio);
    }

        protected IEnumerator HandleAudio(GameObject curAudio, int curElement, bool hacketyHack)
    {
        curAudio.GetComponent<AudioSource>().clip = audioClips[curElement];
        audioLength = curAudio.GetComponent<AudioSource>().clip.length;
        curAudio.GetComponent<AudioSource>().Play();
        Debug.Log(audioLength);
        yield return new WaitForSeconds(audioLength);
        Destroy(curAudio);
        yield return new WaitForSeconds(3.74f);
        aSource.Play();
    }
}