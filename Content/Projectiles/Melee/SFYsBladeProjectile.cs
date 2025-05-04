using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllStuffFluffChanges.Content.Projectiles
{
    public class SFYsBladeProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 30; // Adjust width
            Projectile.height = 30; // Adjust height
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1; // Infinite penetration
            Projectile.timeLeft = 300; // Lifetime in ticks (5 seconds)
            Projectile.light = 0.5f; // Adds light
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false; // Pass through tiles
        }

        public override void AI()
        {
            // Add visual effects (e.g., dust or flames)
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Fire);
            }

            // Rotate the projectile to match the arc of the swing
            Projectile.rotation += 0.4f * (float)Projectile.direction;
        }
    }
}