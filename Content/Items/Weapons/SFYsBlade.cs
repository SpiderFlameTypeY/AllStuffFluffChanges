using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AllStuffFluffChanges.Content.Items.Weapons
{
    public class SFYsBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 75;
            Item.height = 82;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20; //60fps
            Item.useAnimation = 20; //useTime usually
            Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 90;
            Item.knockBack = 8; //Max20
            Item.crit = 6;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ModContent.ProjectileType<SFYsBladeProjectile>();
            Item.shootSpeed = 10f;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                // Emit dusts when the sword is swung
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.174);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
    
    public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        // Adjust projectile spawn position
        Vector2 spawnPos = position + new Vector2(velocity.X * 10f, velocity.Y * 10f);

        // Spawn the projectile
        Projectile.NewProjectile(source, spawnPos, velocity, ModContent.ProjectileType<SFYsBladeProjectile>(), damage, knockback, player.whoAmI);

        return false; // Return false to prevent vanilla projectile behavior
    }
    
    Recipe recipe = CreateRecipe();
    recipe.AddIngredient(ItemID.Volcano);
    recipe.AddIngredient(ItemID.SoulofMight, 20);
    recipe.AddTile(TileID.MythrilAnvil);
    recipe.Register();
}