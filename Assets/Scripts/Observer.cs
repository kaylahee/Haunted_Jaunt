using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // 플레이어의 캐릭터 감지 위한 관찰자 클래스
    public Transform player;
    public GameEnding gameEnding;
    // 캐릭터가 트리거 내에 있는지에 대한 여부를 저장
    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        // 범위 안에 있는지 확인
        if(other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    void Update()
    {
        if(m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }

}
