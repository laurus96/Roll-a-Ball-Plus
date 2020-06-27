using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWall : MonoBehaviour
{
    public GameObject warningText;


    private void Awake()
    {
        warningText.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            CollectCoin.score -= 5;
            warningText.SetActive(true);
            StartCoroutine(warningSpawn());
            

        }
    }

    IEnumerator warningSpawn()
    {
        yield return new WaitForSeconds(5);
        warningText.SetActive(false);

    }
}
