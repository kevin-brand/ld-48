namespace Blocks
{
    public class ExplosiveStone : DestructibleBlock
    {
        protected override void Die()
        {
            // TODO: Explode
            Destroy(this.gameObject);
        }
    }
}
