using Xunit;
using System;
using Core.Interfaces.POS;
using Moq;
using Core.Entities.POS;
using Core.Interfaces;
using Tests.Lib.Data;
using Core.Entities.Catalog;
using DAL.Seed;
using Core.Entities.User;
using System.Threading.Tasks;
using Core.Entities.Inventory;

namespace Core.Entities.POS.Tests
{
    public class CashDrawerTests
    {
        public static IRepository<T> GetFakeRepository<T>() where T : BaseEntity =>  new FakeRepository<T>();
        public static Customer FakeCustomer = new("123456789");
        public static POSOrder GetTestOrder(){
            var repository = GetFakeRepository<Product>();            
            var product = new ProductSeed().GetSeedObject();
            product.Id = 1;
            product.UpdateStock(1,product);
            repository.Add(product);
            var order = new POSOrder();
            order.AddItem(product.Id,product.QuantityInStock,repository);
            var task = order.PayAsync(product.QuantityInStock * product.EndCustomerPrice,FakeCustomer);            
            Task.WaitAny(task);
            return order;
        }
        public static ICashDrawerMediator FakeCashDrawerMediator()
        {
            var mockMediator = new Mock<ICashDrawerMediator>();
            mockMediator.Setup(m => m.Open()).Returns(true);
            mockMediator.Setup(m => m.Close()).Returns(true);
            return mockMediator.Object;
        }
        [Fact(DisplayName = "when open cash drawer, domain object should have state 'Open'")]
        public void Given_closed_cash_drawer_When_try_to_open_Then_is_in_open_state()
        {
            // Given
            var cashDrawer = new CashDrawer(200.0m);
            // When
            cashDrawer.Open(FakeCashDrawerMediator());
            // Then
            Assert.Equal(CashDrawerState.Open,cashDrawer.State);
        }
        [Fact(DisplayName = "when close cash drawer, domain object should have state 'Closed'")]
        public void Given_open_cash_drawer_When_try_to_close_Then_cash_drawer_is_in_closed_state()
        {
            // Given
            var cashDrawer = new CashDrawer(200.0m);
            // When
            cashDrawer.Close(FakeCashDrawerMediator());
            // Then
            Assert.Equal(CashDrawerState.Closed, cashDrawer.State);
        }
        [Fact(DisplayName = "if is already closed or open state should be kept")]        
        public void Given_close_or_open_call_When_state_is_needed_is_already_set_Then_state_is_kept()
        {
            // Given
            var cashDrawer = new CashDrawer(200.0m);
            var mediator = FakeCashDrawerMediator();
            //When
            cashDrawer.Open(mediator);
            cashDrawer.Open(mediator);
            //Then
            Assert.Equal(CashDrawerState.Open, cashDrawer.State);
            // or
            //When
            cashDrawer.Close(mediator);
            cashDrawer.Close(mediator);
            //Then
            Assert.Equal(CashDrawerState.Closed, cashDrawer.State);
        }
        [Fact(DisplayName = "Given a order confirmed, a transaction should be created representing the transaction between the client and the service")]
        public void Given_a_confirmed_order_When_receives_order_Then_transaction_is_writed()
        {
            // Given
            var order = GetTestOrder();            
            var cashDrawer = new CashDrawer(200.0m);
            var transaction = new Transaction(order,cashDrawer,0.0m);
            var mediator = FakeCashDrawerMediator();
            cashDrawer.Open(mediator);        
            var previousCashAmount = cashDrawer.StartCashAmount;
            // When
            
            cashDrawer.PerformTransaction(transaction);
            // Then

            Assert.Equal(previousCashAmount - order.OrderTotal,cashDrawer.StartCashAmount,2);
        }
    }
}