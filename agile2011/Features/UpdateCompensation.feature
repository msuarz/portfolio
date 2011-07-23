Feature: Update Compensation
	The Employee Compensation Service should allow to update Compensations

Scenario: Update based on Scheduled hours

	Original
	[ Scheduled Hours | Hourly | Weekly | Period | Annual ]
	| 80              |  24    | 900    | 2000   | 50000  |

	Proposed
	[ Scheduled Hours ]
	| 40			  |

	Update

	Actual
	[ Scheduled Hours | Hourly | Weekly | Period | Annual ]
	| 40              |  24    | 450    | 1000   | 25000  |

Scenario: Update Scheduled Hours and Rate Fields

	Original
	[ Scheduled Hours | Hourly | Annual ]
	| 40			  | 24	   | 25000  |

	Proposed
	[ Scheduled Hours | Hourly | Rate Change Type ]
	| 20			  | 48	   | H				  |

	Update

	Actual
	[ Scheduled Hours | Hourly | Annual ]
	| 20			  | 48	   | 25000  |

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
