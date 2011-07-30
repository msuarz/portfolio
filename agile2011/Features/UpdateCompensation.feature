Feature: Update Compensation
	The Employee Compensation Service should allow to update Compensations

Scenario: Increase Salary

	When the hourly rate increases
	Then the salary should increase

Scenario: Double hourly rate

	When the hourly rate increases twice
	Then the salary should double

Scenario: Change by Hourly Rate

	Given the hourly rate is "20"
		and the salary is "50000"
	When the hourly rate changes to "40"
	Then the salary should be "100000"

Scenario Outline: Change by Hourly Rate

	Given the hourly rate is "Original hourly rate"
		and the salary is "Original salary"
	When the hourly rate changes to "Proposed hourly rate"
	Then the salary should be "Actual Salary"

	Examples:
	| Original hourly rate | Original salary | Proposed hourly rate | Actual Salary |
	| 20                   | 50000           | 40                   | 100000        | 
	| 40                   | 100000          | 20                   | 50000         | 
	| 40                   | 100000          | 0                    | 0             | 

Scenario Outline: Change by Rate

	Given the "Rate" is "Original rate"
		and the salary is "Original salary"
	When the "Rate" changes to "Proposed rate"
	Then the salary should be "Actual Salary"

	Examples:
	| Rate | Original rate | Original salary | Proposed rate | Actual Salary |
	| H    | 20            | 50000           | 40            | 100000        | 
	| Y    | 100000        | 100000          | 50000         | 50000         | 
	| W    | 2000          | 80000           | 4000          | 160000        | 


Scenario: Change by Percentages

	Update by Percent & Salary increases X times
	[ Percent | Times ]
	| 100	  | 2	  |
	| 200	  | 3	  |
	| -50	  | 0.5	  |

Scenario: Update based on Scheduled hours

	Original
	[ Scheduled Hours | Rate Change Type | Annual ]
	| 80              | Y                | 50000  |

	Proposed
	[ Scheduled Hours ]
	| 40              |

	Update

	Actual
	[ Scheduled Hours | Annual ]
	| 40              | 25000  |

Scenario: Update Scheduled Hours and Rate Fields

	Original
	[ Annual | RateChangeType ]
	| 52000  | Y              |

	Proposed
	[ Field	         | Times ]
	| ScheduledHours | 0.5   |
	| Hourly         | 2     |

	Update

	Actual
	[ Annual ]
	| 52000  |
