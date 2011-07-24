Feature: Update Job
	The Employee Job Service should allow to update Jobs

Scenario: Update Fields

	Update
    [ Field            | Value      | Alt Value ]
    | HourlyOrSalaried | "H"        | "S"       |
    | ReasonCode       | "100"      | "101"     |
    | FullOrPartTime   | "F"        | "P"       |
    | JobCode          | "DELIV"    | "SALES"   |
    | AlternateTitle   | "Magician" | "Doctor"  |
    | OrgLevel1        | "EAST"     | "Z"       |
    | OrgLevel2        | "HQ"       | null      |
    | OrgLevel3        | "EXEC"     | null      |
    | OrgLevel4        | "SOFLO"    | null      |
    | ShiftCode        | "01"       | "Z"       |
    | Seasonal         | true       | false     |
    | Agricultural     | true       | false     |
    | DirectLabor      | true       | false     |
