using System;

namespace practice_BeehiveControlOOPPractice
{
    abstract class Bee
    {
        public Bee(string input)
        {
            Job = input;
        }

        public string Job { get; protected set; }
        public abstract float CostPerShift { get; }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) DoJob();
        }

        protected abstract void DoJob(); //each bee will override this method
    }

    class Queen : Bee
    {
        public Queen() : base("Queen") 
        { 
            AssignBee("Honey Manufacturer"); 
            AssignBee("Nectar Collector"); 
            AssignBee("Egg Care"); 
        }

        private Bee[] workers = new Bee[0];
        private float eggs;
        private float unassignedworkers = 3;
        public const float EGGS_PER_SHIFT = 0.45f;
        public const float HONEY_PER_UNASSIGNED_WORKER = 0.5f;
        public string StatusReport { get; private set; }
        public override float CostPerShift { get { return 2.15f; } }

        private void AddWorker(Bee worker)
        {
            if (unassignedworkers >= 1)
            {
                unassignedworkers--;
                Array.Resize(ref workers, workers.Length + 1);
                workers[workers.Length - 1] = worker;
            }
        }

        public void AssignBee(string job)
        {
            switch (job)
            {
                case "Egg Care":
                    AddWorker(new EggCare(this));
                    break;
                case "Honey Manufacturer":
                    AddWorker(new HoneyManufacturer());
                    break;
                case "Nectar Collector":
                    AddWorker(new NectarCollector());
                    break;
            }
            UpdateStatusReport();
        }

        protected override void DoJob()
        {
            eggs += EGGS_PER_SHIFT;
            foreach (Bee bee in workers)
            {
                bee.WorkTheNextShift();
            }
            HoneyVault.ConsumeHoney(HONEY_PER_UNASSIGNED_WORKER * workers.Length);
            UpdateStatusReport();
        }

        public void CareForEggs(float eggsToConvert)
        {
            if (eggs >= eggsToConvert)
            {
                eggs -= eggsToConvert;
                unassignedworkers += eggsToConvert;
            }
        }

        private string WorkerStatus(string job)
        {
            int count = 0;
            foreach (Bee worker in workers)
                if (worker.Job == job) count++;
            string s = "s";
            if (count == 1) s = "";
            return $"{count} {job} bee{s}";

        }

        private void UpdateStatusReport()
        {
            StatusReport = $"Vault report:\n{HoneyVault.StatusReport}\n\n Egg count: {eggs:0.0}\n Unassigned workers: {unassignedworkers:0.0}\n {WorkerStatus("Nectar Collector")}\n {WorkerStatus("Honey Manufacturer")}\n {WorkerStatus("Egg Care")}\n TOTAL WORKERS: {workers.Length}";
        }
    }

    class HoneyManufacturer : Bee
    {
        public HoneyManufacturer() : base("Honey Manufacturer") { }

        public const float NECTAR_PROCESSED_PER_SHIFT = 33.15f;
        public override float CostPerShift { get { return 1.7f; } }

        protected override void DoJob()
        {
            HoneyVault.ConvertNectarToHoney(NECTAR_PROCESSED_PER_SHIFT);
        }
    }

    class NectarCollector : Bee
    {
        public NectarCollector() : base("Nectar Collector") { }

        public const float NECTAR_PROCESSED_PER_SHIFT = 33.25f;
        public override float CostPerShift { get { return 1.95f; } }

        protected override void DoJob()
        {
            HoneyVault.CollectNectar(NECTAR_PROCESSED_PER_SHIFT);
        }
    }

    class EggCare : Bee
    {
        public EggCare(Queen queen) : base("Egg Care") { this.queen = queen; }

        public const float CARE_PROGRESS_PER_SHIFT = 0.15f;
        public override float CostPerShift { get { return 1.35f; } }

        private Queen queen;

        protected override void DoJob()
        {
            queen.CareForEggs(CARE_PROGRESS_PER_SHIFT);
        }

    }
}
