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
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
            {
                // Emit dusts when the sword is swung
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.);
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            // 60 frames = 1 second
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}