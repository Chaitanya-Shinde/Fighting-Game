using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public float damage = 2f;
    public bool isPlayer, isEnemy;
    public GameObject hitVFX_Prefab;
    //public Vector3 LeftArmHitPosition, RightArmHitPosition, LeftLegHitPosition, RightLegHitPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
       
    }

    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if(hit.Length >0)
        {
            print("we hit" + hit[0].gameObject.name);
            

            if(isPlayer)
            {
                Vector3 hitVFX_POS = hit[0].transform.position;
                hitVFX_POS.y += 1.13f ;

                if(hit[0].transform.forward.x > 0)
                {
                    hitVFX_POS.x += 0.3f;
                }
                else if(hit[0].transform.forward.x <0)
                {
                    hitVFX_POS.x -= 0.3f;
                }

                //Instantiate(hitVFX_Prefab, hitVFX_POS, Quaternion.identity);
                if(gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                {
                    Instantiate(hitVFX_Prefab, GameObject.FindWithTag(Tags.RIGHT_LEG_TAG).GetComponent<Transform>().position, Quaternion.identity);
                }

                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                {
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                    if(gameObject.CompareTag(Tags.LEFT_ARM_TAG))
                    {
                        Instantiate(hitVFX_Prefab, GameObject.FindWithTag(Tags.LEFT_ARM_TAG).GetComponent<Transform>().position, Quaternion.identity);
                    }
                    else if(gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                    {
                        Instantiate(hitVFX_Prefab, GameObject.FindWithTag(Tags.RIGHT_LEG_TAG).GetComponent<Transform>().position, Quaternion.identity);
                    }
                    
                    
                }
                else
                {
                    Debug.Log("knockdown false");
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                    
                }

            }

            if(isEnemy)
            {
                Vector3 hitVFX_POS = hit[0].transform.position;
                hitVFX_POS.y += 1.13f;

                if(hit[0].transform.forward.x > 0)
                {
                    hitVFX_POS.x += 0.3f;
                }
                else if(hit[0].transform.forward.x <0)
                {
                    hitVFX_POS.x -= 0.3f;
                }

                //Instantiate(hitVFX_Prefab, hitVFX_POS, Quaternion.identity);

                if(gameObject.CompareTag(Tags.LEFT_ARM_TAG) || gameObject.CompareTag(Tags.RIGHT_LEG_TAG))
                {
                    Debug.Log("Knockdown player");
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, true);
                    
                }
                else
                {
                    Debug.Log("knockdown false");
                    hit[0].GetComponent<HealthScript>().ApplyDamage(damage, false);
                }
            }

            gameObject.SetActive(false);
        }
    }
}
