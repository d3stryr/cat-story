using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    private Fader fader;
    private Door theDoor;
    private List<Gem> gems;
    // Start is called before the first frame update
    void Start()
    {
        if(GM==null)
        {
            GM = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        gems = new List<Gem>();
    }

    public static void RegisterDoor(Door door)
    {
        if (GM == null)
            return;
        GM.theDoor = door;
    }

    public static void RegisterFader(Fader fD)
    {
        if (GM == null)
            return;

        GM.fader = fD;
    }

    public static void ManagerLoadLevel(int index)
    {
        if (GM == null)
            return;

        GM.fader.SetLevel(index);
    }

    public static void ManagerRestartLevel()
    {
        if (GM == null)
            return;
        GM.gems.Clear();
        GM.fader.RestartLevel();
    }

    public static void RegisterGems(Gem gem)
    {
        if (GM == null)
            return;
        if(!GM.gems.Contains(gem))
            GM.gems.Add(gem);
    }

    public static void RemoveGemFromList(Gem gem)
    {
        if (GM == null)
            return;
        if (GM.gems.Contains(gem))
            GM.gems.Remove(gem);
        if (GM.gems.Count == 0)
            GM.theDoor.UnlockDoor();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
