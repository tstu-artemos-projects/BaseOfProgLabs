using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3.BookStoreLibrary
{
    /// <summary>
    /// Очередь покупателей в магазине
    /// </summary>
    public class CustomerQueue
    {
        private readonly Queue<Customer> _queue;
        private readonly int _maxCapacity; // предел очереди (зависит от сложности)
        private readonly int _maxUnsatisfiedCapacity; // предел очереди (зависит от сложности)
        private int _unsatisfiedCount; // счётчик неудовлетворённых клиентов

        public int Count => _queue.Count;
        public int UnsatisfiedCount => _unsatisfiedCount;
        public bool IsEmpty => _queue.Count == 0;
        public int MaxCapacity => _maxCapacity;

        public event Action<Customer>? CustomerAdded; // для взаимодействия с формой
        public event Action<Customer>? CustomerRemoved;
        public event Action? UnsatisfiedLimitReached;
        public event Action? QueueLimitReached;
        // Когда добавился покупатель форма обновит отображение очереди
        // Когда очередь переполнена QueueLimitReached то конец
        // Когда 3 недовольных клиента UnsatisfiedLimitReached то конец


        /// <param name="maxCapacity">Макс. длина очереди (3-5 в зависимости от сложности)</param>
        /// <param name="maxUnsatisfiedCapacity">Максимальное количество недовольных</param>
        public CustomerQueue(int maxCapacity = 5, int maxUnsatisfiedCapacity = 5)
        {
            if (maxCapacity < 1)
                throw new ArgumentOutOfRangeException(nameof(maxCapacity));

            _maxCapacity = maxCapacity;
            _queue = new Queue<Customer>();
            _unsatisfiedCount = 0;
            _maxUnsatisfiedCapacity = maxUnsatisfiedCapacity;
        }

        // управление очередью

        /// <summary>
        /// Добавить покупателя в очередь.
        /// Возвращает false, если очередь переполнена (условие проигрыша).
        /// </summary>
        public bool Enqueue(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            if (_queue.Count >= _maxCapacity)
            {
                QueueLimitReached?.Invoke();
                return false; // Проигрыш: очередь переполнена
            }

            _queue.Enqueue(customer);
            CustomerAdded?.Invoke(customer);
            return true;
        }


        /// <summary>
        /// Получить следующего покупателя из очереди (без удаления).
        /// </summary>
        public Customer? Peek() => _queue.Count > 0 ? _queue.Peek() : null;

        /// <summary>
        /// Удалить и вернуть следующего покупателя из очереди.
        /// </summary>
        public Customer? Dequeue()
        {
            if (_queue.Count == 0) return null;

            var customer = _queue.Dequeue();
            CustomerRemoved?.Invoke(customer);
            return customer;
        }

        /// <summary>
        /// Покупатель обслужен успешно — удаляем из очереди.
        /// </summary>
        public bool ServeCustomer(Customer customer)
        {
            if (customer == null) return false;        
            if (!_queue.Contains(customer)) return false; // Проверяем, что покупатель действительно в очереди            
            var tempQueue = new Queue<Customer>(); // Удаляем конкретного покупателя (т.к. Queue не поддерживает Remove)
            bool found = false;

            while (_queue.Count > 0)
            {
                var c = _queue.Dequeue();
                if (c == customer && !found)
                {
                    found = true;
                    customer.Serve();
                    CustomerRemoved?.Invoke(customer);
                }
                else
                {
                    tempQueue.Enqueue(c);
                }
            }
            while (tempQueue.Count > 0) //восстановление очереди
                _queue.Enqueue(tempQueue.Dequeue());

            return found;
        }

        /// <summary>
        /// Покупатель уходит неудовлетворённым.
        /// Возвращает true, если достигнут лимит неудовлетворённых (условие проигрыша).
        /// </summary>
        public bool CustomerLeavesUnsatisfied(Customer customer)
        {
            if (customer == null) return false;
            customer.LeaveUnsatisfied();
            _unsatisfiedCount++;            
            ServeCustomer(customer); // Удаляем покупателя из очереди
            if (_unsatisfiedCount >= _maxUnsatisfiedCapacity)
            {
                UnsatisfiedLimitReached?.Invoke();
                return true; // Проигрыш
            }
            return false;
        }

        /// <summary>
        /// Проверка, подходит ли книга для первого покупателя в очереди.
        /// </summary>
        public bool CanServeFirstCustomer(Book book, decimal salePrice)
        {
            var customer = Peek();
            if (customer == null) return false;

            return customer.CheckBook(book) && customer.CheckPrice(salePrice);
        }

        /// <summary>
        /// Сброс статистики (для новой игры).
        /// </summary>
        public void Reset()
        {
            _queue.Clear();
            _unsatisfiedCount = 0;
        }

        /// <summary>
        /// Получить копию очереди для отображения в интерфейсе.
        /// </summary>
        public List<Customer> GetQueueSnapshot() => _queue.ToList();
    }
}