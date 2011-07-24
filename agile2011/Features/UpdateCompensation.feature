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
	[ Scheduled Hours | Hourly | Annual | PayFrequency ]
	| 40			  | 25	   | 52000  | W			   |

	Proposed
	[ Scheduled Hours | Hourly ]
	| 20			  | 50	   |

	Update

	Actual
	[ Scheduled Hours | Hourly | Annual ]
	| 20			  | 50	   | 52000  |

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
