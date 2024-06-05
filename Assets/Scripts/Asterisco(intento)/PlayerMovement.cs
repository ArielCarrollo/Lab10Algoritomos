using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public List<Vector3> path;
    public float speed = 2f;
    private int targetIndex;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        while (true)
        {
            Vector3 targetPosition = path[targetIndex];
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }

            targetIndex = (targetIndex + 1) % path.Count;
            if (targetIndex == 0)
            {
                FindObjectOfType<Manager>().PauseGame();
                yield return new WaitForSeconds(2);
                FindObjectOfType<Manager>().ResumeGame();
            }
        }
    }
}
