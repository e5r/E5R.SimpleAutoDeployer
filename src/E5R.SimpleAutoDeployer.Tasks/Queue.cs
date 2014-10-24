using Generic = System.Collections.Generic;

namespace E5R.SimpleAutoDeployer.Tasks
{
    public class Queue
    {
        private static Generic.Queue<TaskBase> _waitingQueue = new Generic.Queue<TaskBase>();
        private static Generic.Queue<TaskBase> _initiatedQueue = new Generic.Queue<TaskBase>();
        private static Generic.Queue<TaskBase> _completedQueue = new Generic.Queue<TaskBase>();

        public Generic.Queue<TaskBase> WaitingStack
        {
            get { return _waitingQueue; }
        }

        public Generic.Queue<TaskBase> InitiatedStack
        {
            get { return _initiatedQueue; }
        }

        public Generic.Queue<TaskBase> CompletedStack
        {
            get { return _completedQueue; }
        }

        public bool HasTask
        {
            get
            {
                return _waitingQueue.Count > 0;
            }
        }

        public void AddTask(TaskBase task)
        {
            task.Sattus = Status.Waiting;
            _waitingQueue.Enqueue(task);
        }

        public void InitiateNextTask()
        {
            if (HasTask)
            {
                var task = _waitingQueue.Dequeue();
                task.Sattus = Status.Initiated;
                _initiatedQueue.Enqueue(task);
                // TODO: Add Event Handler on Finished to exchange list
            }
        }
    }
}
