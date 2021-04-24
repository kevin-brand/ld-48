namespace Blocks
{
    public class Stone : DestructibleBlock
    {
        protected override void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
