using Core.Results;
using Core.Results.Extensions;
using System;
using System.Text;
using Xunit;

namespace Core.Tests.ErrorHandling
{
    public class When_using_results_to_handle_error
    {
        Result<int> AddNumber(int lhs,string rhs)
        {
            if(int.TryParse(rhs,out var iRhs))
            {
                return Result<int>.Ok(iRhs + lhs);
            }
            return Result<int>.Fail(lhs,new Error("rhsIsNotANumber","provided lhs is not a number",true));
        }
        [Fact]
        public void Result_is_ok_if_no_error_is_present()
        {
            var okResult = Result<object>.Ok(new object());
            Assert.True(okResult.Success);
            var failResult = Result<object>.Fail(new object(),new Error("ResultFailed","The result failed",true));
            Assert.False(failResult.Success);
        }
        [Fact]
        public void Bind_will_not_process_following_lines_if_result_has_failed()
        {            
            var result = Result<int>.Ok(1)
                .Bind<int,int>(number => AddNumber(number,"1"))
                .Bind<int,int>(number => AddNumber(number,"X"))
                .Bind<int,int>(number => AddNumber(number,"1"));
            var number = result.Value;
            Assert.Equal(0,number);
        }
        [Fact]
        public void Bind_will_continue_process_if_no_error_exists()
        {            
            var result = Result<int>.Ok(1)
                .Bind<int,int>(number => AddNumber(number,"1"))                
                .Bind<int,int>(number => AddNumber(number,"3"))
                .Bind<int,int>(number => AddNumber(number,"-3"));
            var number = result.Value;
            Assert.Equal(2,number);
        }
        [Fact]
        public void Map_will_map_internal_value_to_another_if_result_is_successful()
        {
            var result = Result<int>.Ok(4)
                .Bind(number => 
                    number % 2 == 0 
                    ? Result<int>.Ok(number) 
                    : Result<int>.Fail(number,new Error("NumberIsNotEven","expected a even number",true)))
                .Map(number => number / 2);
            Assert.Equal(2,result.Value);
        }
        [Fact]
        public void Map_will_not_map_internal_value_if_result_has_failed()
        {
            var result = Result<int>.Ok(4)
                .Bind(number => 
                    number % 2 == 0 
                    ? Result<int>.Ok(number) 
                    : Result<int>.Fail(number,new Error("NumberIsNotEven","expected a even number",true)))
                .Map(number => number / 2);
            Assert.Equal(2,result.Value);
        }
        [Theory]
        [InlineData(4,2)]
        [InlineData(5,2)]
        public void Double_will_map_differently_if_result_has_failed_or_not(int arg,int expected)
        {
            var result = Result<int>.Ok(arg)
                .Bind(number => 
                    number % 2 == 0 
                    ? Result<int>.Ok(number) 
                    : Result<int>.Fail(number,new Error("NumberIsNotEven","expected a even number",true)))
                .DoubleMap(successfulNumber => successfulNumber / 2,
                           failedNumber => (failedNumber - 1) / 2);

            Assert.Equal(expected,result.Value);
        }
        [Fact]
        public void Tee_will_execute_a_method_without_return_on_a_result_and_continue()
        {
            StringBuilder outStr = new StringBuilder();
            var result = Result<int>.Ok(4)
                .Tee(number => Log(outStr,number))
                .Map(number => number + 1)
                .Tee(number => Log(outStr,number));
            var lines = outStr.ToString().Split('\n',StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal(2,lines.Length);
            void Log(StringBuilder output,int value)
            {
                output.AppendLine($"the value {value} was passed to log function");
            }
        }
        [Fact]
        public void TryCatch_will_wrap_a_method_execution_in_a_try_catch()
        {
            var result = Result<string>.Ok("NOT A NUMBER")
                .TryCatch(str => int.Parse(str));
            var error = result.Errors[0] as ExceptionError;
            var value = result.Value;
            Assert.Equal(default(int),value);
            Assert.NotNull(error);            
            Assert.Equal(typeof(FormatException),error.Exception.GetType());
        }
    }
}
