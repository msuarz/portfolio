Feature: Update Compensation
	The Employee Compensation Service should allow to update Compensations

Scenario: Increase Salary

	When the hourly rate increases
	Then the salary should increase

Scenario: Double hourly rate

	When the hourly rate increases twice
	Then the salary should double

Scenario: Change by Hourly Rate

	Given the hourly rate is "25"
		and the salary is "52000"
	When the hourly rate changes to "50"
	Then the salary should be "104000"

Scenario Outline: Change by Hourly Rate

	Given the hourly rate is "Original Hourly"
		and the salary is "Original Salary"
	When the hourly rate changes to "Proposed Hourly"
	Then the salary should be "Actual Salary"

	Examples:
	| Original Hourly | Original Salary | Proposed Hourly | Actual Salary |
	| 25              | 52000           | 50              | 104000        | 
	| 50              | 104000          | 25              | 52000         | 
	| 50              | 104000          | 0               | 0             | 

Scenario Outline: Change by Rate

	Given the "Rate" is "Original Rate"
		and the salary is "Original Salary"
	When the "Rate" changes to "Proposed Rate"
	Then the salary should be "Actual Salary"

	Examples:
	| Rate | Original Rate | Original Salary | Proposed Rate | Actual Salary |
	| H    | 25            | 52000           | 50            | 104000        | 
	| Y    | 100000        | 100000          | 50000         | 50000         | 
	| W    | 1000          | 52000           | 2000          | 104000        | 


Scenario: Change by Percentages

	Update by Percent & Salary increases X times
	[ Percent | Times ]
	| 100	  | 2	  |
	| 200	  | 3	  |
	| -50	  | 0.5   |

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
