using Xunit;
using System;
using Core.Interfaces.POS;
using Moq;

namespace Core.Entities.POS.Tests
{
    public class CashDrawerTests
    {
        public ICashDrawerMediator FakeCashDrawerMediator()
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
            var cashDrawer = new CashDrawer();            
            // When
            cashDrawer.Open(FakeCashDrawerMediator());
            // Then
            Assert.Equal(CashDrawerState.Open,cashDrawer.State);
        }
        [Fact(DisplayName = "when close cash drawer, domain object should have state 'Closed'")]
        public void Given_open_cash_drawer_When_try_to_close_Then_cash_drawer_is_in_closed_state()
        {
            // Given
            var cashDrawer = new CashDrawer();
            // When
            cashDrawer.Close(FakeCashDrawerMediator());
            // Then
            Assert.Equal(CashDrawerState.Closed, cashDrawer.State);
        }
        [Fact(DisplayName = "if is already closed or open state should be kept")]        
        public void Given_close_or_open_call_When_state_is_needed_is_already_set_Then_state_is_kept()
        {
            // Given
            var cashDrawer = new CashDrawer();
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
        [Fact(DisplayName = "Given ")]
        public void Given_()
        {

        }
    }
}