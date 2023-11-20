using System.Collections.Generic;
using UnityEngine;

public class BowlingBallController : MonoBehaviour
{
    public float forceMultiplier = 5f;                      // variable para aumentar la fuerza
    public float maxForce = 10f;                            // m�xima fuerza que puede aplicarse
    public GameObject pista;                                // variable del tipo GameObject para la pista
    public float CurrentForce { get; private set; }         // m�todo para solo leer el valor de la fuerza actual
    public float MaxForce { get { return maxForce; } }      // m�todo para retornar el valor m�ximo de la fuerza

    private Rigidbody rb;                                   // variable del tipo Rigidbody para la ball
    private bool isPressed = false;                         // variable para gestionar el clic de space

    void Start()
    {
        // inicializa el Rigidbody de Ball
        rb = GetComponent<Rigidbody>();

        // si la Pista es nula => mensaje
        if (pista == null)
        {
            Debug.LogError("No hay Pista asignada");
        }
    }

    void Update()
    {
        // si clic en tecla izquierda => m�todo Move(-1) / -1 direcci�n izquierda
        // si no clic en tecla derecha => m�todo Move(1) / 1 direcci�n derecha
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(-1);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(1);
        }

        // si clic en space (tecla presionda) => bool isPressed = true
        if (Input.GetKeyDown(KeyCode.Space))
            isPressed = true;

        // si clic space (tecla liberada) => calcula la fuerza aplicada = limit�ndola a un valor de CurrentForce dentro de un rango espec�fico: CurrentForce-> valr a limitar, 0f-> valor m�nimo, maxForce -> valor m�ximo de fuerza.
        // adiciona al rigidbody Ball una fuerza = el factor multiplicador * la fuerza aplicada + el vector nomalizado
        // cambia el estado de isPressed = false
        // modifica el valor de la fuerza = 0
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float clampedForce = Mathf.Clamp(CurrentForce, 0f, maxForce);
            rb.AddForce(forceMultiplier * clampedForce * Vector3.forward, ForceMode.Impulse);
            isPressed = false;
            CurrentForce = 0f;
        }

        // si isPressed = true => modifica el valor de la fuerza afectada por Time.deltaTime * el multiplicador de fuerza
        if (isPressed)
            CurrentForce += Time.deltaTime * forceMultiplier;
    }

    private void Move(int direction)
    {
        // calcula la variable horizontalMove = a la direcci�n de movimiento de Ball (derecha o izqueirza) afectada por Time.deltaTime
        float horizontalMove = direction * Time.deltaTime;

        // modifica el transform de Ball, trasladando a Ball seg�n un vector y la direcci�n de movimiento de Ball
        transform.Translate(Vector3.right * horizontalMove);

        // asegurar que la posici�n de Ball est� dentro de los l�mites de la pista
        float xPosition = Mathf.Clamp(transform.position.x, pista.transform.position.x - pista.transform.localScale.x / 2f, pista.transform.position.x + pista.transform.localScale.x / 2f);
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }
}

