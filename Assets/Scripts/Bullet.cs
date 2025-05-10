using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 8f; //ź���� �ӷ�
    private Rigidbody bulletRigidbody; //�̵��� ����� ������ٵ� ������Ʈ
    
    void Start()
    {   //���� ������Ʈ���� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //������ٵ��� �ӵ� = ���� ���� * �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ���� ���� ������Ʈ�� Player �±׸� ���� ���
        if (other.tag == "player")
        {
            //���� ���� ������Ʈ���� PlayerController ������Ʈ ��������
            PlayerController playerController = other.GetComponent<PlayerController>();

            //�������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if (playerController != null)
            {
                //���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.Die();

            }
        }
    }
}
