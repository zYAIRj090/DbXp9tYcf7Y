// 代码生成时间: 2025-10-10 21:54:04
using System;
using System.Collections.Generic;

namespace VirtualLabApp
{
    /// <summary>
    /// VirtualLab class represents a virtual laboratory environment for conducting experiments.
    /// </summary>
    public class VirtualLab
    {
        private List<Experiment> experiments;

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualLab"/> class.
        /// </summary>
        public VirtualLab()
        {
            experiments = new List<Experiment>();
        }

        /// <summary>
        /// Adds a new experiment to the virtual lab.
        /// </summary>
        /// <param name="experiment">The experiment to add.</param>
        public void AddExperiment(Experiment experiment)
        {
            if (experiment == null)
            {
                throw new ArgumentNullException(nameof(experiment), "Experiment cannot be null.");
            }

            experiments.Add(experiment);
        }

        /// <summary>
        /// Removes an experiment from the virtual lab.
        /// </summary>
        /// <param name="experiment">The experiment to remove.</param>
        public void RemoveExperiment(Experiment experiment)
        {
            if (experiment == null)
            {
                throw new ArgumentNullException(nameof(experiment), "Experiment cannot be null.");
            }

            experiments.Remove(experiment);
        }

        /// <summary>
        /// Conducts an experiment by executing the experiment's run method.
        /// </summary>
        /// <param name="experiment">The experiment to conduct.</param>
        public void ConductExperiment(Experiment experiment)
        {
            if (experiment == null)
            {
                throw new ArgumentNullException(nameof(experiment), "Experiment cannot be null.");
            }

            try
            {
                experiment.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error conducting experiment: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves all experiments in the virtual lab.
        /// </summary>
        /// <returns>A list of experiments.</returns>
        public List<Experiment> GetAllExperiments()
        {
            return new List<Experiment>(experiments);
        }
    }

    /// <summary>
    /// Experiment class represents a single experiment in the virtual lab.
    /// </summary>
    public abstract class Experiment
    {
        /// <summary>
        /// Executes the experiment.
        /// </summary>
        public abstract void Run();
    }

    /// <summary>
    /// Example experiment that performs a simple operation.
    /// </summary>
    public class SimpleExperiment : Experiment
    {
        /// <summary>
        /// Executes the simple experiment.
        /// </summary>
        public override void Run()
        {
            Console.WriteLine("Simple experiment is running...");
            // Perform experiment operations here.
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            VirtualLab lab = new VirtualLab();

            try
            {
                Experiment simpleExp = new SimpleExperiment();
                lab.AddExperiment(simpleExp);

                lab.ConductExperiment(simpleExp);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
