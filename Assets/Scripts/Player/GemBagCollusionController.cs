using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBagCollusionController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Gem1")
        {
            foreach (Transform child in collision.transform)
            {
                child.gameObject.SetActive(false);
                child.parent = null;
            }
            collision.gameObject.SetActive(false);
            collision.transform.parent = null;
            collision.transform.GetComponent<MeshRenderer>().enabled = true;
            StartCoroutine(GameManager.Instance.AddScore(50));
        }
    }
}
