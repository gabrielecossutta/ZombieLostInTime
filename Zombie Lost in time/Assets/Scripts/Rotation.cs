using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform Target;
    private Vector3 previousTargetPosition;

    private void Start()
    {
        previousTargetPosition = Target.position;
    }

    private void Update()
    {
        // Calcola la differenza di posizione del target rispetto al frame precedente
        Vector3 positionDelta = Target.position - previousTargetPosition;

        // Ruota attorno al target
        transform.RotateAround(Target.position, Vector3.up, 300 * Time.deltaTime);

        // Aggiorna la posizione precedente del target
        previousTargetPosition = Target.position;

        // Applica la differenza di posizione al GameObject per compensare la rotazione
        transform.position += positionDelta;
    }
}