using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public GameObject LoadindUI;
    public int  GameIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGameEvent()
    {
        if(LoadindUI !=null )
        { 
        LoadindUI.SetActive(true);
        }
        SceneManager.LoadScene(GameIndex);
    }
}
