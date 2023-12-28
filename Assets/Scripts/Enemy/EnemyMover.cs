using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CT239_TowDef
{
    public class EnemyMover : MonoBehaviour
    {
        /// <summary>
        /// Create a path for the enemy move
        /// </summary>
        [SerializeField] List<Waypoint> path = new List<Waypoint>();

        /// <summary>
        /// Delay time to reach the next Waypoint
        /// </summary>
        [SerializeField] float waitTime = 1f;

        /// <summary>
        /// Minimum and the maximum speed of the enemy
        /// </summary>
        [SerializeField][Range(0f, 5f)] float speed = 1f;

        private Enemy enemy; 

        private void Start()
        {
               FindPath();
               if (!GameManager.isGameOver)
               {
                    ReturnToStart();
                    StartCoroutine(FollowPath());
               }
               enemy = GetComponent<Enemy>();
        }


        /// <summary>
        /// Make a path for the enemy
        /// </summary>
        void FindPath()
        {
            path.Clear();

            GameObject parent = GameObject.FindGameObjectWithTag("Path");
            Debug.Log("added" + parent.name);
            foreach (Transform child in parent.transform)
            {
                Waypoint waypoint = child.GetComponent<Waypoint>();

                if (waypoint != null)  path.Add(waypoint); 
  
            }
        }

        /// <summary>
        /// Enemy follow the path
        /// </summary>
        /// <returns></returns>
        IEnumerator FollowPath()
        {
            foreach (var waypoint in path)
            {
                Vector3 startPosition = transform.position;
                Vector3 endPosition = waypoint.transform.position;
                float travelPercent = 0f;

                transform.LookAt(endPosition);

                while (travelPercent < 1f)
                {
                    travelPercent += Time.deltaTime * speed;
                    transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                    yield return new WaitForEndOfFrame();
                }
            }
            FinishPath();
        }

        /// <summary>
        /// Make the enemy start at the first waypoint
        /// </summary>
        private void ReturnToStart()
        {
            transform.position = path[0].transform.position;
        }

        private void FinishPath()
        {
            enemy.ReducePlayerHealth();
            Destroy(gameObject);
        }
    }
}
