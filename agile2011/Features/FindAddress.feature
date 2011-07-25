Feature: Find Address
	The Employee Address Service should allow to find Addresses

Scenario: Abstract

	When I search for addresses of an existing Employee
	I should get the corresponding addresses

Scenario: More explicit but unmanagable 

	When I search for addresses of employees in EAST
	I should get the corresponding addresses

Scenario: Using Args

	When I search for addresses of employees with "Organization Level1" "=EAST"
	and "Last Name" "like (A%)"
	I should get the corresponding addresses

Scenario: Table

	When I search for addresses
	| Organization Level1 | =EAST         |
	| Last Name           | like (A%)     |
	| Former Name         | not isblank() |
	I should get the corresponding addresses

Scenario: Fixture

	Query
	[ Last Name	| First Name ]
	| like(%o%)	| =Jack	     |

	Find

	Employees
	[ first name | last name ]
	| Jack       | Ross      |
	| Jack       | Locke     |

	Addresses
	[ Address line1  | City   | Country | Zip or postal code ]
	| 1 Ross         | Neo    | USA     | 458668764          |
	| 1261 The Links | Ithaca | USA     | 14886              |

Scenario: DSL

	Find
	[ Organization Level1 | Last Name | First Name | Former Name ]
	| =EAST               | =Doe      | =John      |             |
	| in(EAST, WEST)      |           |            | isblank()   |
