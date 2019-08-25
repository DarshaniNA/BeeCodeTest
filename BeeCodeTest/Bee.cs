using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeeCodeTest
{
    public class Bee
    {
        static int nextId;
        public int BeeID { get; private set; }
        public Bee()
        {
            BeeID = Interlocked.Increment(ref nextId);
        }
        private float BeeHealth = 100;
        public string BeeStatus = "Alive";

        public void TakeDamage(int damage, string status)
        {
            if (status.Equals("Alive"))
            {
                if (damage > 0 && damage < 100)
                {
                    BeeHealth -= damage;
                }
            }
        }

        public float CurrentHealth()
        {
            return BeeHealth;
        }

        public virtual void CheckBeeStatus()
        {
        }

    }

    public class WorkerBee : Bee
    {
        public override void CheckBeeStatus()
        {
            base.CheckBeeStatus();
            if (CurrentHealth() < 70)
            {
                BeeStatus = "Dead";
            }
            else
            {
                BeeStatus = "Alive";
            }
        }
    }
    public class QueenBee : Bee
    {
        public override void CheckBeeStatus()
        {
            base.CheckBeeStatus();
            if (CurrentHealth() < 20)
            {
                BeeStatus = "Dead";
            }
            else
            {
                BeeStatus = "Alive";
            }
        }
    }
    public class DroneBee : Bee
    {
        public override void CheckBeeStatus()
        {
            base.CheckBeeStatus();
            if (CurrentHealth() < 50)
            {
                BeeStatus = "Dead";
            }
            else
            {
                BeeStatus = "Alive";
            }
        }
    }
}
