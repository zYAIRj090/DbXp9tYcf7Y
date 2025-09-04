// 代码生成时间: 2025-09-04 18:53:27
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

/// <summary>
/// A simple scheduled task scheduler that can schedule tasks to run at specific intervals.
/// </summary>
public class ScheduledTaskScheduler
{
    private readonly Timer _timer;
    private readonly Action _taskAction;
    private readonly TimeSpan _interval;
    private bool _isRunning = false;

    /// <summary>
    /// Initializes a new instance of the ScheduledTaskScheduler class.
    /// </summary>
    /// <param name="taskAction">The action to be executed periodically.</param>
    /// <param name="interval">The time interval between executions.</param>
    public ScheduledTaskScheduler(Action taskAction, TimeSpan interval)
    {
        _taskAction = taskAction ?? throw new ArgumentNullException(nameof(taskAction));
        _interval = interval;
        _timer = new Timer(ExecuteTask);
    }

    /// <summary>
    /// Starts the scheduled task.
    /// </summary>
    public void Start()
    {
        if (_isRunning)
        {
            throw new InvalidOperationException("Task is already running.");
        }

        _timer.Interval = _interval.TotalMilliseconds;
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Start();
        _isRunning = true;
    }

    /// <summary>
    /// Stops the scheduled task.
    /// </summary>
    public void Stop()
    {
        if (!_isRunning)
        {
            throw new InvalidOperationException("Task is not running.");
        }

        _timer.Stop();
        _timer.Elapsed -= OnTimedEvent;
        _isRunning = false;
    }

    /// <summary>
    /// The method to be called when the timer elapses.
    /// </summary>
    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        try
        {
            _taskAction();
        }
        catch (Exception ex)
        {
            // Handle exceptions that may occur during task execution.
            Console.WriteLine($"Error executing task: {ex.Message}");
        }
    }

    /// <summary>
    /// Executes the task immediately without waiting for the next interval.
    /// </summary>
    public void ExecuteTask()
    {
        _taskAction();
    }
}

/// <summary>
/// Example usage of the ScheduledTaskScheduler.
/// </summary>
public class Program
{
    public static void Main()
    {
        // Example task that prints the current time to the console.
        Action printTimeTask = () => Console.WriteLine($"Current time: {DateTime.Now}");

        // Create a new scheduler instance that runs the task every 5 seconds.
        var scheduler = new ScheduledTaskScheduler(printTimeTask, TimeSpan.FromSeconds(5));

        // Start the scheduler.
        scheduler.Start();

        // Keep the console open for demonstration purposes.
        Console.WriteLine("Press any key to stop the scheduler...