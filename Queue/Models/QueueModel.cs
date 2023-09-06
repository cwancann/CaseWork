using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//queue to manage backgound task
public class TaskQueue
{
    private readonly Queue<Func<Task>> _queue = new Queue<Func<Task>>();
    private readonly object _lock = new object();
    private bool _isProcessing = false;

    public async Task EnqueueTask(Func<Task> taskFunc)
    {
        lock (_lock)
        {
            _queue.Enqueue(taskFunc);

            if (!_isProcessing)
            {
                _isProcessing = true;
                ProcessQueueAsync();
            }
        }
    }

    private async Task ProcessQueueAsync()
    {
        while (true)
        {
            Func<Task> taskFunc;
            lock (_lock)
            {
                if (_queue.Count == 0)
                {
                    _isProcessing = false;
                    break;
                }

                taskFunc = _queue.Dequeue();
            }

            try
            {
                await taskFunc();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
