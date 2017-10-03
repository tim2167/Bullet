//Tim Chang
using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class GameLoopManager : MonoBehaviour
{

    public AudioSource bgmAudioSource;
    public HUE_Rotate hueRotate;

    public ScoreManager scoreManager;
    public AudioSource bgmAudio;

    public List<BulletScript> bullets;
    public PlayerController playerController;
    public FollowTheBeat followTheBeat;

    bool playerAlive = true;

    public void GameOver() //check if game is over and sets sound control to stop if it is over
    {

        DOTween.To(() => Time.timeScale, (x) => Time.timeScale = x, 0, 1f).SetUpdate(true);

        bgmAudioSource.DOFade(0, 1f).OnComplete(() =>
        {
            bgmAudioSource.Stop();
            playerAlive = false;
        }).SetUpdate(true);

        hueRotate.RotateValue = Mathf.PI;
    }

    public void RestartGame()  //reset the game and destroy any bullets/pixels that are still in game
    {
        playerAlive = true;
        hueRotate.RotateValue = 0;
        scoreManager.Reset();
        playerController.Reset();
        followTheBeat.Reset();

        for (int i = 0; i < bullets.Count; i++)
        {
            GameObject.Destroy(bullets[i].gameObject);
        }

        bullets.Clear();
        bgmAudio.volume = 1;
        bgmAudio.Play();
        Time.timeScale = 1;

    }

    public void Update()
    {
        if (!playerAlive)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                RestartGame();
            }
        }
    }

}
