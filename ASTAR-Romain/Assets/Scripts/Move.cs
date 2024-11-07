using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private Transform _placeToGo;
    [SerializeField] private GameObject _follower;
    private Vector3 _mousePos;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 direction = _mousePos - _follower.transform.position;

        // Ca c'est pour la 3D, ca ne marche pas dans la 2D
        //_follower.transform.rotation = Quaternion.LookRotation(direction, Vector3.forward);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _follower.transform.rotation = Quaternion.Euler(0,0,angle);

        if (direction.magnitude <= 0.3f)
        {
            return;
        }

        Vector3 velocite = 5f * Time.deltaTime * direction.normalized;

        // ça fait avancer le follower là où j'ai appuyer avec la souris, mais le seul problème que j'ai.
        // c'est que le follower commence à ralentir dès qu'il se raproche de là ou j'ai appuyer.
        _follower.transform.Translate( new Vector3(velocite.x, velocite.y, 0), Space.World);
    }
}
