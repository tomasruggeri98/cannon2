using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonController : MonoBehaviour
{
    public Transform canonBase;       // La base del cañón, que rota horizontalmente
    public Transform canonPivot;      // Punto de rotación vertical del cañón
    public GameObject proyectilPrefab; // Prefab del proyectil
    public Transform spawnPoint;      // Punto desde donde se dispara el proyectil
    public float velocidadDisparo = 20f;   // Velocidad del proyectil
    public float rotacionHorizontalVel = 30f; // Velocidad de rotación horizontal
    public float rotacionVerticalVel = 20f;   // Velocidad de rotación vertical
    public float maxAnguloVertical = 45f;     // Ángulo máximo hacia arriba
    public float minAnguloVertical = -10f;    // Ángulo mínimo hacia abajo

    void Start()
    {
        // Vincula los botones con sus funciones
        Button btnGirarIzquierda = GameObject.Find("BtnGirarIzquierda").GetComponent<Button>();
        btnGirarIzquierda.onClick.AddListener(GirarIzquierda);

        Button btnGirarDerecha = GameObject.Find("BtnGirarDerecha").GetComponent<Button>();
        btnGirarDerecha.onClick.AddListener(GirarDerecha);

        Button btnApuntarArriba = GameObject.Find("BtnApuntarArriba").GetComponent<Button>();
        btnApuntarArriba.onClick.AddListener(ApuntarArriba);

        Button btnApuntarAbajo = GameObject.Find("BtnApuntarAbajo").GetComponent<Button>();
        btnApuntarAbajo.onClick.AddListener(ApuntarAbajo);

        Button btnDisparar = GameObject.Find("BtnDisparar").GetComponent<Button>();
        btnDisparar.onClick.AddListener(Disparar);
    }

    void GirarIzquierda()
    {
        canonBase.Rotate(Vector3.up, -rotacionHorizontalVel * Time.deltaTime);
    }

    void GirarDerecha()
    {
        canonBase.Rotate(Vector3.up, rotacionHorizontalVel * Time.deltaTime);
    }

    void ApuntarArriba()
    {
        float anguloActual = canonPivot.localEulerAngles.x;
        anguloActual = (anguloActual > 180) ? anguloActual - 360 : anguloActual;
        if (anguloActual < maxAnguloVertical)
        {
            canonPivot.Rotate(Vector3.right, -rotacionVerticalVel * Time.deltaTime);
        }
    }

    void ApuntarAbajo()
    {
        float anguloActual = canonPivot.localEulerAngles.x;
        anguloActual = (anguloActual > 180) ? anguloActual - 360 : anguloActual;
        if (anguloActual > minAnguloVertical)
        {
            canonPivot.Rotate(Vector3.right, rotacionVerticalVel * Time.deltaTime);
        }
    }

    void Disparar()
    {
        GameObject proyectil = Instantiate(proyectilPrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = proyectil.GetComponent<Rigidbody>();
        rb.velocity = spawnPoint.forward * velocidadDisparo;
    }
}
