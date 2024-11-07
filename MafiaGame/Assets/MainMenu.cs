using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void EightPlayerScene()
    {
        SceneManager.LoadSceneAsync("8Player");
    }
    public void TenPlayerScene()
    {
        SceneManager.LoadSceneAsync("10Player");
    }
    public void TwelvePlayerScene()
    {
        SceneManager.LoadSceneAsync("12Player");
    }
    
    
    // []
    // // Start is called before the first frame update
    // void Start()
    // {
    //     
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     
    // }
}
