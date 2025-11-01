using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private TMP_Text TextoScore;
    [SerializeField] private TMP_Text TextoLives;
    [SerializeField] float velocidad;
    [SerializeField] private int coins;
    [SerializeField] private string nextLevel;
    [SerializeField] private GameObject exit;
    private Vector3 posicionInicial;
    private float timer = 1;
    private int vidas;
    private string actualScene;
    [SerializeField] AudioSource[] audio;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidas = 3;
        TextoScore.SetText("Get " + coins.ToString() + " more coins");
        TextoLives.SetText("x" + vidas.ToString() );
        actualScene = SceneManager.GetActiveScene().name;
        posicionInicial = transform.position;
        
        Debug.Log(this.gameObject.transform.position.x);// Conseguir posición en X
        //Establece uns rotcion con grados Euler
        this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
          PlayerMovement(); 
        }
      
    }
    
    //Ingredientes: Dos objetos con Collider
    //Aquel que se mueva, con riggid body
    //Al menos uno de ellos como Trigguer

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Moneda")) //Comparación de Tag
        {
            ObtainCoins(other);
            audio[0].Play();
        }

        else if (other.gameObject.CompareTag("Trampa")) //Comparación de Tag
        {
            transform.position = posicionInicial;
            timer = 0.75f;
            audio[1].Play();
            vidas--;
            TextoLives.SetText("x" + vidas.ToString() );
            if (vidas <= 0)
            {
                SceneManager.LoadScene(actualScene);
            }
        }
        else if (other.gameObject.CompareTag("Meta")) //Comparación de Tag
        {
            NextLevel(nextLevel);
        }
    }

    private void PlayerMovement()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); //Esto puede darte -1/0/1
        float vInput =Input.GetAxisRaw("Vertical");
        
        Vector3 vectorM = new Vector3(hInput,vInput,0).normalized;
        //gameObject.transform.position += vectorM * (velocidad * Time.deltaTime);
        transform.Translate(vectorM * (velocidad * Time.deltaTime),Space.World); //Pensado para hacer translaciones
    }

    private void ObtainCoins(Collider2D other)
    {
        coins--;
        if (coins > 0)
        {
            TextoScore.SetText("Get " + coins.ToString() + " more coins");
        }
        else
        {
            TextoScore.SetText("ESCAPE");
            exit.SetActive(true);
        }
        
        Destroy(other.gameObject);//Forma de destruir otro game object
    }

    private void NextLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
} 

