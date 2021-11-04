## Classes
### Calendar
- Month LoadMonth(DateTime)
- Week LoadWeek(DateTime)
- DateTime ConvertTime(DateTime, TimeZone)

### Week
- BindingList Sunday<Day>
- BindingList Monday<Day>
- BindingList Tuesday<Day>
- BindingList Wednesday<Day>
- BindingList Thursday<Day>
- BindingList Friday<Day>
- BindingList Saturday<Day>

abstract ### Day
- Integer DayOfYear
- Integer DayofMonth
- Integer DayofWeek

abstract ### User
- String Username
- String PasswordHash
- String Language

### CurrentUser
- String TimeZone

### UserDay
- BindingList AppointmentBindingList<Appointment>
- User CurrentUser

### AlertList
- QueueAlerts(CurrentUser)
- SendAlert(Alert)
- BindingList Alerts<Alert>

### Alert
- Integer AppointmentID
- DateTime StartDateTime

### frmLogIn
- CurrentUser LogIn(Username,Password)

### frmCustomers
- Boolean CreateCustomer(Customer)
- Boolean UpdateCustomer(CustomerID, Customer)
- Boolean DeleteCustomer(CustomerID)
- Void LoadCustomers()
- Boolean ViewCustomer(CustomerID)

### frmAccount
- Boolean LoadUser(CurrentUser)
- Boolean UpdateUser(UserID, User)

### frmCalendar
- Boolean LoadCalendar(CurrentUser)
- Void ViewCustomers()
- Void ViewAccount()
- Void ViewReports()
- Void ViewUsers()

### frmAppointment
- Boolean CreateAppointment(Appointment)
- Boolean UpdateAppointment(AppointmentID, Appointment)
- Boolean CheckForConflicts(AppointmentID)
- Boolean DeleteAppointment(AppointmentID)

### frmReports
- Boolean CreateReport(ReportID)
- Boolean DownloadReport(CurrentReport)
- Report CurrentReport

### Report
- array ReportData

### frmUsers
- Boolean CreateUser(User)
- Boolean UpdateUser(UserID, User)
- Boolean DeleteUser(UserID)

### Country
- countryId int
- country varchar(50)
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

### Customer
- customerId int
- customerName varchar(45)
- addressId int
- active tinyint(1)
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

### Address
- addressId int
- address varchar(50)
- address2 varchar(50)
- cityId int
- postalCode varchar(10)
- phone varchar(20)
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

### City
- cityId int
- city varchar(50)
- countryId int
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

### Appointment
- appointmentId int
- customerId int
- userId int
- title varchar(255)
- description text
- location text
- contact text
- type text
- url varchar(255)
- start datetime
- end datetime
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

### User
- userId int
- userName varchar(50)
- password varchar(50)
- active tinyint
- createDate datetime
- createdBy varchar(40)
- lastUpdate timestamp
- lastUpdateBy varchar(40)

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
