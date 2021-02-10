using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _minVerticalScale = 1;
    [SerializeField] float _maxVerticalScale = 3;
    [SerializeField] float _minHorizontalScale = 1;
    [SerializeField] float _maxHorizontalScale = 3;
    [SerializeField] [Range(0.1f, 1)] float _scaleSpeed = 1;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ScalingProccess();
        }
    }



    private void ScalingProccess()
    {
        float y = Input.GetAxis("Mouse Y") * _scaleSpeed;
        Vector3 scale = transform.localScale;

        if (scale.y + y > _minVerticalScale && scale.y + y < _maxVerticalScale)
        {
            this.transform.localScale = new Vector3(scale.x, scale.y + y, scale.z);
        }

        float scaleX = 5 / (scale.y + y);
        // if (scale.x - y > _minHorizontalScale && scale.x - y < _maxHorizontalScale)
        // {
        //     this.transform.localScale = new Vector3(scale.x - y, transform.localScale.y, scale.z);
        // }

        if (scaleX > _minHorizontalScale && scaleX < _maxHorizontalScale)
        {
            this.transform.localScale = new Vector3(scaleX, transform.localScale.y, scale.z);

        }

    }
}
