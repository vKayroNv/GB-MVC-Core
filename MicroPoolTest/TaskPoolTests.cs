using MicroPool;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace MicroPoolTest
{
    public class TaskPoolTests
    {
        void TestTask()
        {
            Thread.Sleep(10000);
        }

        [Fact]
        public void AddTask_Limit()
        {
            TaskPool.ClearAllTasks();

            for (int i = 0; i < Environment.ProcessorCount * 2; i++)
            {
                TaskPool.AddTask(new Task(TestTask));
            }

            Assert.False(TaskPool.AddTask(new Task(TestTask)));
        }

        [Fact]
        public void AddTask_AddNull()
        {
            TaskPool.ClearAllTasks();

            Type type = typeof(ArgumentNullException);

            Assert.Throws(type, () => TaskPool.AddTask(null));
        }

        [Fact]
        public void AddTask()
        {
            TaskPool.ClearAllTasks();

            var task = new Task(TestTask);

            var expectedEntry = $"{task.Id} {task.Status}";

            Assert.True(TaskPool.AddTask(task));

            foreach (var actualEntry in TaskPool.GetAllTasks())
                Assert.Equal(expectedEntry, actualEntry);
        }

        [Fact]
        public void RemoveTask_WrongId()
        {
            TaskPool.ClearAllTasks();

            Assert.False(TaskPool.RemoveTask(0));
        }

        [Fact]
        public void RemoveTask()
        {
            TaskPool.ClearAllTasks();

            var task = new Task(TestTask);
            TaskPool.AddTask(task);

            Assert.True(TaskPool.RemoveTask(task.Id));
        }

        [Fact]
        public void StartTask_WrongId()
        {
            TaskPool.ClearAllTasks();

            Assert.False(TaskPool.StartTask(0));
        }

        [Fact]
        public void StartTask()
        {
            TaskPool.ClearAllTasks();

            var task = new Task(TestTask);
            TaskPool.AddTask(task);
            Assert.True(TaskPool.StartTask(task.Id));
        }

        [Fact]
        public void TryRemoveStartedTask()
        {
            TaskPool.ClearAllTasks();

            var task = new Task(TestTask);
            TaskPool.AddTask(task);

            TaskPool.StartTask(task.Id);

            Assert.False(TaskPool.RemoveTask(task.Id));
        }
    }
}