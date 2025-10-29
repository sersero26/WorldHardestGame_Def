using UnityEngine;

public class Spiral : MonoBehaviour
{
    [SerializeField] private float velocidadR;

    [SerializeField] private Vector3 rotacionS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(rotacionS * Time.deltaTime,Space.World);
    }
}
