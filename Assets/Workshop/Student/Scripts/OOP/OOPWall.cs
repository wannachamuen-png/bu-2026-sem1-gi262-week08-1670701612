using UnityEngine;

namespace Solution
{
    public class OOPWall : Identity
    {
        public int Damage;
        public bool IsIceWall;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            IsIceWall = Random.Range(0, 100) < 20;

            if (IsIceWall && spriteRenderer != null)
            {
                spriteRenderer.color = Color.blue;
            }
        }

        public override bool Hit()
        {
            if (mapGenerator == null)
            {
                Debug.LogError("OOPWall: mapGenerator is not assigned.", this);
                return false;
            }

            if (mapGenerator.player == null)
            {
                Debug.LogError("OOPWall: mapGenerator.player is not assigned.", this);
                return false;
            }

            if (IsIceWall)
            {
                mapGenerator.player.TakeDamage(Damage, true);
            }
            else
            {
                mapGenerator.player.TakeDamage(Damage);
            }

            if (positionX >= 0 && positionX < mapGenerator.X &&
                positionY >= 0 && positionY < mapGenerator.Y)
            {
                mapGenerator.mapdata[positionX, positionY] = null;
            }

            Destroy(gameObject);
            return false;
        }
    }
}