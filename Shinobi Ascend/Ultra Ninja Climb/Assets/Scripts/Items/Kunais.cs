using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunais : MonoBehaviour
{
    public float trapDetectionDist;

    public LayerMask hMask;

    public GameObject originalKunai;

    public float offsetSpeed;

    List<GameObject> spawnedKunais = new List<GameObject>();

    public Transform shootPoint;

    public AudioClip shootAudio;

    public void ShootKunai(Vector2 direction, AudioExecution aExec)
    {
        RaycastHit2D hit = Physics2D.CircleCast(shootPoint.position, 0.7f, direction, trapDetectionDist, hMask);

        if(hit.collider != null)
        {
            GameObject k = Instantiate(originalKunai, shootPoint.position, Quaternion.identity);

            SingleKunai singleK = k.GetComponent<SingleKunai>();
            singleK.movementSpeed = direction.magnitude * 2;
            singleK.target = hit.collider.gameObject;
            singleK.k = this;

            k.transform.LookAt(hit.collider.transform.position);
                        
            k.transform.Rotate(k.transform.up * 270);

            spawnedKunais.Add(k);

            PlaySound(aExec);

            GameManager.instance.currentKunais--;
        }
    }

    public void PlaySound(AudioExecution aExec)
    {
        aExec.PlayAudio(shootAudio);
    }

    public void RepositionKunais(float offset)
    {
        foreach(GameObject k in spawnedKunais)
        {
            k.transform.position = new Vector3(k.transform.position.x, k.transform.position.y - offset, k.transform.position.z);
        }
    }

    public void DestroyKunai(SingleKunai k)
    {
        if(spawnedKunais.Contains(k.gameObject))
        {
            spawnedKunais.Remove(k.gameObject);
            Destroy(k.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 0.70f);
    }
}
