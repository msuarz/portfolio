Feature: Update Compensation
	The Employee Compensation Service should allow to update Compensations

Scenario: Increase Salary

	When the hourly rate increases
	Then the salary should increase

Scenario: Double hourly rate

	When the hourly rate doubles
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

Scenario: Update based on Scheduled hours

	Original
	[ Scheduled Hours | Hourly | Annual ]
	| 40              | 25     | 52000  |

	Proposed
	[ Scheduled Hours ]
	| 80              |

	Update

	Actual
	[ Scheduled Hours | Hourly | Annual  ]
	| 80              | 25     | 104000  |

Scenario: Update Scheduled Hours and Rate Fields

	Original
	[ Scheduled Hours | Hourly | Annual ]
	| 40              | 25     | 52000  |

	Proposed
	[ Scheduled Hours | Hourly ]
	| 20              | 50     |

	Update

	Actual
	[ Annual ]
	| 52000  |
