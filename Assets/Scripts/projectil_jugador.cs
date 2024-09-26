using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectil : MonoBehaviour
{
    private Vector2 maxPantalla;
    [SerializeField]
    private float _vel;
    // Start is called before the first frame update
    void Start()
    {
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        _vel = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 posActual = transform.position;
        posActual += new Vector2 (0,1) * _vel* Time.deltaTime;
        transform.position = posActual;
        if (transform.position.y > maxPantalla.y){
            Destroy(gameObject);
        }

    }
}
