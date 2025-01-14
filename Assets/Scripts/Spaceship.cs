using UnityEngine;

public class Spaceship : MonoBehaviour

{
    private Bounds _cameraBounds;
    public Projectile projectilePrefab;
    public float speed = 5f;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        var height = Camera.main.orthographicSize * 2f;
        var width = height * Camera.main.aspect;

        var size = new Vector3(width, height);

        _cameraBounds = new Bounds(Vector3.zero, size);

        _spriteRenderer = GetComponent<SpriteRenderer>();

    }


    void Update()
    {
        ApplyMovement();
        FireProjectile();
    }

    void LateUpdate()
    {
        var newPosition = transform.position;

        var spriteWidth = _spriteRenderer.sprite.bounds.extents.x;
        var spriteHeight = _spriteRenderer.sprite.bounds.extents.y;


        newPosition.x = Mathf.Clamp(transform.position.x, _cameraBounds.min.x + 0.5f, _cameraBounds.max.x - spriteWidth);
        newPosition.y = Mathf.Clamp(transform.position.y, _cameraBounds.min.y + 0.5f, _cameraBounds.max.y - spriteHeight);


            transform.position = newPosition;
    }
    void FireProjectile()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }

    void ApplyMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate(Time.deltaTime * speed * new Vector3(horizontal, vertical));
    }
}
