using Microsoft.Ccr.Core;
using System;

namespace Zhongmubao.Push.MQ
{
    /// <summary>
    /// 队列处理类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueueProcessor<T>
    {
        protected Dispatcher dispatcher;
        protected DispatcherQueue dispatcherQueue;
        public ProcessorDelegate ProcessQueue;
        private string queueName;
        protected Port<T> port;
        protected int upperBound;
        public QueueProcessor(string queueName, int threadCount, int queueLength)
        {
            this.queueName = queueName;
            upperBound = queueLength;
            dispatcher = new Dispatcher(threadCount, this.queueName);
            dispatcherQueue = new DispatcherQueue(this.queueName, dispatcher, TaskExecutionPolicy.ConstrainQueueDepthDiscardTasks, queueLength);
            port = new Port<T>();
        }

        public void Enqueue(T item)
        {
            port.Post(item);
            InternalProcessQueue();
        }
        
        protected void InternalProcessQueue()
        {
            Receiver<T> receiver = Arbiter.Receive(true, port, item => QueueHandler(item));
            Arbiter.Activate(dispatcherQueue, new ITask[] { receiver });
        }
        
        private void QueueHandler(T item)
        {
            try
            {
                ProcessQueue(item);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public delegate void ProcessorDelegate(T item);
    }
}
