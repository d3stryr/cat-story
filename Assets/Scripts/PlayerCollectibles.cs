using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollectibles : MonoBehaviour
{
    public int gemNumber;


    private TMP_Text textComponent;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GameObject.FindGameObjectWithTag("GemUI").GetComponent<TMP_Text>();
        gemNumber = PlayerPrefs.GetInt("GemsKey", 0);
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
        textComponent.text = gemNumber.ToString();
    }
    public void GemCollected()
    {
        gemNumber += 1;
        UpdateText();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("GemsKey");
    }
}
