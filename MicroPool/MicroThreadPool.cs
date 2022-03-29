using System.Collections.Concurrent;

namespace MicroPool
{
    public static class TaskPool
    {
        private static int _counter;
        private static int _counterMax = Environment.ProcessorCount * 2;
        private static readonly ConcurrentQueue<Task> _tasks = new();

        public static bool AddTask(Task task)
        {
            if (_counter >= _counterMax) return false;

            if (task == null) throw new ArgumentNullException();

            _tasks.Enqueue(task);
            _counter++;

            return true;
        }

        public static bool RemoveTask(int idTask)
        {
            var task = _tasks.SingleOrDefault(task => task.Id == idTask);

            if (task == null) return false;

            if (!task.IsCompleted) return false;

            if (_tasks.TryDequeue(out task))
            {
                _counter--;
                return true;
            }
            else
                return false;
        }

        public static bool StartTask(int idTask)
        {
            var task = _tasks.SingleOrDefault(task => task.Id == idTask);

            if (task == null) return false;

            task.Start();

            return true;
        }

        public static IEnumerable<string> GetAllTasks()
        {
            foreach (var task in _tasks)
                yield return $"{task.Id} {task.Status}";
        }

        public static void ClearAllTasks()
        {
            _tasks.Clear();
            _counter = 0;
        }
    }
}
