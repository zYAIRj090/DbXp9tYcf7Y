// 代码生成时间: 2025-09-19 06:23:07
using System;
using System.Threading.Tasks;
using System.Timers;

// 定时任务调度器类
public class ScheduledTaskScheduler
{
    private Timer _timer;
    private readonly Action _task;
    private readonly TimeSpan _interval;
    private readonly bool _autoReset;

    // 构造函数初始化任务和时间间隔
    public ScheduledTaskScheduler(Action task, TimeSpan interval, bool autoReset = true)
    {
        _task = task ?? throw new ArgumentNullException(nameof(task));
        _interval = interval;
        _autoReset = autoReset;
        _timer = new Timer(interval.TotalMilliseconds) { AutoReset = autoReset };

        // 设置计时器的Elapsed事件处理程序
        _timer.Elapsed += OnTimedEvent;
    }

    // 开始执行定时任务
    public void Start()
    {
        if (_timer == null)
            throw new InvalidOperationException("Timer has not been initialized.");

        _timer.Start();
    }

    // 停止执行定时任务
    public void Stop()
    {
        _timer.Stop();
    }

    // 计时器事件处理方法
    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        try
        {
            // 执行用户定义的任务
            _task.Invoke();
        }
        catch (Exception ex)
        {
            // 处理异常情况
            Console.WriteLine($"Error occurred: {ex.Message}");
        }
    }

    // 销毁定时器
    public void Dispose()
    {
        _timer?.Dispose();
    }
}

// 使用示例
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Scheduled Task Scheduler Example");

        // 定义需要周期性执行的任务
        Action timedTask = () => Console.WriteLine("Task executed at: " + DateTime.Now);

        // 创建定时任务调度器实例，每5秒执行一次
        using (var scheduler = new ScheduledTaskScheduler(timedTask, TimeSpan.FromSeconds(5)))
        {
            scheduler.Start();
            Console.WriteLine("Press any key to stop...