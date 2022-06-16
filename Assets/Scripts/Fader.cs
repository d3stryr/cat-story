using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour
{
    private Animator anim;
    private int lvlToLoad;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.RegisterFader(this);
        anim = GetComponent<Animator>();
    }

    public void SetLevel(int lvl)
    {
        lvlToLoad = lvl;
        anim.SetTrigger("Fade");
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(lvlToLoad);
    }
    private void Restart()
    {
        SetLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void RestartLevel()
    {
        Invoke("Restart", 1.5f);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
