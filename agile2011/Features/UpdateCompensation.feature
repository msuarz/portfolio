Feature: Update Compensation
	The Employee Compensation Service should allow to update Compensations

Scenario: Update based on Scheduled hours

	Original
	[ Scheduled Hours | Rate Change Type | Annual ]
	| 80              | Y                | 50000  |

	Proposed
	[ Scheduled Hours ]
	| 40			  |

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

Scenario: Update based on Percentages

	Update by Percent & Salary increases X times
	[ Percent | Times ]
	| 100	  | 2	  |
	| 200	  | 3	  |
	| -50	  | 0.5	  |

Scenario: Update based on Rate
	
	Update by Rate
	[ Rate | Property ]
	| H	   | Hourly   |
	| W    | Weekly   |
	| P    | Period	  |
	| Y    | Annual	  |
