using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla, maxPantalla;
    [SerializeField]private GameObject prefabProjectil;
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1,1));
        float mMitatIMGX = GetComponent<SpriteRenderer>().bounds.size.x  / 2;
        float mMitatIMGY = GetComponent<SpriteRenderer>().bounds.size.y / 2;
        minPantalla.x += mMitatIMGX;
        maxPantalla.x -= mMitatIMGX;
        minPantalla.y += mMitatIMGY;
        maxPantalla.y -= mMitatIMGY;

    }

    void Update()
    {
        MovimentNau();
        disparar();
    }
    private void MovimentNau(){
                float direccioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direccioIndicadaY = Input.GetAxisRaw("Vertical");
        //Debug.Log("X: "+direccioIndicadaX +" - Y "+ direccioIndicadaY);

        Vector2 direccioindicada = new Vector2(direccioIndicadaX, direccioIndicadaY);

        Vector2 novaPos = transform.position;
        novaPos = novaPos + direccioindicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }
    private void disparar(){
           if(Input.GetKeyDown("space")){
        GameObject projectil = Instantiate(prefabProjectil);
        projectil.transform.position = transform.position;
    }     
        
     

    }
}
