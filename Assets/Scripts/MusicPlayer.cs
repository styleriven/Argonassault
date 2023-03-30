using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Awake() {
        int numberMusicPlayers = FindObjectOfType<MusicPlayer>().Length;

        if (numberMusicPlayers>1)
        {
            Destroy(gameObject);
        }
        else
        {
            OnDestroyReLoad(gameObject);
        }
    }
}
