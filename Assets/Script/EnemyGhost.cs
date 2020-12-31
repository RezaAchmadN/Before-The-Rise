using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGhost : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(gameObject);
    }
    public void Restart() {
        Invoke("GameOver",1f);
    }
    void GameOver() {
        FindObjectOfType<GameManager>().EndGame();
    }
}
