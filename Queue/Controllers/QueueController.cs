using Microsoft.AspNetCore.Mvc;

public class MyController : Controller
{
    private readonly TaskQueue _taskQueue = new TaskQueue();

    public async Task<ActionResult> SomeAction()
    {
        // Enqueue a background task
        await _taskQueue.EnqueueTask(async () =>
        {
            // Perform some background processing here
            await DoBackgroundWorkAsync();
        });

        // controller action continues without waiting for the background task to complete
        return View();
    }

    private async Task DoBackgroundWorkAsync()
    {
        // logic
        await Task.Delay(TimeSpan.FromSeconds(5));
    }
}
