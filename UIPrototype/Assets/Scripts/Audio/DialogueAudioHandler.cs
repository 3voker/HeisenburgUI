using UnityEngine;
using System.Collections;

public class DialogueAudioHandler : AudioManager
{
    private void Start()
    {
        audioObject = Resources.Load("AudioObject") as GameObject;
    }

    public void PlayAgreementSound()
    {
        GameObject agreementAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(agreementAudio, Random.Range(0, 1)));
    }

    public void PlayInsultedSound()
    {
        GameObject insultedAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(insultedAudio, Random.Range(2, 3)));
    }

    public void PlaySurprisedSound()
    {
        GameObject surprisedAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(surprisedAudio, Random.Range(4, 5)));
    }

    public void PlayLaugh()
    {
        GameObject laughAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(laughAudio, 6));
    }

}
