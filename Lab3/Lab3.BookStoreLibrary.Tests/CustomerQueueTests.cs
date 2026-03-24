using Xunit;
using Lab3.BookStoreLibrary;
using System.Collections.Generic;

namespace Lab3.Tests
{
    public class CustomerQueueTests
    {
        [Fact]
        public void Enqueue_AddsCustomer_WhenSpaceAvailable()
        {
            // arrange
            var queue = new CustomerQueue(maxCapacity: 2);//создаём очередь на 2 места 
            var customer = new Customer(1, RequestType.Genre, null, null, "Fantasy", 500);//и создаём 1 человека
            // act
            bool result = queue.Enqueue(customer);
            // assert
            Assert.True(result);// проверяем, что метод вернул true и сount = 1
            Assert.Equal(1, queue.Count);
        }

        [Fact]
        public void Enqueue_ReturnsFalse_AndTriggersEvent_WhenQueueIsFull()
        {
            // arrange
            var queue = new CustomerQueue(maxCapacity: 1);
            var customer1 = new Customer(1, RequestType.Genre, null, null, "Fantasy", 500);
            var customer2 = new Customer(2, RequestType.Genre, null, null, "Sci-Fi", 300);
            bool eventRaised = false;
            queue.QueueLimitReached += () => eventRaised = true;//забиваем очередь до максимума и пытаемся добавить еще одного
            // act
            queue.Enqueue(customer1);
            bool result = queue.Enqueue(customer2);
            // assert
            Assert.False(result);
            Assert.True(eventRaised);
        }

        [Fact]
        public void ServeCustomer_RemovesSpecificCustomer_AndSetsStatus()
        {
            //проверяет, что  покупатель исчез из очереди и у объекта покупателя вызвался метод Serve и IsServed стал true
            
            // arrange
            var queue = new CustomerQueue();
            var customer = new Customer(1, RequestType.SpecificBook, "1984", "Orwell", null, 1000);
            queue.Enqueue(customer);
            // act
            bool result = queue.ServeCustomer(customer);
            // assert
            Assert.True(result);
            Assert.Empty(queue.GetQueueSnapshot());
            Assert.True(customer.IsServed);
        }

        [Fact]
        public void CustomerLeavesUnsatisfied_IncrementsCounter_AndTriggersLimitEvent()// проверяем предел недовольных клиентов
        {
            //a rrange
            var queue = new CustomerQueue();
            var c1 = new Customer(1, RequestType.Genre, null, null, "G1", 100);
            var c2 = new Customer(2, RequestType.Genre, null, null, "G2", 100);
            var c3 = new Customer(3, RequestType.Genre, null, null, "G3", 100);
            queue.Enqueue(c1);
            queue.Enqueue(c2);
            queue.Enqueue(c3);

            bool limitReachedEvent = false;
            queue.UnsatisfiedLimitReached += () => limitReachedEvent = true;

            // act
            queue.CustomerLeavesUnsatisfied(c1);
            queue.CustomerLeavesUnsatisfied(c2);
            bool isGameOver = queue.CustomerLeavesUnsatisfied(c3); 

            // assert
            Assert.Equal(3, queue.UnsatisfiedCount);
            Assert.True(isGameOver);
            Assert.True(limitReachedEvent);
        }

        //[Fact]
        //public void Reset_ClearsAllData()
        //{
        //    // arrange
        //    var queue = new CustomerQueue();
        //    queue.Enqueue(new Customer(1, RequestType.Genre, null, null, "G1", 100));
        //    // act
        //    queue.Reset();
        //    // assert
        //    Assert.Equal(0, queue.Count);
        //    Assert.Equal(0, queue.UnsatisfiedCount);
        //}
    }
}