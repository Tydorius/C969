## Classes
Calendar
- +LoadMonth
- +LoadWeek
- +ConvertTime(DATETIME, TIMEZONE)

Event
- +CreateEvent
- +UpdateEvent
- +DeleteEvent
- +ArchiveEvent
- -Title
- -StartDate
- -StartTime
- -EndDate
- -EndTime
- -Owners<User>
- -Customer
- *CheckForConflicts()

AlertList
- +QueueAlerts
- +SendAlerts

UserList
- +CreateUser
- +UpdateUser
- +DeleteUser

User
- -Username
- -PasswordHash
- -Language

CurrentUser : User
- -TimeZone

Timezone
- -TimeZoneID
- -Name
- -GMT
- -StartDate
- -EndDate


Customer
- +CreateCustomer
- +UpdateCustomer
- +DeleteCustomer
- -customerId INT(10) (Int32)
- -customerName VARCHAR(45) (String)
- -addressId INT(10) (Address class)
- -active TINYINT(1) (Boolean)
- -createDate DATETIME
- -createdBy VARCHAR(40)
- -lastUpdate TIMESTAMP
- -lastUpdateBy VARCHAR(40) 

frmLogIn
- *LogIn(Username,Password)
- --> frmCalendar

frmCalendar
- *LoadCalendar(User,PasswordHash)
- *ViewCustomers
- *ViewAccount
- *ViewReports
- --> frmCustomers
- --> frmAccount
- --> frmReports

frmCustomers
- *LoadCustomers
- *ViewCustomer
- *NewCustomer

frmAccount
- *LoadUser
- *UpdateUser

frmReports
- *CreateReport
- *DownloadReport

## Requirements:
- Login form that supports multiple languages. At least one additional language should exist. (Spanish) It should provide rejection results based on login failure.
- Ability to add, update, and delete customer records.
- Ability to add, update, and delete appointments.
- Ability to view calendar by month or by week.
- Ability to adjust appointment times based on user time zones and daylight-savings-time.
- Exception control to prevent booking outside normal business hours.
- Exception control to prevent overlapping appointments.
- Exception control to enforce customer attachment.
- Exception control for login attempts.
- Two or more lambda expressions, with comments justifying their purpose.
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions#expression-lambdas
- Reminders/Alerts 15 minutes ahead of appointments.
- Ability to generate report on number of appointment types by month.
- Ability to generate report with the schedule of each consultant.
- One additional report of choice.
- Track user activity via a local login text file.

## Notes and Observations:
- No security or password hashing requirements. Will simplify the login process.
- userName VARCHAR(50) is ten characters longer than createdBy VARCHAR(40) fields that exist on all database entries. Will be enforcing a character limit of 40 for all users.
- All times will be stored in GMT +0 and converted.
