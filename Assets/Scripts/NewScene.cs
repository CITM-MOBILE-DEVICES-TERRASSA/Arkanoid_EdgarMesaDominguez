using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to change to scene 1
    public void ChangeToScene0()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeToScene1()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeToScene2()
    {
        SceneManager.LoadScene(2);
    }

    public void ChangeToScene4()
    {
        SceneManager.LoadScene(4);
    }
}
