using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class HazardManager : MonoBehaviour
{
    public List<Image> hazardSprites;
    public Action<int> OnHazard;
    private bool playing;
    public void StartGame() => playing = true;
    public void StopGame() => playing = false;

    public void Start()
    {
        StartGame();
        StartCoroutine(HazardRoutine());
    }


    private WaitForSeconds minHazardWait = new WaitForSeconds(3.0f);
    private IEnumerator HazardRoutine()
    {
        while (playing)
        {
            yield return minHazardWait;

            if (Random.Range(0, 1) == 0) 
                SpawnHazard(Random.Range(0, 3));
        }
    }

    private void SpawnHazard(int hazardIndex) => StartCoroutine(FlashHazard(hazardSprites[hazardIndex], hazardIndex));

    private WaitForSeconds flashDelay = new WaitForSeconds(0.5f);
    private IEnumerator FlashHazard(Image hazardSprite, int idx)
    {
        for (var i = 0; i < 3; i++)
        {
            hazardSprite.enabled = true;
            yield return flashDelay;
            hazardSprite.enabled = false;
            yield return flashDelay;
            OnHazard.Invoke(idx);
        }
    }
}
