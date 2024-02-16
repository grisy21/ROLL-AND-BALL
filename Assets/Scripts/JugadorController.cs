using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    public Text TextoContador, TextoGanar;
    public float velocidad;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        TextoGanar.text = "";
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);

        // Verificar si el componente Rigidbody está adjunto antes de agregar fuerza
        if (rb != null)
        {
            rb.AddForce(movimiento * velocidad);
        }
        else
        {
            Debug.LogError("Rigidbody componente está faltando en el objeto.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();
        }
    }

    void setTextoContador()
    {
        TextoContador.text = "Contador: " + contador.ToString();
        if (contador >= 12)
        {
            TextoGanar.text = "¡Ganaste!";
        }
    }
}
