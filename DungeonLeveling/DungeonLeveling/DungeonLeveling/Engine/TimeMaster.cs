using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Xml;

namespace DungeonLeveling
{
    public class TimerMaster
    {
        public bool isDone;
        public int mSec;
        protected TimeSpan timer = new TimeSpan();

        public TimerMaster(int m)
        {
            isDone = false;
            mSec = m;
        }
        
        public int Timer
        {
            get { return (int)timer.TotalMilliseconds; }
        }

        public void UpdateTimer()
        {
            timer += Global.gameTime.ElapsedGameTime;
        }

        public void UpdateTimer(float SPEED)
        {
            timer += TimeSpan.FromTicks((long)(Global.gameTime.ElapsedGameTime.Ticks * SPEED));
        }

        public virtual void AddToTimer(int MSEC)
        {
            timer += TimeSpan.FromMilliseconds((long)(MSEC));
        }

        public bool Test()
        {
            if (timer.TotalMilliseconds >= mSec || isDone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetToZero()
        {
            timer = TimeSpan.Zero;
            isDone = false;
        }

        public void SetTimer(TimeSpan TIME)
        {
            timer = TIME;
        }

        public virtual void SetTimer(int MSEC)
        {
            timer = TimeSpan.FromMilliseconds((long)(MSEC));
        }
    }
}
