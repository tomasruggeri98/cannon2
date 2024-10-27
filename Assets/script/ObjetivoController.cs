using UnityEngine;

public class ObjetivoController : MonoBehaviour
{
    private float anguloInicialVertical;
    private float anguloInicialHorizontal;

    void Start()
    {
        // Inicializa los �ngulos base (puedes usar transformaciones locales si tienes el pivot del ca��n)
        anguloInicialVertical = 0f;
        anguloInicialHorizontal = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si el objeto que colisiona es el proyectil
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            // Obtenemos la velocidad (magnitud de la fuerza de disparo)
            Rigidbody rbProyectil = collision.gameObject.GetComponent<Rigidbody>();
            float fuerzaDisparo = rbProyectil.velocity.magnitude;

            // Calculamos el �ngulo en el momento de la colisi�n
            float anguloActualVertical = CalcularAnguloVertical();
            float anguloActualHorizontal = CalcularAnguloHorizontal();

            // Muestra la informaci�n en la consola (o puedes adaptarlo para mostrar en pantalla)
            Debug.Log("Impacto del proyectil!");
            Debug.Log("�ngulo Vertical de Disparo: " + anguloActualVertical + "�");
            Debug.Log("�ngulo Horizontal de Disparo: " + anguloActualHorizontal + "�");
            Debug.Log("Fuerza de Disparo: " + fuerzaDisparo + " unidades");
        }
    }

    // M�todo para calcular el �ngulo vertical basado en la diferencia con el �ngulo inicial
    private float CalcularAnguloVertical()
    {
        Transform canonPivot = GameObject.Find("Ca��nPivot").transform;
        float anguloActualVertical = canonPivot.localEulerAngles.x;
        anguloActualVertical = (anguloActualVertical > 180) ? anguloActualVertical - 360 : anguloActualVertical;
        return anguloActualVertical - anguloInicialVertical;
    }

    // M�todo para calcular el �ngulo horizontal basado en la diferencia con el �ngulo inicial
    private float CalcularAnguloHorizontal()
    {
        Transform canonBase = GameObject.Find("CanonBase").transform;
        float anguloActualHorizontal = canonBase.localEulerAngles.y;
        anguloActualHorizontal = (anguloActualHorizontal > 180) ? anguloActualHorizontal - 360 : anguloActualHorizontal;
        return anguloActualHorizontal - anguloInicialHorizontal;
    }
}
