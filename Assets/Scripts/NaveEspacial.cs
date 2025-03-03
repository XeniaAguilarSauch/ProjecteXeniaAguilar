using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NaveEspacial : MonoBehaviour
{
    public Transform[] planetas;
    public float velocidad = 5f;
    private int indicePlaneta = 0;
    private bool esperandoRespuesta = false;
    private bool finalizado = false;

    public GameObject panelPregunta;
    public Text textoPregunta;
    public Button botonRespuesta1;
    public Button botonRespuesta2;
    public Transform sol;

    private void Start()
    {
        panelPregunta.SetActive(false);
        MoverAPlaneta();
    }

    private void Update()
    {
        if (!esperandoRespuesta)
        {
            if (!finalizado)
            {
                transform.position = Vector3.MoveTowards(transform.position, planetas[indicePlaneta].position, velocidad * Time.deltaTime);
                Vector3 direccion = planetas[indicePlaneta].position - transform.position;
                Quaternion rotacionMeta = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionMeta, Time.deltaTime * velocidad);

                if (Vector3.Distance(transform.position, planetas[indicePlaneta].position) < 0.1f)
                {
                    esperandoRespuesta = true;
                    MostrarPregunta(planetas[indicePlaneta].gameObject.name);
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, sol.position, velocidad * Time.deltaTime);
                Vector3 direccion = sol.position - transform.position;
                Quaternion rotacionMeta = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacionMeta, Time.deltaTime * velocidad);

                if (Vector3.Distance(transform.position, sol.position) < 0.1f)
                {
                    SceneManager.LoadScene("TerrainScene");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == planetas[indicePlaneta].gameObject.name)
        {
            esperandoRespuesta = true;
            MostrarPregunta(other.gameObject.name);
        }
    }

    void MostrarPregunta(string planeta)
    {
        panelPregunta.SetActive(true);

        switch (planeta)
        {
            case "Mercury":
                textoPregunta.text = "¿Cuál es la temperatura media en Mercurio?";
                AsignarRespuestas("430°C", "100°C");
                break;

            case "Venus":
                textoPregunta.text = "¿Qué gas compone la mayor parte de la atmósfera de Venus?";
                AsignarRespuestas("Dióxido de carbono", "Oxígeno");
                break;

            case "Earth":
                textoPregunta.text = "¿Cuántos satélites naturales tiene la Tierra?";
                AsignarRespuestas("1", "2");
                break;

            case "Mars":
                textoPregunta.text = "¿Cómo se llama el gran cañón en Marte?";
                AsignarRespuestas("Valles Marineris", "Gran Cañón de Marte");
                break;

            case "Jupiter":
                textoPregunta.text = "¿Cuál es el planeta más grande del sistema solar?";
                AsignarRespuestas("Júpiter", "Saturno");
                break;

            case "Saturn":
                textoPregunta.text = "¿Qué característica es famosa en Saturno?";
                AsignarRespuestas("Anillos", "Lunas grandes");
                break;

            case "Uranus":
                textoPregunta.text = "¿Cuál es el color de Urano?";
                AsignarRespuestas("Azul", "Verde");
                break;

            case "Neptune":
                textoPregunta.text = "¿Qué planeta está más alejado del Sol?";
                AsignarRespuestas("Neptuno", "Urano");
                break;

            case "Pluto":
                textoPregunta.text = "¿Cuál es el estado actual de Plutón en el sistema solar?";
                AsignarRespuestas("Planeta enano", "Planeta mayor");
                break;

            default:
                textoPregunta.text = "Pregunta no definida.";
                break;
        }

        botonRespuesta2.onClick.AddListener(RespuestaIncorrecta);
    }

    void AsignarRespuestas(string respuestaCorrecta, string respuestaIncorrecta)
    {
        bool respuestaCorrectaPrimero = Random.Range(0, 2) == 0;

        if (respuestaCorrectaPrimero)
        {
            botonRespuesta1.GetComponentInChildren<Text>().text = respuestaCorrecta;
            botonRespuesta2.GetComponentInChildren<Text>().text = respuestaIncorrecta;
            botonRespuesta1.onClick.AddListener(RespuestaCorrecta);
        }
        else
        {
            botonRespuesta1.GetComponentInChildren<Text>().text = respuestaIncorrecta;
            botonRespuesta2.GetComponentInChildren<Text>().text = respuestaCorrecta;
            botonRespuesta2.onClick.AddListener(RespuestaCorrecta);
        }
    }

    void RespuestaCorrecta()
    {
        panelPregunta.SetActive(false);
        esperandoRespuesta = false;

        if (indicePlaneta < planetas.Length - 1)
        {
            indicePlaneta++;
        }
        else
        {
            finalizado = true;
        }

        LimpiarListeners();
    }

    void RespuestaIncorrecta()
    {
        textoPregunta.text = "Respuesta incorrecta. Intenta de nuevo.";
    }

    void LimpiarListeners()
    {
        botonRespuesta1.onClick.RemoveAllListeners();
        botonRespuesta2.onClick.RemoveAllListeners();
    }

    void MoverAPlaneta()
    {
        if (indicePlaneta < planetas.Length)
        {
            esperandoRespuesta = false;
        }
    }
}







