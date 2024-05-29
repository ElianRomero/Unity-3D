using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.AI;

public class Moviemient_Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform objetivo;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("El componente NavMeshAgent no está adjunto a este objetivo");
        }
        else if (objetivo == null)
        {
            Debug.LogError("El objetivo no está asignado. Asigne el objetivo al que la IA debe moverse");
        }
        else
        {
            MoverHaciaObjetivo();
        }
    }

    void MoverHaciaObjetivo()
    {
        if (navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(objetivo.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (navMeshAgent.isOnNavMesh)
        {
            navMeshAgent.SetDestination(objetivo.position);
        }
    }
}
