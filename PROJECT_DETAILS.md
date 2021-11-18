## INTRODUCTION
Throughout your career in software design and development, you will be asked to create applications with various features and criteria based on a variety of business requirements. For this assessment, you will create your own C# application with requirements that mirror those you will encounter in a real-world job assignment.

The skills you will showcase in this assessment are also directly relevant to technical interview questions for future employment. This application should become a portfolio piece for you to show to future employers.

Several attachments and links have been included to help you complete this task. The attached “Database ERD” shows the entity relationship diagram (ERD) for this database, which you can reference as you create your application.

For this task, you will use the Performance Assessment Lab Area accessed by the Performance Assessment Lab Area link to access the virtual lab environment to complete this task. The preferred integrated development environment (IDE) for this assignment is Visual Studio. If you choose to use another IDE, you must export your project into Visual Studio format for submission.

Your submission should include a zip file with all the necessary code files to compile, support, and run your application. The zip file submission must also keep the project file and folder structure intact for the Visual Studio IDE.

## SCENARIO
You are working for a software company that has been contracted to develop a scheduling desktop user interface application. The contract is with a global consulting organization that conducts business in multiple languages and has main offices in Phoenix, Arizona; New York, New York; and London, England. The consulting organization has provided a MySQL database that your application must pull data from. The database is used for other systems and therefore its structure cannot be modified.

The organization outlined specific business requirements that must be included as part of the application. From these requirements, a system analyst at your company created solution statements for you to implement in developing the application. These statements are listed in the requirements section.

## REQUIREMENTS
Your submission must be your original work. No more than a combined total of 30% of the submission and no more than a 10% match to any one individual source can be directly quoted or closely paraphrased from sources, even if cited correctly.

You must use the rubric to direct the creation of your submission because it provides detailed criteria that will be used to evaluate your work. Each requirement below may be evaluated by more than one rubric aspect. The rubric aspect titles may contain hyperlinks to relevant portions of the course.

You are not allowed to use frameworks or external libraries. The database does not contain data, so it needs to be populated. You must use “test” as the user name and password to login.

A.   Create a log-in form that can determine the user’s location and translate log-in and error control messages (e.g., “The username and password did not match.”) into the user’s language and in one additional language.

B.  Provide the ability to add, update, and delete customer records in the database, including name, address, and phone number. 

C.   Provide the ability to add, update, and delete appointments, capturing the type of appointment and a link to the specific customer record in the database.

D.   Provide the ability to view the calendar by month and by week. 

E.   Provide the ability to automatically adjust appointment times based on user time zones and daylight-saving time.

F.   Write exception controls to prevent each of the following. You may use the same mechanism of exception control more than once, but you must incorporate at least two different mechanisms of exception control.
- scheduling an appointment outside business hours
- scheduling overlapping appointments
- entering nonexistent or invalid customer data
- entering an incorrect username and password

G.  Write two or more lambda expressions to make your program more efficient, justifying the use of each lambda expression with an in-line comment.

H.  Write code to provide reminders and alerts 15 minutes in advance of an appointment, based on the user’s log-in.

I.   Provide the ability to generate each of the following reports using the collection classes:
- number of appointment types by month
- the schedule for each consultant
- one additional report of your choice

J.   Provide the ability to track user activity by recording timestamps for user log-ins in a .txt file. Each new record should be appended to the log file if the file already exists.

K.   Demonstrate professional communication in the content and presentation of your submission.

File Restrictions
File name may contain only letters, numbers, spaces, and these symbols: ! - _ . * ' ( )
File size limit: 200 MB
File types allowed: doc, docx, rtf, xls, xlsx, ppt, pptx, odt, pdf, txt, qt, mov, mpg, avi, mp3, wav, mp4, wma, flv, asf, mpeg, wmv, m4v, svg, tif, tiff, jpeg, jpg, gif, png, zip, rar, tar, 7z

## RUBRIC
### A:LOG-IN FORM

COMPETENT

The log-in form has functionality to determine the user’s location and translate log-in and error control messages into the user’s language and in 1 additional language. The code is complete and functions properly.

- Complete.

### B:CUSTOMER RECORDS

COMPETENT

The application has functionality to add, update, and delete customer records in the database, including name, address, and phone number. The code is complete and functions properly.

- Complete.

### C:APPOINTMENTS

COMPETENT

The application code has functionality to add, update, and delete appointments, capture the type of appointment, and link the appointments to the specific customer record in the database. The code is complete and functions properly.

- Complete.

### D:CALENDAR VIEWS

COMPETENT

The application has functionality to view the calendar by month and by week. The code is complete and functions properly.

- Complete.

### E:TIME ZONES

COMPETENT

The application has functionality to automatically adjust appointment times based on user time zones and daylight-saving time. The code is complete and functions properly.

- Complete.

### F:EXCEPTION CONTROL

COMPETENT

The application code includes exception controls to prevent each of the given points and uses at least 2 different mechanisms. The code is complete and functions properly.

### G:LAMBDA EXPRESSIONS

COMPETENT

The application code includes 2 or more appropriate lambda expressions to make the program more efficient and provides a logical justification of the use of each lambda expression with in-line comments. The code is complete and functions properly.

### H:ALERTS

COMPETENT

The application has functionality for an alert if there is an appointment within 15 minutes of the user’s log-in. The code is complete and functions properly.

### I:REPORTS

COMPETENT

The application has functionality to generate each of the given reports. The code is complete and functions properly.

### J:ACTIVITY LOG

COMPETENT

The application has functionality to track user activity by recording timestamps for user log-ins in a .txt file, and each new record is appended to the log file if the file already exists. The code is complete and functions properly.

- Complete

### K:PROFESSIONAL COMMUNICATION

COMPETENT

Content reflects attention to detail, is organized, and focuses on the main ideas as prescribed in the task or chosen by the candidate. Terminology is pertinent, is used correctly, and effectively conveys the intended meaning. Mechanics, usage, and grammar promote accurate interpretation and understanding.
