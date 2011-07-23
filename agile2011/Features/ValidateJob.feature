﻿Feature: Validate Job
	All fields should be validated before submiting an Employee Job change

Scenario: Validate PayGroup

	Original
	[ Pay Group ]
	| BIWEEKLY	|

	Proposed
	[ Pay Group ]
	| bad value |

	Update

	Actual
	[ Pay Group ]
	| BIWEEKLY  |

	Status
	[ Success ]
	| false	  |

	Messages
	[ Property Name  | Message					   ]
	| RateChangeType | Lookup code does not exist. |

Scenario: Validate fields

	Validate
	[ Field			 | Value		| Error								]
	| PayGroup		 | ""           | The following field is required:  |
	| PayGroup		 | "01X"		| Lookup code does not exist.		|
	| TimeClock		 | "1234567890" | Parameter exceeds maximum length. |
	| ScheduledHours | -1			| Value is not within valid range	|
	| ScheduledHours | 100000000	| Value is not within valid range	|

Scenario: Validate cannot clear Required Fields
	
	Validate Required Fields
	| Pay Group			 |
	| Job Code			 |
	| Reason Code		 |
	| Employee Type		 |
	| Hourly Or Salaried |
	| Full Or Part Time	 |


Scenario: Validate UCD fields

	Validate UCD Fields
	| PayGroup			|
	| JobCode			|
	| ReasonCode		|
	| EmployeeType		|
	| HourlyOrSalaried	|
	| FullOrPartTime	|
	| OrgLevel1			|
	| OrgLevel2			|
	| OrgLevel3			|
	| OrgLevel4			|
	| ShiftCode			|
