using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f; //탄알의 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지디바디 컴포넌트
    
    void Start()
    {   //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 PlayerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if (playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();

            }
        }
    }
}
