using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFarmacist : MonoBehaviour
{
    public Transform[] pathPoints;
    public float speed = 2f;
    private int currentPointIndex = 0;

    private void Update()
    {
        if (pathPoints.Length == 0)
            return;

        // Przeciwnik zmierza do obecnego punktu
        Transform targetPoint = pathPoints[currentPointIndex];
        Vector3 direction = (targetPoint.position - transform.position).normalized;


        transform.position += direction * speed * Time.deltaTime;


        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % pathPoints.Length;
        }
    }
    
    private void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Length == 0)
            return;

        Gizmos.color = Color.red;
        
        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (pathPoints[i] != null)
            {
                Gizmos.DrawSphere(pathPoints[i].position, 0.2f);
            }
        }
        
        Gizmos.color = Color.yellow;
        for (int i = 0; i < pathPoints.Length; i++)
        {
            if (pathPoints[i] != null && pathPoints[(i + 1) % pathPoints.Length] != null)
            {
                Gizmos.DrawLine(pathPoints[i].position, pathPoints[(i + 1) % pathPoints.Length].position);
            }
        }
    }
}