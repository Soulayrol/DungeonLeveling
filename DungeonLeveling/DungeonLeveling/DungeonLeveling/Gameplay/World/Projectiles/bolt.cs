using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonLeveling
{
    public class Bolt : Projectile
    {
        public List<Line> Segments = new List<Line>();
        public float Alpha { get; set; }
        public float FadeOutRate { get; set; }
        public Color Tint { get; set; }
        public bool IsComplete { get { return Alpha <= 0; } }
        private TimerMaster timerBolt = new TimerMaster(2000);
        public string PathLighting;
        public string PathHalfCircle;
        static Random rand = new Random();
        private Vector2 origine;
        private Vector2 target;

        public Bolt(Vector2 Pos, Unit Owner, Vector2 Target) : base(null, Pos, new Vector2(5, 50), Owner, Target)
        {
            PathLighting = "2d/Projectiles/Light";
            PathHalfCircle = "2d/Projectiles/HalfCircle";
            timer = timerBolt;
            Tint = new Color(0.9f, 0.8f, 1f);
            Alpha = 1f;
            FadeOutRate = 0.03f;
            Segments = CreateBolt(Pos, Target, 1f);
            origine = Pos;
            target = Target;
        }

        protected static List<Line> CreateBolt(Vector2 source, Vector2 dest, float thickness)
        {
            var results = new List<Line>();
            Vector2 tangent = dest - source;
            Vector2 normal = Vector2.Normalize(new Vector2(tangent.Y, -tangent.X));
            float length = tangent.Length();
            

            List<float> positions = new List<float>();
            positions.Add(0);

            for (int i = 0; i < length / 4; i++)
                positions.Add(Rand(0, 1));

            positions.Sort();

            const float Sway = 80;
            const float Jaggedness = 1 / Sway;

            Vector2 prevPoint = source;
            float prevDisplacement = 0;
            for (int i = 1; i < positions.Count; i++)
            {
                float pos = positions[i];

                // used to prevent sharp angles by ensuring very close positions also have small perpendicular variation.
                float scale = (length * Jaggedness) * (pos - positions[i - 1]);

                // defines an envelope. Points near the middle of the bolt can be further from the central line.
                float envelope = pos > 0.95f ? 20 * (1 - pos) : 1;

                float displacement = Rand(-Sway, Sway);
                displacement -= (displacement - prevDisplacement) * (1 - scale);
                displacement *= envelope;

                Vector2 point = source + pos * tangent + displacement * normal;
                results.Add(new Line(prevPoint, point, thickness));
                prevPoint = point;
                prevDisplacement = displacement;
            }

            results.Add(new Line(prevPoint, dest, thickness));

            return results;
        }

        private static float Rand(float min, float max)
        {
            return (float)rand.NextDouble() * (max - min) + min;
        }

        public override bool CollisionTest(List<Unit> units)
        {
            bool test = false;
            for (int i = 0; i < units.Count && test == false; i++)
            {
                test = Global.collision.lineRect(origine.X, origine.Y, target.X, target.Y, units[i].BoudingBox.X, units[i].BoudingBox.Y, units[i].BoudingBox.Width, units[i].BoudingBox.Height);
                if (test) { units[i].GetHit(0.7f); }
            }
            return test;
        }

        public override void Draw()
        {
            if (Alpha <= 0)
                return;
            
            Global.spriteBatch.End();
            Global.spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Additive);
            foreach (var segment in Segments)
            {
                Texture2D Lighting = Global.content.Load<Texture2D>(PathLighting);
                Texture2D HalfCircle = Global.content.Load<Texture2D>(PathHalfCircle);
                segment.Draw(Lighting, HalfCircle, Tint * (Alpha * 0.9F));
            }
            Global.spriteBatch.End();
            // Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, transformMatrix: Global.camera._transform, samplerState: SamplerState.PointClamp);
            Global.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, samplerState: SamplerState.PointClamp);
        }

        public override void Update(List<Unit> units)
        {
            timer.UpdateTimer();
            CollisionTest(units);
            if (timer.Test())
                done = true;
            Alpha -= FadeOutRate;
        }
    }
}
