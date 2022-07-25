using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    private Transform[] playerTransforms;
    [SerializeField]
    private GameObject[] allPlayers;

        private void Start()
        {
            //GameObject[] allPlayers = GameObject.FindGameObjectsWithTag("Player") ;

            playerTransforms = new Transform[allPlayers.Length];

            for (int i = 0; i < allPlayers.Length; i++)
            {
                playerTransforms[i] = allPlayers[i].transform;
            }
        }

        public float yOffset = 2.0f;
        public float xOffset = 2.0f;
        public float minDistance = 2.0f;

        private float zMin, zMax, yMin, yMax;

        private void LateUpdate()
        {
            if (playerTransforms.Length == 0)
            {
                Debug.Log("have no found a player, make sure the player tag is on");
                return;
            }

            zMin = zMax = playerTransforms[0].position.z;
            yMin = yMax = playerTransforms[0].position.y;

            for (int i = 1; i < playerTransforms.Length; i++)
            {
                if (playerTransforms[i].position.z < zMin)
                    zMin = playerTransforms[i].position.z;

                if (playerTransforms[i].position.z > zMax)
                    zMax = playerTransforms[i].position.z;

                if (playerTransforms[i].position.y < yMin)
                    yMin = playerTransforms[i].position.y;

                if (playerTransforms[i].position.y > yMax)
                    yMax = playerTransforms[i].position.y;
            }

            float zMiddle = (zMin + zMax) / 2;
            float yMiddle = (yMin + yMax) / 2;
            float distance = zMax - zMin;

            if (distance < minDistance)
                distance = minDistance;

            transform.position = new Vector3( zMiddle, yMiddle + yOffset, -distance);
        }
}
