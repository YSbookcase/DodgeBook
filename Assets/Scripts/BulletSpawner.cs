using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð� 



    void Start()
    {

        timeAfterSpawn = 0f;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;

    }


    void Update()
    {
        //timeAfterSpawn ����
        timeAfterSpawn += Time.deltaTime;
        //�ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if (timeAfterSpawn >= spawnRate)
        {
            //������ �ð��� ����
            timeAfterSpawn = 0f;

            //bulletPrefab�� ��������
            //transform.position ��ġ�� transform.rotation ȸ������ ����
            GameObject bullet
                = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
            transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
