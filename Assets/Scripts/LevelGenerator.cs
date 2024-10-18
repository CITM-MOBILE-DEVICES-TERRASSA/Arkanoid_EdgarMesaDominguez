using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size = new Vector2Int(10, 5 );
    public Vector2 offset = new Vector2(1.1f, 0f);
    public GameObject brickPrefab;
 
    public Gradient gradient = new Gradient
    {
        colorKeys = new GradientColorKey[]
        {
            new GradientColorKey(new Color(0.5f, 0f, 0.5f), 0f), // Purple at the start
            new GradientColorKey(new Color(1f, 0f, 1f), 1f) // Magenta at the end
        },
        alphaKeys = new GradientAlphaKey[]
        {
            new GradientAlphaKey(1f, 0f), // Fully opaque at the start
            new GradientAlphaKey(1f, 1f) // Fully opaque at the end
        }
    };

    private void Awake()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++) 
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float) ((size.x - 1) * 0.5f - i)  * offset.x, j * offset.y, 0); 
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float) j / (size.y - 1));
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }


}
