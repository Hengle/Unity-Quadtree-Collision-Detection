﻿using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(QuadtreeCanUpwardsCollider))]
public class QuadtreeCanUpwardsDetector : MonoBehaviour
{
    QuadtreeCanUpwardsCollider _quadTreeCollider;

    List<GameObject> _colliders = new List<GameObject>();


    private void Awake()
    {
        _quadTreeCollider = GetComponent<QuadtreeCanUpwardsCollider>();
    }

    private void OnEnable()
    {
        _quadTreeCollider.collisionEvent += OnQuadtreeCollision;
    }

    private void OnDisable()
    {
        _quadTreeCollider.collisionEvent -= OnQuadtreeCollision;
    }

    void OnQuadtreeCollision(GameObject collisionGameObject)
    {
        _colliders.Add(collisionGameObject);
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach (GameObject collider in _colliders)
            if (collider)                           //从碰撞发生到绘制Gizmo中间有很短的时间，如果在这期间物体被销毁了，就获取不到Trnanform出bug，因此要先判断
                Gizmos.DrawLine(transform.position, collider.transform.position);
        _colliders.Clear();
    }
}
