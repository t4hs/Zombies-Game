using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Player player;

    // Update is called once per frame

    private static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        CheckPlayerState();
    }

    public void CheckPlayerState()
    {
        if(player.GetHealth() == 0)
        {
            player.Die();
            return;
        }

        if(!player.HasLives())
        {
            GameManager.GetInstance().ChangeState(GameState.GameOver);
        }
    }

    public void SpawnPlayer()
    {
        player.Display();
        player.Init();
    }
    public static PlayerManager GetInstance()
    {
        return instance;
    }
}
