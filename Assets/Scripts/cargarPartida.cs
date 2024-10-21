using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarPartida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
        
   public void LoadGame(){

     // Cargar la partida
        SceneManager.LoadScene(1);
        Debug.Log("Cargando partida...");
   }
}
