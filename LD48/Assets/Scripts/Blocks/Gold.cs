namespace Blocks
{
    public class Gold : DestructibleBlock
    {
        protected override void Die()
        {
            // TODO: Drop Gold
            Destroy(this.gameObject);
        }
    }
}
