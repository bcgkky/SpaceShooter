using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ForGame : MonoBehaviour
{
    public GameObject astro;
    [SerializeField] int adet;
    [SerializeField] int wave;
    [SerializeField] int start;

    [SerializeField] Text scoreT;
    [SerializeField] Text gameO;
    [SerializeField] Text resT;
    [SerializeField] Text quitT;

    bool gameover;
    bool restart;

    public int puan;

    IEnumerator Asteroid()
    {
        yield return new WaitForSeconds(start);

        while (true)
        {
            
            for (int i = 0; i < adet; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-2.86f, 2.86f), 4, 5.86f);
                Quaternion spawnRot = Quaternion.identity;
                Instantiate(astro, spawnPos, spawnRot);

                yield return new WaitForSeconds(1.25f);
            }

            yield return new WaitForSeconds(wave);

            if (gameover) {
                restart = true;
                quitT.text = "Press 'Q' for Quit game";
                resT.text = "Press 'R' for Restart game";
                break; }
        }
    }

    void Start()
    {
        StartCoroutine(Asteroid());
        resT.text = "";
        quitT.text = "";
    }

    public void GameOver()
    {
        gameover = true;
        gameO.text = "GAME OVER";
        
    }

    public void UpdatePoint()
    {
        puan += 10;
        scoreT.text = "Score : " + puan;
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
