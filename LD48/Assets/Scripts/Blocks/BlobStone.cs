namespace Blocks
{
    public class BlobStone : DestructibleBlock
    {
        protected override void Die()
        {
            // TODO: Spawn Blob
            Destroy(this.gameObject);
        }
    }
}
