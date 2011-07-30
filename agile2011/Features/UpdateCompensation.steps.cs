namespace Features 
{
    public partial class UpdateCompensation : CompensationSteps
    {
        void Update_by_Percent___Salary_increases_X_times(int Percent, double Times)
        {
            proposed.PercentChange = Percent;

            EnsureUpdate(proposed);

            AssertSalaryIncreasedTimes((decimal) Times);        
        }

        void When_the_hourly_rate_increases()
        {
            
        }

        void Then_the_salary_should_increase()
        {
            
        }

        void When_the_hourly_rate_increases_twice()
        {
            
        }

        void Then_the_salary_should_double()
        {
            
        }

        void Given_the_hourly_rate_is(int HourlyRate)
        {
            
        }

        void and_the_salary_is(int Salary)
        {
            
        }

        void When_the_hourly_rate_changes_to(int HourlyRate)
        {
            
        }

        void Then_the_salary_should_be(int Salary)
        {
            
        }

        void Given_the__is(string Rate, int Value)
        {
            
        }

        void When_the__changes_to(string Rate, int Value)
        {
            
        }
    }
}
