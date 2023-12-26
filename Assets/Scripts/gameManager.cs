using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;

    public GameObject[] rotators;
    public GameObject spawner;

    private bool gameHasEnded = false;
    

    public Animator animator;
    public int level = 1;
    [SerializeField] private int score = 0;
    private bool _canLevelUp = true;
    public void StartGame()
    {
        rotators[0].SetActive(true);
        spawner.SetActive(true);
    }
    public void scoreAdd()
    {
        
        
        if (score>7 && !gameHasEnded)
        {
            levelController(_canLevelUp);
            score = 0;
        }
        else
        {
            score = score + 1;
        }
        scoreText.text = score.ToString();
    }

    public void levelController(bool canLevelUp)
    {
        if (canLevelUp)
        {
            rotators[level - 1].SetActive(false);
            level += 1;
            rotators[level - 1].SetActive(true);
            _canLevelUp = false;
            levelText.text = level.ToString();
         }
    }
    public void EndGame()
    {
        if (gameHasEnded)
        {
            return;
        }
        Debug.Log(rotators[level - 1].name);
        rotators[level - 1].GetComponent<rotator>().enabled  = false;
        spawner.SetActive(false);
        levelText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        animator.SetTrigger("EndGame");
        gameHasEnded = true;
        StartCoroutine(delay(1));

        SceneManager.LoadScene(0);
    }

    IEnumerator delay(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
