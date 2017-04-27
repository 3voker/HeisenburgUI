using UnityEngine;
using System.Collections;

public class BattleAudioHandler : AudioManager
{
    private void Start()
    {
        audioObject = Resources.Load("AudioObject") as GameObject;
    }

    public void PlayBattlecrySound()
    {
        GameObject battlecryAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(battlecryAudio, 0));
    }

    public void PlayAttackSound()
    {
        GameObject attackAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(attackAudio, Random.Range(1, 4)));
    }

    public void PlayBlockSound()
    {
        GameObject blockAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(blockAudio, Random.Range(5, 8)));
    }

    public void PlayPainSound()
    {
        GameObject painAudio = Instantiate(audioObject);
        StartCoroutine(HandleAudio(painAudio, Random.Range(9, 12)));
    }
}
